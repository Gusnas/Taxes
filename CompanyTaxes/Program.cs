using System;
using System.Collections.Generic;
using System.Globalization;
using CompanyTaxes.Entities;

namespace CompanyTaxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n; i++)
            {
                Console.WriteLine("Tax payer #" + i + " data:");

                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Anual income: ");
                double income = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                if(type == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double health = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    list.Add(new Individual(name,income,health));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int employees = int.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    list.Add(new Company(name, income, employees));
                }
            }
            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");

            double sum = 0;
            foreach(TaxPayer tp in list)
            {
                Console.WriteLine(tp.Name + " : $ " + tp.Tax().ToString("F2",CultureInfo.InvariantCulture));
                sum += tp.Tax();
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $" + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
