using System;

public class Person
{
    string title;
	public Person(string title)
	{
        this.title = title;
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string sendMessage()
    {
        Console.WriteLine($"{title} sent message:");
        string message = Console.ReadLine();
        return message;
    }

    public bool recieveMessage(string message)
    {
        if(message != "" || message != null)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
