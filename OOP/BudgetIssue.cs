using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budgetIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthDays = int.Parse(Console.ReadLine());
            double moneyForADay = double.Parse(Console.ReadLine());
            double lv = double.Parse(Console.ReadLine());

            double moneyForMonth = 0;
            double moneyForYear = 0;
            double bonus = 0;
            double danuci = 0;

            for(var i = 1; i < monthDays; i++)
            {
                moneyForMonth += moneyForADay;
            }
            moneyForYear = moneyForMonth * 12;
            danuci = moneyForYear * 0.25;
            for(var i = 1; i <= 365; i++)
            {

                if(i == 365)
                {
                    bonus = moneyForMonth * 2.5;
                }
            }
        }
    }
}
