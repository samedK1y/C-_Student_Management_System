using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace C__Student_Management_System
{
    internal class StudentInformation
    {

        private int _id;
        private GenderEnum _gender;
        private int _age;
        private ClassEnum _class;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value > 0)
                {
                    _id = value;

                }
                else
                {
                    Console.WriteLine("Id must be greater than 0. A random Id will be generated.");
                    Random random = new Random();
                    _id = random.Next(1, 1000);

                }
            }

        }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Age
        {
            get { return _age; }

            set
            {
                if (value > 15 && value < 150)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("⚠️Age must be between 16 and 149. A random age will be generated.");

                    _age = 1;
                }
            }
        }
        public GenderEnum Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public ClassEnum _Class
        {
            get { return _class; }
            set { _class = value; }
        }

        public string Department { get; set; }

        public int StudentGrades { get; set; }


        public StudentInformation(int id, string name, string surname, int age, GenderEnum gender, ClassEnum _class, string department)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            _Class = _class;
            Department = department;

        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"\n-----------------------------");
            Console.WriteLine($"Id      : {Id}");
            Console.WriteLine($"Name    : {Name}");
            Console.WriteLine($"Surname : {Surname}");
            Console.WriteLine($"Age     : {Age}");
            Console.WriteLine($"Gender  : {Gender}");
            Console.WriteLine($"Class   : {_Class}");
            Console.WriteLine($"-----------------------------\n");

        }
    }
}
