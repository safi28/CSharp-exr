"use strict";

class SpaceShip extends HTMLElement {
    shadow;
    directionsMap = {
        up: 0,
        right: 90,
        left: -90,
        down: 180
    }
    options = {
        "dir": "right",
        "t": "0",
        "l": "0",
        "engine": "off"
    }

    constructor(options) {
        super();
        this.options = { ...this.options, ...options || {} };
    }

    adoptedCallback() {
        console.log("attached");
    }

    connectedCallback() {
        this.shadow = this.attachShadow({ mode: "closed" });
        const div = document.createElement("div");

        ["generic", "dir", "t", "l", "engine"].forEach(x => {
            const style = document.createElement("style");
            style.id = x;
            this.shadow.appendChild(style);
        });

        this.setAttribute("dir", this.options.dir);
        this.setAttribute("t", this.options.t);
        this.setAttribute("l", this.options.l);
        this.setAttribute("engine", this.options.engine);

        this.renderStyles("generic");

        this.shadow.appendChild(div);
    }

    disconnectedCallback() {
        console.log("disconnected");
    }

    renderStyles(id, params) {
        this.shadow.querySelector(`#${id}`)
            .textContent = this[`renderStyles_${id}`](params);
    }

    renderStyles_generic() {
        return `
        div {
            box-sizing: border-box;
            background-color: rgba(255, 0, 0, .5);
            display: block;
            position: absolute;
            height: 210px;
            width: 210px;
            background-repeat: no-repeat;
            background-size: 420px 210px;
        
            transition-delay: 0s;
            transition-duration: 50ms;
            transition-property: transform;
            transition-timing-function: linear;
        
            background-image: url(/assets/ship-sprite.gif);
        }
        `;
    }
    renderStyles_dir({ dir }) {
        return `
        div {
            transform: rotate(${this.directionsMap[dir]}deg);
        }`;
    }
    renderStyles_t({ t }) {
        return `
        div {
            top: ${t}px;
        }`;
    }
    renderStyles_l({ l }) {
        return `
        div {
            left: ${l}px;
        }`;
    }
    renderStyles_engine({ engine }) {
        return `
        div {
            background-position: ${engine === "off" ? 0 : -210}px 0px;
        }`;
    }

    static get observedAttributes() {
        return ["dir", "t", "l", "engine"];
    }

    attributeChangedCallback(name, _, newValue) {
        this.renderStyles(name, { [name]: newValue });
    }
}

const keysMap = {
    ArrowUp: "up",
    ArrowDown: "down",
    ArrowLeft: "left",
    ArrowRight: "right",
}

const actionsMap = {
    Space: ship => {
        ship.setAttribute("engine", ship.getAttribute("engine") === "off" ? "on" : "off");
    },
}

function handleKeyboard(ship, keys, actions, e) {
    if (typeof keys[e.code] !== "undefined") {
        ship.setAttribute("dir", keys[e.code]);
    }
    if (typeof actions[e.code] === "function") {
        actions[e.code](ship);
    }
}

window.customElements.define('space-ship', SpaceShip);


function detectColision(o1, o2) {
    const o2L = o2.left + o2.width / 1.25;
    const o2T = o2.top + o2.height / 1.25;
    const o1L = o1.left + o1.width;
    const o1T = o1.top + o1.height;

    if (
        o2L >= o1.left && o2T >= o1.top &&
        o1L >= o2.left && o1T >= o2.top
    ) {
        return true;
    }
}

function animate(ship, animateStars) {
    if (ship.getAttribute("engine") === "on") {
        const dir = ship.getAttribute("dir");
        const l = ship.getAttribute("l");
        const t = ship.getAttribute("t");
        const speed = 1;

        const colision = detectColision(_asteroid, {
            top: Number(t),
            left: Number(l),
            width: 210,
            height: 210
        });

        if (colision) {
            console.log("Ooops...");
            ship.setAttribute("engine", "off");
            return false;
        }

        if (dir === "right") {
            let left = Number(l) + speed;
            if (left > window.innerWidth - 260) {
                left = window.innerWidth - 260;
                ship.setAttribute("engine", "off");
            }
            animateStars(left * -1, "X");
            ship.setAttribute("l", left);
        }

        if (dir === "left") {
            let left = Number(l) - speed;
            if (left < 0) {
                left = 0;
                ship.setAttribute("engine", "off");
            }
            animateStars(left * -1, "X");
            ship.setAttribute("l", left);
        }

        if (dir === "down") {
            let top = Number(t) + speed;
            if (top > window.innerHeight - 260) {
                top = window.innerHeight - 260;
                ship.setAttribute("engine", "off");
            }
            animateStars(top * -1, "Y");
            ship.setAttribute("t", top);
        }

        if (dir === "up") {
            let top = Number(t) - speed;
            if (top < 0) {
                top = 0;
                ship.setAttribute("engine", "off");
            }
            animateStars(top * -1, "Y");
            ship.setAttribute("t", top);
        }
    }
    requestAnimationFrame(animate.bind(undefined, ship, animateStars));
}

function animateStars(stars, step, dir) {
    stars.forEach(x => {
        x[0].style[`backgroundPosition${dir}`] = `${step * x[1]}px`;
    })
}

const _asteroid = {
    width: 100,
    height: 100,
    top: 250,
    left: 300
}

function main() {
    const ship = new SpaceShip();
    const stars = [
        [document.all.far, 1],
        [document.all.mid, 4],
        [document.all.near, 8]
    ]

    const asteroid = document.createElement("div");
    asteroid.style.width = `${_asteroid.width}px`
    asteroid.style.height = `${_asteroid.height}px`
    asteroid.style.background = "cyan"
    asteroid.style.position = "absolute"
    asteroid.style.top = `${_asteroid.top}px`
    asteroid.style.left = `${_asteroid.left}px`

    document.body.appendChild(asteroid);
    document.body.appendChild(ship);
    document.addEventListener("keydown", handleKeyboard.bind(undefined, ship, keysMap, actionsMap))

    requestAnimationFrame(
        animate.bind(undefined, ship, animateStars.bind(undefined, stars))
    );
}

main();