using System;
using System.Collections.Generic;

namespace test_dp_adapter
    {
    class Program
        {
        static void Main(string[] args)
            {
            List<IEmployee> list = new List<IEmployee>();
            list.Add(new Employee("Tom"));
            list.Add(new Employee("Jerry"));
            list.Add(new ConsultantToEmployeeAdapter("Bruno"));  //consultant from existing class

            foreach (IEmployee i in list) i.ShowHappiness();

            Console.WriteLine("Hello World! 3"); 
            }


        //from the existing library, does not need to be changed
        public interface IEmployee
            {
            void ShowHappiness();
            }

        public class Employee : IEmployee
            {
            private string name;
            public Employee(string name) { this.name = name; }
            void IEmployee.ShowHappiness() { Console.WriteLine("Employee " + this.name + " showed happiness"); }
            }

        //existing class does not need to be changed
        public class Consultant
            {
            private string name;
            public Consultant(string name) { this.name = name; }
            protected void ShowSmile() { Console.WriteLine("Consultant " + this.name + " showed smile"); }
            }
        // adapter
        public class ConsultantToEmployeeAdapter : Consultant, IEmployee
            {
            public ConsultantToEmployeeAdapter(string name) : base(name)
                {
                }
            void IEmployee.ShowHappiness()
                {
                base.ShowSmile();  //call the parent Consultant class
                }
            }
        }
    }
