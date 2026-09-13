using System;
using System.Collections.Generic;
using System.Text;

namespace C__Student_Management_System
{
    internal class StudentManagement
    {
        private List<StudentInformation> _students = new List<StudentInformation>();

        public int kapasite { get;} = 20;

        public IReadOnlyList<StudentInformation> Persons => _students;
        
        public bool AddStudent(StudentInformation student)
        {
            if (_students.Count < kapasite)
            {
                _students.Add(student);
                Console.WriteLine("Student added successfully.");
               

                return true;
               
            }
            else
            {
                Console.WriteLine("Cannot add more students. Capacity reached.");
                return false;
            }
        }
        public bool RemoveStudent(StudentInformation student)
        {
            bool bulunduMu = false;
            if (_students.Count > 0)
            {
                for (int i = 0; i < _students.Count; i++)
                {
                    if (_students[i].Id == student.Id)
                    {
                        _students.RemoveAt(i);
                        Console.WriteLine("Student removed successfully.");
                        bulunduMu = true;
                        break;

                    }

                } 

            }
            else
            {
                
                Console.WriteLine("Student not found.");

            }
            return bulunduMu;
            
        }

    }
}

    
    