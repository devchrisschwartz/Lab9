using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();
            #region ExistingStudents
            Student student1 = new Student
            {
                Name = "Chuck Buckwheat",
                Hometown = "Springfield, USA",
                FavoriteFood = "Chicken",
                Hobby = "reading mystery novels"
            };
            Student student2 = new Student
            {
                Name = "Rip Steakflank",
                Hometown = "Beefdip City, Florida",
                FavoriteFood = "Fish eyes",
                Hobby = "baking confectionaries"
            };
            Student student3 = new Student
            {
                Name = "Kristal Clear",
                Hometown = "Walla Walla, Washington",
                FavoriteFood = "Pop Rocks",
                Hobby = "painting"
            };
            Student student4 = new Student
            {
                Name = "Big McLargeHuge",
                Hometown = "Whoville",
                FavoriteFood = "Salted meat sticks",
                Hobby = "making miniature ships inside bottles"
            };
            Student student5 = new Student
            {
                Name = "Legolas Runsfast",
                Hometown = "that elf village in the woods outside of town. You know the one.",
                FavoriteFood = "Bread. Lots of bread",
                Hobby = "comparing orc killstreaks with dwarves"
            };
            Student student6 = new Student
            {
                Name = "Mary Christmas",
                Hometown = "the North Pole",
                FavoriteFood = "Waffles",
                Hobby = "winemaking"
            };
            Student student7 = new Student
            {
                Name = "Dirk Hardpec",
                Hometown = "Bollywood, CA",
                FavoriteFood = "Protein Cakes",
                Hobby = "ping pong"
            };
            Student student8 = new Student
            {
                Name = "Butch Deadlift",
                Hometown = "Biceps, NY",
                FavoriteFood = "Horse meat",
                Hobby = "working out"
            };
            Student student9 = new Student
            {
                Name = "Anita Mann",
                Hometown = "San Francisco, CA",
                FavoriteFood = "S'ghetti",
                Hobby = "blogging about men"
            };
            Student student10 = new Student
            {
                Name = "Buff Drinklots",
                Hometown = "Triceps, NY",
                FavoriteFood = "Fermented cabbage",
                Hobby = "bird watching"
            };
            Student student11 = new Student
            {
                Name = "Gristle McThornbody",
                Hometown = "Sydney, Australia",
                FavoriteFood = "Raw eggs",
                Hobby = "camping"
            };
            Student student12 = new Student
            {
                Name = "Flint Ironstag",
                Hometown = "Mount Hyjal, Kalimdor",
                FavoriteFood = "Bear tartare",
                Hobby = "hunting"
            };
            Student student13 = new Student
            {
                Name = "Buck Plankchest",
                Hometown = "Mount Olympus, Greece",
                FavoriteFood = "Kangaroo",
                Hobby = "carpentry"
            };
            Student student14 = new Student
            {
                Name = "Slab Manmuscle",
                Hometown = "the planet Mars",
                FavoriteFood = "Alligator",
                Hobby = "gardening"
            };
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);
            students.Add(student6);
            students.Add(student7);
            students.Add(student8);
            students.Add(student9);
            students.Add(student10);
            students.Add(student11);
            students.Add(student12);
            students.Add(student13);
            students.Add(student14);
            #endregion

            Console.Write("Welcome to the fantastical C# class! ");

            string continueChoice = "y";

            while (continueChoice.ToLower() == "y" || continueChoice.ToLower() == "yes")
            {
                string userChoice = GetValidInput(@"^[cC][hH][eE][cC][kK]$|^[aA][dD][dD]$", "Would you like to check the information of a student, or add a student? (Please enter \"check\" or \"add\")",
                    "That choice isn't an option, please enter \"check\" or \"add\".", "That choice isn't an option, please enter \"check\" or \"add\".");
                if (Regex.IsMatch(userChoice, @"^[aA][dD][dD]$"))
                {
                    Student temp = new Student();
                    temp.Name = GetValidInput(@"^[a-zA-Z]{1,20} [a-zA-Z]{1,20}$", "Please enter the student's first and last name separated by a space.",
                        "Sorry, that is not a valid name. Please enter a first and last name separated by a space.", "Sorry, that is not a valid name. Please enter a first and last name separated by a space.");
                    temp.Hometown = GetValidInput(@"^[a-zA-Z ,.0-9]{1,40}$", $"Please enter {temp.Name}'s hometown.",
                        "Sorry, you either put nothing or too long of a hometown, try again!", "Null value not allowed! Try entering a hometown.");
                    temp.FavoriteFood = GetValidInput(@"^[a-zA-Z ]{1,20}$", $"Please enter their favorite food", "Sorry, not a valid input. Please enter a favorite food.", "Null value not allowed, please enter a favorite food.");
                    temp.Hobby = GetValidInput(@"^[a-zA-Z ,'.0-9]{1,30}$", "Please enter the student's hobby.", "Sorry, you entered an invalid character or the hobby was too long.", "Null value? Please enter a hobby.");

                    students.Add(temp);

                    continueChoice = GetValidInput(@"^[y]$|^[yY][eE][sS]$|^[nN]$|^[nN][oO]$", "Would you like to add another student or check the info on one of the current students? (Y/N): ", "Sorry, please enter Y/N", "Sorry, please enter Y/N");
                }
                else
                {
                    int studentNumber = StudentNumberInput(students.Count, students);
                    StudentInfo(studentNumber, students);
                    continueChoice = GetValidInput(@"^[y]$|^[yY][eE][sS]$|^[nN]$|^[nN][oO]$", "Would you like to add a student or check the info on one of the other students? (Y/N): ", "Sorry, please enter Y/N", "Sorry, please enter Y/N");
                }
            }

            Console.WriteLine("Thanks for your time, check back next lab for additional info.");
            Console.ReadKey();
        }

        // Takes user input and checks if null, then checks if it matches the given regex pattern, then returns the input as a string if it passes both, otherwise asks user for input again.
        public static string GetValidInput(string pattern, string userMessage, string errorMessage, string nullMessage)
        {
            Console.WriteLine(userMessage);
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine(nullMessage);
                }
                else if (!Regex.IsMatch(userInput, pattern))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return userInput;
                }
            }
        }

        public static int StudentNumberInput(int listCount, List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i+1}: {students[i].Name}");
            }

            int studentNumber = int.Parse(GetValidInput(@"^\d{1,3}$", $"Which student would you like to learn more about? (Enter a number 1-{listCount}): ",
                $"Sorry, that student does not exist. Please enter a valid number (1-{listCount}): ", $"A null value is not allowed! Please enter a number between 1 and {listCount}: "));

            while (true)
            {
                if (studentNumber >= 1 && studentNumber <= listCount)
                {
                    return studentNumber;
                }
                else
                {
                    studentNumber = int.Parse(GetValidInput(@"^\d{1,3}$", $"Sorry, your input is not within range. Which student would you like to learn more about? (Enter a number 1-{listCount}): ",
                $"Sorry, that student does not exist. Please enter a valid number (1-{listCount}): ", $"A null value is not allowed! Please enter a number between 1 and {listCount}: "));
                }
            }
        }

        public static void StudentInfo(int studentNumber, List<Student> students)
        {
            string knowMore = "y";
            while (Regex.IsMatch(knowMore, @"^[yY]$|^[yY][eE][sS]$"))
            {
                #region userChoice
                string userFactChoice = GetValidInput(@"^[hH][oO][mM][eE][tT][oO][wW][nN]$|^[fF][aA][vV][oO][rR][iI][tT][eE] [fF][oO][oO][dD]$|^[hH][oO][bB][bB][yY]$",
                $"#{studentNumber} is {students[studentNumber - 1].Name}. What would you like to know about? (enter \"hometown\", \"favorite food\", or \"hobby\"): ",
                "That choice is not an option. Please choose a valid data, either \"hometown\", \"favorite food\", or \"hobby\".",
                "A null value huh? Nice try Drew. Enter \"hometown\", \"favorite food\", or \"hobby\".");
                #endregion

                if (Regex.IsMatch(userFactChoice, @"^[hH][oO][mM][eE][tT][oO][wW][nN]$"))
                {
                    Console.WriteLine($"{students[studentNumber-1].Name}'s hometown is {students[studentNumber - 1].Hometown}.");
                }
                else if (Regex.IsMatch(userFactChoice, @"^[hH][oO][bB][bB][yY]$"))
                {
                    Console.WriteLine($"{students[studentNumber - 1].Name}'s hobby is {students[studentNumber - 1].Hobby}");
                }
                else
                {
                    Console.WriteLine($"{students[studentNumber - 1].Name}'s favorite food is {students[studentNumber - 1].FavoriteFood}.");
                }
                knowMore = GetValidInput(@"^[yY]$|^[yY][eE][sS]$|^[nN]$|^[nN][oO]$", "Would you like to know more about this student? (enter yes or no): ",
                    "That wasn't a yes or no, so I'm unsure what you want. Please enter yes or no: ",
                    "That wasn't a yes or no, so I'm unsure what you want. Please enter yes or no: ");
            }



        }
    }
}
