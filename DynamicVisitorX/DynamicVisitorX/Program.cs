using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace DynamicVisitorX
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dynamic Visitor Pattern");

            var person = new Person
            {
                FirstName = "Albert",
                LastName = "Einstein",
            };

            person.Friends.Add(
                new Employee
                {
                    FirstName = "Bill",
                    LastName = "Gates",
                    Salary = 5000
                });

            person.Friends.Add(
                new Customer
                {
                    FirstName = "Sally",
                    LastName = "Rides",
                    CreditLimit = 1
                });

            person.Friends.Add(
                new Employee
                {
                    FirstName = "Melinda",
                    LastName = "Gates",
                    Salary = 5000
                });

            Console.WriteLine(new ToXElementPersonVisitor().DynamicVisit(person));

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public readonly IList<Person> Friends = new Collection<Person>();
    }

    class Customer : Person
    {
        public decimal CreditLimit { get; set; }
    }

    class Employee : Person
    {
        public decimal Salary { get; set; }
    }

    class ToXElementPersonVisitor
    {
        public XElement DynamicVisit(Person p) => Visit((dynamic)p);

        XElement Visit(Person p)
        {
            return new XElement("Person",
                new XAttribute("Type", p.GetType().Name),
                new XAttribute("FirstName", p.FirstName),
                new XAttribute("LastName", p.LastName),
            p.Friends.Select(f => DynamicVisit(f)));
        }

        XElement Visit(Customer c) // Specialized logic for customers
        {
            XElement xe = Visit((Person)c); // Call "base" method
            xe.Add(new XElement("CreditLimit", c.CreditLimit));
            return xe;
        }

        XElement Visit(Employee e) // Specialized logic employees
        {
            XElement xe = Visit((Person)e); // Call "Base" method
            xe.Add(new XElement("Salary", e.Salary));
            return xe;
        }
    }
}