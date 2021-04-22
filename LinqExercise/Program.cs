using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine("Sum and Average");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());
            Console.WriteLine("");

            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("Ascending Order");
            var ascending = numbers.OrderBy(x => x);
               foreach (var x in ascending)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("");

            Console.WriteLine("Decsending Order");
            var decsending = numbers.OrderByDescending(x => x);
            foreach (var x in decsending)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("");

            //Print to the console only the numbers greater than 6
            Console.WriteLine("Greater Than 6");
            var greater6 = numbers.Where(x => x > 6);
            foreach (var x in greater6)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Only 4 Numbers");
            var only4 = numbers.Take(4).OrderBy(x => x);

            foreach (var x in only4)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("");



            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Add My Age to the List");
            numbers.SetValue(40, 4);
            var myAge = numbers.OrderByDescending(x => x);
            foreach (var num in myAge)
            {
                Console.WriteLine(num);
            }
            

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("First Name of Employees That Start With S or C");
            var firstName = employees.Where(x => x.FirstName.Contains("C") || x.FirstName.Contains("S")).OrderBy(x => x.FirstName);

            var firstName2 = employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S")).OrderBy(x => x.FirstName);
            //var firstName = employees.Where(x => x.FirstName.Contains("C")).OrderBy(x => x.FirstName);
            //var fName2 = employees.Where(x => x.FirstName.Contains("S")).OrderBy(x => x.FirstName);

            foreach (var x in firstName)
            {
                Console.WriteLine(x.FullName);
            }

            //foreach (var x in fName2)
            //{
            //    Console.WriteLine(x.FullName);
            //}
            Console.WriteLine("");


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees Older Than 26");
            var oldHeads = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var x in oldHeads)
            {
                Console.WriteLine($"Name: {x.FirstName}  Age: {x.Age}");      
            }
            Console.WriteLine("");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("Sum and Average of YOE for Employeses Older Than 35");
            var yearOfExp = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sum = 0.0;
            foreach (var x in yearOfExp)
            {
                sum += x.YearsOfExperience;
            }

            var average = (sum / yearOfExp.Count());

            Console.WriteLine(sum);
            Console.WriteLine(average);
            Console.WriteLine("");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Dominick", "Dougherty", 40, 1)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FullName);
            }
          

                
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
