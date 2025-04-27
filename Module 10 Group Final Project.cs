using System;
using System.Collections.Generic;

enum ShiftType { Day = 1, Night = 2 }

class Contractor
{
    public string Name { get; set; }
    public int Number { get; set; }
    public DateTime StartDate { get; set; }

    public Contractor() {}

    public Contractor(string name, int number, DateTime startDate)
    {
        Name = name;
        Number = number;
        StartDate = startDate;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Number: {Number}, Start Date: {StartDate.ToShortDateString()}";
    }
}

class Subcontractor : Contractor
{
    public ShiftType Shift { get; set; }
    public double HourlyPayRate { get; set; }

    public Subcontractor() {}

    public Subcontractor(string name, int number, DateTime startDate, ShiftType shift, double hourlyPayRate)
        : base(name, number, startDate)
    {
        Shift = shift;
        HourlyPayRate = hourlyPayRate;
    }

    public float CalculatePay(float hoursWorked)
    {
        double rate = HourlyPayRate;
        if (Shift == ShiftType.Night)
        {
            rate *= 1.03; // 3% differential
        }
        return (float)(rate * hoursWorked);
    }

    public override string ToString()
    {
        return base.ToString() + $", Shift: {Shift}, Hourly Rate: ${HourlyPayRate:F2}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Subcontractor> subcontractors = new List<Subcontractor>();
        float totalPayroll = 0;
        string continueInput;

        Console.WriteLine("Subcontractor Entry System");

        do
        {
            Console.Write("\nEnter Contractor Name: ");
            string name = Console.ReadLine();

            int number;
            while (true)
            {
                Console.Write("Enter Contractor Number: ");
                if (int.TryParse(Console.ReadLine(), out number)) break;
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            DateTime startDate;
            while (true)
            {
                Console.Write("Enter Start Date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out startDate)) break;
                Console.WriteLine("Invalid date format.");
            }

            int shiftInput;
            while (true)
            {
                Console.Write("Enter Shift (1 = Day, 2 = Night): ");
                if (int.TryParse(Console.ReadLine(), out shiftInput) &&
                    (shiftInput == 1 || shiftInput == 2)) break;
                Console.WriteLine("Invalid shift. Enter 1 for Day or 2 for Night.");
            }
            ShiftType shift = (ShiftType)shiftInput;

            double rate;
            while (true)
            {
                Console.Write("Enter Hourly Pay Rate: ");
                if (double.TryParse(Console.ReadLine(), out rate)) break;
                Console.WriteLine("Invalid input. Please enter a decimal number.");
            }

            Subcontractor s = new Subcontractor(name, number, startDate, shift, rate);
            subcontractors.Add(s);

            float hours;
            while (true)
            {
                Console.Write("Enter hours worked: ");
                if (float.TryParse(Console.ReadLine(), out hours)) break;
                Console.WriteLine("Invalid input. Please enter a decimal number.");
            }

            float pay = s.CalculatePay(hours);
            totalPayroll += pay;

            Console.WriteLine("\nSubcontractor Info:");
            Console.WriteLine(s);
            Console.WriteLine($"Calculated Pay: ${pay:F2}");

            Console.Write("\nWould you like to enter another subcontractor? (y/n): ");
            continueInput = Console.ReadLine();

        } while (continueInput.ToLower() == "y");

        // Display summary
        Console.WriteLine("\n--- Subcontractor Summary ---");
        foreach (var s in subcontractors)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine($"Total Payroll: ${totalPayroll:F2}");
        Console.WriteLine("\nProgram Ended.");
    }
}

