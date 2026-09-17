using C__Student_Management_System;
using System;



/** 
 
 They will be fixed:

1) UpdateStudent methodunu student managment kısmında yap ve encapsulationa uyması adına.
2)Add student çok dolu olduğundan ayrı methodtlar açılacak GetValidText , GetValidInt, GetValidEnum gibi.Daha sonra addstudentte birleştirlecek
  GetValidText(string prompt)
        {
             while(true)
             {
                 Console.WriteLine(prompt);
                 var input = Console.ReadLine();
                 if(string.IsNullOrWhiteSpace(input))
                 {
                     Console.WriteLine("⚠️ Please do not enter an empty expression or one that is not a string");
                     continue;
                 }
                 return input;
             }       
        }
3)ID çakışımına çözüm bul.
4)isnotstringi kullanma!!

 
 
 
 
 **/
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
            bool isSuccesful;
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
                isSuccesful = Enum.TryParse<GenderEnum>(Vgender,true,out  genderParsed);
                if(!isSuccesful)
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
                isSuccesful = int.TryParse(Vage, out ageParsed);
                if(!isSuccesful)
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
                isSuccesful = int.TryParse(VId, out idParsed);
                if (!isSuccesful)
                {
                    Console.WriteLine("⚠️ Please enter a valid student ID.\n");
                    continue;

                }
                break;

            }
            bool isFound;
            while (true)
            {
                Console.WriteLine("\n● Which Class?(1,2,3,4)");
                var Vclass = Console.ReadLine();
                isSuccesful = int.TryParse(Vclass, out gradeParsed);
                int newGradeParsed = gradeParsed - 1;
                if (!isSuccesful)
                {
                    Console.WriteLine("Please enter a valid class.");
                    continue;
                }
                isSuccesful = Enum.TryParse<ClassEnum>(newGradeParsed.ToString(), out  classEnum);
                isFound = Enum.IsDefined(typeof(ClassEnum), classEnum);

                if (!isSuccesful || !isFound)
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
                if (Vdepartment is not string && !string.IsNullOrWhiteSpace(Vdepartment))
                {
                    Console.WriteLine("⚠️ Please do not enter an empty expression or one that is not a string.\n");
                    continue;
                }
                break;
            }

            StudentInformation student = new StudentInformation(idParsed, Vname, Vsurname, ageParsed, genderParsed, classEnum, Vdepartment);
             isSuccesful = studentManagement.AddStudent(student);
            if(!isSuccesful)
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
                bool isSuccesful = int.TryParse(inputId, out  idToDelete);
                if (!isSuccesful || idToDelete < 0 || idToDelete > 9999)
                {
                    Console.WriteLine("⚠️ Please enter a valid student ID.(0-9999)\n");

                    continue;
                }
                else
                {
                   isSuccesful = studentManagement.RemoveStudent(idToDelete);
                    if (!isSuccesful)
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
            bool isFound = false;
            while (true)
            {
               
                Console.WriteLine("The ID number of the student you wish to search for?");
                var inputId = Console.ReadLine();
                bool isSuccesful = int.TryParse(inputId, out idToSearch);
                if(!isSuccesful)
                {
                    Console.WriteLine("⚠️ Please enter a valid student ID.(0-9999)\n");
                    break;
                }
                for (int i = 0; i < studentManagement.Persons.Count; i++)
                {
                    if (studentManagement.Persons[i].Id == idToSearch)
                    {
                        Console.WriteLine("!Student found!");
                        ViewStudents();
                        isFound = true;
                        break;

                    }

                }
                if (!isFound)
                {
                    Console.WriteLine("⚠️ Student not found. Please enter a valid student ID.\n");
                    continue;
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
                bool isSuccesful = int.TryParse(updateIdInput, out  updateId);
                if (!isSuccesful)
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
                        bool isSuccesful = Enum.TryParse<GenderEnum>(newGender, true, out GenderEnum genderParsed);
                        if (!isSuccesful)
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
                        bool isSuccesful = int.TryParse(newAgeInput, out int newAge);
                        if (!isSuccesful || newAge < 16 || newAge > 65)
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
                        bool isSuccesful = int.TryParse(newClassInput, out int newClassParsed);
                        if (!isSuccesful)
                        {
                            Console.WriteLine("⚠️ Please enter a valid class.");
                            continue;

                        }
                        isSuccesful = Enum.TryParse<ClassEnum>((newClassParsed - 1).ToString(), out ClassEnum classEnum);
                        bulunuMu = Enum.IsDefined(typeof(ClassEnum), classEnum);
                        if (!isSuccesful || !bulunuMu)
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
            bool isSuccesful;

            do
            {
                Panel();
                 var secim = Console.ReadLine();
                isSuccesful = int.TryParse(secim, out  secimInt);
                if (!isSuccesful)
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