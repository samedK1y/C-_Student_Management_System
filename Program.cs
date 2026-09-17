using C__Student_Management_System;
using System;




namespace StudentManagementSystem
{

    class Program
    {
        

        static void Panel()
        {
            Console.WriteLine("----📋STUDENT MANAGEMENT📋----" +
                "\n====1)Add Student" +
                "\n====2)Delete Students" +
                "\n====3)View Students" +
                "\n====4)Search Students" +
                "\n====5)Update Student" +
                "\n====6)Add Note" +
                "\n====7)Student Statistics" +
                "\n====8)Exit\n");
        }

        static StudentManagement studentManagement = new StudentManagement();
        static void AddStudent()
        {
            bool basariliMi;
            string Vname, Vsurname, Vdepartment;
            GenderEnum genderParsed;
            ClassEnum classEnum;
            int ageParsed,
               idParsed,
               gradeParsed;
            while (true)
            {
                Console.WriteLine("\n● Gender(Male/Female) ?");
                var Vgender = Console.ReadLine();
                basariliMi = Enum.TryParse<GenderEnum>(Vgender,true,out  genderParsed);
                if(!basariliMi)
                {
                    Console.WriteLine("⚠️Please enter a valid gender (Male/Female ).");
                    continue;
                }
                break;
            }
            while (true) 
            {
                Console.WriteLine("\n● Name of the student to be added ?");
                Vname = Console.ReadLine();
                if (Vname is not  string && !string.IsNullOrWhiteSpace(Vname))
                {
                    Console.WriteLine("⚠️ Please do not enter an empty expression or one that is not a string");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("\n● Surname of the student to be added ?");
                Vsurname = Console.ReadLine();
                if (Vsurname is not string && !string.IsNullOrWhiteSpace(Vsurname))
                {
                    Console.WriteLine("⚠️ Please do not enter an empty expression or one that is not a string.\n");
                    continue;
                }
                break;

            }
            while (true)
            {
                Console.WriteLine("\n● Age of the student to be added ?");
                var Vage = Console.ReadLine();
                basariliMi = int.TryParse(Vage, out ageParsed);
                if(!basariliMi)
                {
                    Console.WriteLine("⚠️ Please enter a valid age.\n");
                    continue;
                }
                if (ageParsed < 16 || ageParsed > 65)
                {
                    Console.WriteLine("⚠️ Age must be between 16 and 65.\n");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("\n● Student ID ?");
                var VId = Console.ReadLine();
                basariliMi = int.TryParse(VId, out idParsed);
                if (!basariliMi)
                {
                    Console.WriteLine("⚠️ Please enter a valid student ID.\n");
                    continue;

                }
                break;

            }
            bool bulunduMu;
            while (true)
            {
                Console.WriteLine("\n● Which Class?(1,2,3,4)");
                var Vclass = Console.ReadLine();
                basariliMi = int.TryParse(Vclass, out gradeParsed);
                int newGradeParsed = gradeParsed - 1;
                if (!basariliMi)
                {
                    Console.WriteLine("Please enter a valid class.");
                    continue;
                }
                basariliMi = Enum.TryParse<ClassEnum>(newGradeParsed.ToString(), out  classEnum);
                bulunduMu = Enum.IsDefined(typeof(ClassEnum), classEnum);

                if (!basariliMi || !bulunduMu)
                {
                    Console.WriteLine("⚠️ Please enter a valid class (1,2,3,4).\n");
                    continue;
                }
                
                break;


            }
            while (true)
            {
                Console.WriteLine("\n● What is the department they are studying in?");
                 Vdepartment = Console.ReadLine();
                break;
            }

            StudentInformation student = new StudentInformation(idParsed, Vname, Vsurname, ageParsed, genderParsed, classEnum, Vdepartment);
             basariliMi = studentManagement.AddStudent(student);
            if(!basariliMi)
            {
                Console.WriteLine("⚠️ Failed to add student.\n");
            }
            else
            {
                student.DisplayStudentInfo();
                Console.WriteLine($" Remaining capacity: {studentManagement.kapasite - studentManagement.Persons.Count}" );
            }
        }

        static void DeleteStudent()
        {
            int idToDelete;
            ViewStudentId();
            while (true)
            {
                if (studentManagement.Persons.Count == 0)
                {
                    Console.WriteLine("⚠️ There are no students to delete.\n");
                    break;
                }
                Console.WriteLine("Enter the ID of the student you want to delete:");
                var inputId = Console.ReadLine();
                bool basariliMi = int.TryParse(inputId, out  idToDelete);
                if (!basariliMi || idToDelete < 0 || idToDelete > 9999)
                {
                    Console.WriteLine("⚠️ Please enter a valid student ID.(0-9999)\n");

                    continue;
                }
                else
                {
                   basariliMi = studentManagement.RemoveStudent(idToDelete);
                    if (!basariliMi)
                    {
                        Console.WriteLine("⚠️ Student not found. Please enter a valid student ID.\n");
                        break;
                    }
                }
                break;

            }
        }
        static void ViewStudentId()
        {
            Console.WriteLine("\n---Student List---\n");
            for (int i = 0;i < studentManagement.Persons.Count; i++)
            {
                Console.WriteLine($"-Name / Id: {studentManagement.Persons[i].Name} / {studentManagement.Persons[i].Id}\n");
            }
        }
        static void ViewStudents()
        {
            
            if (studentManagement.Persons.Count == 0)
            {
                Console.WriteLine("⚠️ There are no students to display.\n");
                return;
            }

            
            for (int i =0; i < studentManagement.Persons.Count; i++)
            {
                Console.WriteLine(
                    $"\n🧑‍🎓-----------\n" +
                    $"-Name:        {studentManagement.Persons[i].Name}\n" +
                    $"-Surname:     {studentManagement.Persons[i].Surname}\n" +
                    $"-Age:         {studentManagement.Persons[i].Age}\n" +
                    $"-Gender:      {studentManagement.Persons[i].Gender}\n" +
                    $"-Class:       {studentManagement.Persons[i]._Class}\n" +
                    $"-Department:  {studentManagement.Persons[i].Department}\n" +
                    $"-------------\n");
            }
        }

        static void SearchStudent()
        {
            ViewStudentId();
            if (studentManagement.Persons.Count == 0)
            {
                Console.WriteLine("⚠️ There are no students to display.\n");
                return;
            }
            int idToSearch;

            while (true)
            {
               
                Console.WriteLine("The ID number of the student you wish to search for?");
                var inputId = Console.ReadLine();
                bool basariliMi = int.TryParse(inputId, out idToSearch);
                if(!basariliMi)
                {
                    Console.WriteLine("⚠️ Please enter a valid student ID.(0-9999)\n");
                    break;
                }
                for (int i = 0; i <= studentManagement.Persons.Count; i++)
                {
                    if (studentManagement.Persons[i].Id == idToSearch)
                    {
                        Console.WriteLine("!Student found!");
                        ViewStudents();
                        break;

                    }
                    else
                    {
                        Console.WriteLine("⚠️ Student not found. Please enter a valid student ID.\n");
                        break;
                    }

                }
                break;
            }
             

        }

        static void UpdateStudent()
        {
            bool bulunuMu;
            ViewStudentId();
            if (studentManagement.Persons.Count == 0)
            {
                Console.WriteLine("⚠️ There are no students to display.\n");
                return;
            }
            int updateId;
            string updateIdInput;
            while (true)
            {
                Console.WriteLine("Enter the ID of the student you want to update:");
                 updateIdInput = Console.ReadLine();
                bool basariliMi = int.TryParse(updateIdInput, out  updateId);
                if (!basariliMi)
                {
                    Console.WriteLine("⚠️ Please enter a valid student ID.(0-9999)\n");
                    continue;
                }
                break;
                
            }
            
            for (int i = 0; i < studentManagement.Persons.Count; i++)
            {
                if (studentManagement.Persons[i].Id == updateId)
                {
                    Console.WriteLine("✅Student found. Please enter the updated information:");
                    while (true)
                    {
                        Console.WriteLine("Enter new Gender(Male/Female):");
                        var newGender = Console.ReadLine();
                        bool basarilimi = Enum.TryParse<GenderEnum>(newGender, true, out GenderEnum genderParsed);
                        if (!basarilimi)
                        {
                            Console.WriteLine("⚠️ Please enter a valid gender (Male/Female)");
                            continue;
                        }
                        studentManagement.Persons[i].Gender = genderParsed;
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("\n●Enter new Name:");
                        var newName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newName))
                        {
                            Console.WriteLine("⚠️ Please do not enter an empty expression or one that is not a string");
                            continue;
                        }
                        studentManagement.Persons[i].Name = newName;
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("\n●Enter new Surname:");
                        var newSurname = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newSurname))
                        {
                            Console.WriteLine("⚠️ Please do not enter an empty expression or one that is not a string");
                            continue;
                        }
                        studentManagement.Persons[i].Surname = newSurname;
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("\n●Enter new Age:");
                        var newAgeInput = Console.ReadLine();
                        bool basarilimi = int.TryParse(newAgeInput, out int newAge);
                        if (!basarilimi || newAge < 16 || newAge > 65)
                        {
                            Console.WriteLine("⚠️ Please enter a valid age between 16 and 65.");
                            continue;
                        }
                        studentManagement.Persons[i].Age = newAge;
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("\n●Enter new Class(1,2,3,4):");
                        var newClassInput = Console.ReadLine();
                        bool basariliMi = int.TryParse(newClassInput, out int newClassParsed);
                        if (!basariliMi)
                        {
                            Console.WriteLine("⚠️ Please enter a valid class.");
                            continue;

                        }
                        basariliMi = Enum.TryParse<ClassEnum>((newClassParsed - 1).ToString(), out ClassEnum classEnum);
                        bulunuMu = Enum.IsDefined(typeof(ClassEnum), classEnum);
                        if (!basariliMi || !bulunuMu)
                        {
                            Console.WriteLine("⚠️ Please enter a valid class (1,2,3,4).");
                            continue;
                        }
                        studentManagement.Persons[i]._Class = classEnum;
                        break;
                    }
                    while (true)
                    {
                        Console.WriteLine("\n●Enter new Department:");
                        var newDepartment = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newDepartment))
                        {
                            Console.WriteLine("⚠️ Please do not enter an empty expression or one that is not a string");
                            continue;
                        }
                        studentManagement.Persons[i].Department = newDepartment;
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            int secimInt;
            bool basariliMi;

            do
            {
                Panel();
                 var secim = Console.ReadLine();
                basariliMi = int.TryParse(secim, out  secimInt);
                if (!basariliMi)
                {
                    Console.WriteLine("\n⚠️Invalid selection. Please enter a value within the specified range.\n");
                    continue;
                }
                switch (secimInt)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DeleteStudent(); 
                        break;
                    case 3:
                        ViewStudents();
                        break;
                    case 4:
                        SearchStudent();
                        break;
                    case 5:
                        UpdateStudent();
                        break;
                    case 8:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("⚠️Invalid selection. Please try again.\n");
                        break;
                }
            }while (secimInt != 8);
            
        }
    }
} 