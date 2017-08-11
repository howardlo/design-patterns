using System;
using System.Collections.Generic;


//
// From: https://www.codeproject.com/articles/186185/visitor-design-pattern
//

namespace VisitorDesignPatternX
{
    class Program
    {
        static void Main(string[] args)
        {
            //first set up the structure
            List<IElement> list = new List<IElement> ();
            list.Add(new Household("The Adams Family"));
            list.Add(new Household("The Jones Family"));
            list.Add(new BusinessEntity("The Oatmeal Bakery"));
            list.Add(new BusinessEntity("The Ice Cream Shop"));

            //use one visitor, or logic
            IVisitor visitor = new SantaClaus();
            foreach (IElement i in list)
                i.Accept(visitor);   //apply the logic to the element

            //use another visitor, or logic
            visitor = new MailCarrier();
            foreach (IElement i in list)
                i.Accept(visitor);  //apply the logic to the element


            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }

    public interface IElement
    {
        string Name { get; set; }
        void Accept(IVisitor v);
    }

    public class Household : IElement
    {
        private string name;

        string IElement.Name
        {
            get { return name; }
            set { name = value; }
        }

        public Household(string name)
        {
            this.name = name;
        }

        void IElement.Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }

    public class BusinessEntity : IElement
    {
        private string name;

        string IElement.Name
        {
            get { return name; }
            set { name = value; }
        }

        public BusinessEntity(string name)
        {
            this.name = name;
        }

        void IElement.Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }

    public interface IVisitor
    {
        void Visit(IElement e);
    }

    public class SantaClaus : IVisitor
    {
        void IVisitor.Visit(IElement v)
        {
            Console.WriteLine("Santa visited " + v.Name);
        }
    }

    public class MailCarrier : IVisitor
    {
        void IVisitor.Visit(IElement v)
        {
            Console.WriteLine("MailCarrier visited " + v.Name);
        }
    }
}