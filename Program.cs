using System;
using System.Text.Json;

namespace JSON__de_serialization
{
    class Program
    {

        static string jsonPath = @"C:\Users\1.1-PC\Dot Net\.NET\C#\JSON (de)serialization\JSON (de)serialization\jsonPractice.txt";
        static int compenyTuition = 10000;
        public static void Main(string[] args)
        {
            string UserInput = "";
            Console.Clear();
            ConsoleKeyInfo input;
            Desrializer();

            do
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(@"Choose an option from foolowing list:
                               a - Add
                               r - Remove
                               p - Print
                               f - Fee
                               c - Clear
                               q - Quit
                            Your option?");
                UserInput = Convert.ToString(Console.ReadLine().ToLower().Trim());
                input = Console.ReadKey();
                

                switch (UserInput)
                {
                    case "a": 
                        Console.WriteLine("Enter the student name to add:");
                        string nameInputAdd = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Enter student age to add:");
                        int ageInputAdd = Convert.ToInt32(Console.ReadLine());

                        student newStudent = new student(nameInputAdd, ageInputAdd);

                        List<student> studentsList = Desrializer();
                        studentsList.Add(newStudent);

                        Console.WriteLine("----------------------");
                        Console.WriteLine($"The student: 'Name - {nameInputAdd}, Age - {ageInputAdd}' addad successfully.");

                        Serializer(studentsList);

                        break;
                    case "r":
                        studentsList = Desrializer();
                        bool removed = false;

                        Console.WriteLine("Enter the Name of student to remove:");
                        string inputNameToRemove = Convert.ToString(Console.ReadLine());
                        foreach (student student in studentsList)
                            if (student.Name == inputNameToRemove)
                            {
                                studentsList.Remove(student);
                                removed = true;
                                Console.WriteLine("----------------------");
                                Console.WriteLine($"The Name {student.Name} has been removed");
                                break;
                            }
                       if (removed == false)
                        {
                            Console.WriteLine("----------------------");
                            Console.WriteLine($"The Name {inputNameToRemove} is NOT in the students List");
                        }
                        

                        Serializer(studentsList);

                        break;
                    case "p":
                        studentsList = Desrializer();
                        Console.WriteLine("----------------------");
                        Console.WriteLine("The students List is:");
                        PrintList(studentsList);
                        break;
                    case "f":
                        studentsList = Desrializer();

                        foreach (student Student in studentsList)
                            if (Student.Age < 25)
                            {
                                Console.WriteLine($"\t{Student} {compenyTuition*0.75}");
                            }
                            else
                            {
                                Console.WriteLine($"\t{Student}  {compenyTuition}");
                            }

                        break;
                    case "c":
                        studentsList = Desrializer();

                        studentsList.Clear();
                        Console.WriteLine("The students List is clean");
                        break;
                    case "q": //End of program
                        break;

                    default:
                        Console.WriteLine("No parameter entered");
                        break;
                }
            } while (!UserInput.Equals("q"));

            Console.WriteLine("------------------");
            Console.WriteLine("The program ended successfully, thank you for using our software.");
            Console.WriteLine("------------------");
        }
        public static void PrintList(List<student> studentsList)
        {
            foreach (var Student in studentsList)
                Console.WriteLine($"\t{Student}");
            Console.WriteLine();
        }
        //

        public static List<student> Desrializer()
        {
            string JsonToList = File.ReadAllText(jsonPath);
            List<student> studentsList = JsonSerializer.Deserialize<List<student>>(JsonToList);
            Console.WriteLine("----------------------");
            Console.WriteLine($"The Json file was successfully uploaded to the list\n");

            return studentsList;
        }
        
        //

        public static void Serializer(List<student> studentsList)
        {
            string ListToJson = JsonSerializer.Serialize(studentsList);
            File.WriteAllText(jsonPath, ListToJson);
            Console.WriteLine("----------------------");
            Console.WriteLine($"\nThe list was successfully converted to JSON in the file.");
        }
    }
}

