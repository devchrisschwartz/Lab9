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

            #region ListsAndArrays
            string[] studentNames = {"Chuck Buckwheat", "Rip Steakflank", "Kristal Clear", "Big McLargeHuge", "Legolas Runsfast", "Mary Christmas", "Dirk Hardpec", "Butch Deadlift", "Anita Mann", "Buff Drinklots",
                "Gristle McThornbody", "Flint Ironstag", "Buck Plankchest", "Slab Manmuscle"};
            string[] studentHometowns = {"Springfield, USA", "Beefdip City, Florida", "Walla Walla, Washington", "Whoville", "that elf village in the woods outside of town. You know the one",
                "the North Pole", "Bollywood, CA", "Biceps, NY", "San Francisco, CA", "Triceps, NY", "Sydney, Australia", "Mount Hyjal, Kalimdor", "Mount Olympus, Greece", "on the planet Mars"};
            string[] studentFavoriteFoods = {"Chicken Beaks", "Tuna Eyeballs", "Pop Rocks", "Salted meat sticks", "Bread. Lots of bread", "Waffles", "Protein Cakes", "Horse Meat",
                "S'ghetti", "Fermented Cabbage", "Raw Eggs", "Mayonnaise Crackers", "Kangaroo Meat", "Alligator Meat"};

            // Perform index of a ' ' char, sort starting from the next char.

            // Candy Kane, Jenn Italia,

            List<string> studentNamesList = new List<string>();
            studentNamesList.AddRange(studentNames);

            List<string> studentHometownsList = new List<string>();
            studentHometownsList.AddRange(studentHometowns);

            List<string> studentFavoriteFoodsList = new List<string>();
            studentFavoriteFoodsList.AddRange(studentFavoriteFoods);

            #region studentHobbies
            List<string> studentHobbies = new List<string>();
            studentHobbies.Add("Reading mystery novels");
            studentHobbies.Add("Baking confectionaries");
            studentHobbies.Add("Painting");
            studentHobbies.Add("Miniature models in ships");
            studentHobbies.Add("Comparing killstreaks with dwarves");
            studentHobbies.Add("Winemaking");
            studentHobbies.Add("Ping pong");
            studentHobbies.Add("Working out");
            studentHobbies.Add("Blogging about food");
            studentHobbies.Add("Bird watching");
            studentHobbies.Add("Camping");
            studentHobbies.Add("Hunting");
            studentHobbies.Add("Carpentry");
            studentHobbies.Add("Gardening");
            #endregion
            #endregion

            string continueChoice = "y";

            while (continueChoice.ToLower() == "y" || continueChoice.ToLower() == "yes")
            {
                string userChoice = GetValidInput(@"^[cC][hH][eE][cC][kK]$|^[aA][dD][dD]$", "Welcome to the fantastical C# class! Would you like to check the information of some of the students, or add a student? (Please enter \"check\" or \"add\")",
                    "That choice isn't an option, please enter \"check\" or \"add\".", "That choice isn't an option, please enter \"check\" or \"add\".");
                if (Regex.IsMatch(userChoice, @"^[aA][dD][dD]$"))
                {
                    studentNamesList.Add(GetValidInput(@"^[a-zA-Z]{1,20} [a-zA-Z]{1,20}$", "Please enter the student's first and last name separated by a space.",
                        "Sorry, that is not a valid name. Please enter a first and last name separated by a space.", "Sorry, that is not a valid name. Please enter a first and last name separated by a space."));
                    studentHometownsList.Add(GetValidInput(@"^[a-zA-Z ,.0-9]{1,40}$", $"Please enter {studentNamesList[studentNamesList.Count - 1]}'s hometown.",
                        "Sorry, you either put nothing or too long of a hometown, try again!", "Null value not allowed! Try entering a hometown."));
                    studentFavoriteFoodsList.Add(GetValidInput(@"^[a-zA-Z ]{1,20}$", $"Please enter their favorite food", "Sorry, please enter a favorite food.", "Null value not allowed, please enter a favorite food."));
                    studentHobbies.Add(GetValidInput(@"^[a-zA-Z ,'.0-9]{1,30}$", "Please enter the student's hobby.", "Sorry, you entered an invalid character or the hobby was too long.", "Null value? Please enter a hobby."));
                    continueChoice = GetValidInput(@"^[y]$|^[yY][eE][sS]$|^[nN]$|^[nN][oO]$", "Would you like to add another student or check the info on one of the current students? (Y/N): ", "Sorry, please enter Y/N", "Sorry, please enter Y/N");
                }
                else
                {
                    int studentNumber = StudentNumberInput(studentNamesList.Count);
                    StudentInfo("", studentNumber, studentNamesList, studentHobbies, studentHometownsList, studentFavoriteFoodsList);
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

        public static int StudentNumberInput(int listCount)
        {
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

        public static void StudentInfo(string message, int studentNumber, List<string> studentNames, List<string> studentHobbies, List<string> studentHometown, List<string> studentFoods)
        {
            string knowMore = "y";
            while (Regex.IsMatch(knowMore, @"^[yY]$|^[yY][eE][sS]$"))
            {
                #region userChoice
                string userFactChoice = GetValidInput(@"^[hH][oO][mM][eE][tT][oO][wW][nN]$|^[fF][aA][vV][oO][rR][iI][tT][eE] [fF][oO][oO][dD]$|^[hH][oO][bB][bB][yY]$",
                $"#{studentNumber} is {studentNames[studentNumber - 1]}. What would you like to know about? (enter \"hometown\", \"favorite food\", or \"hobby\"): ",
                "That choice is not an option. Please choose a valid data, either \"hometown\", \"favorite food\", or \"hobby\".",
                "A null value huh? Nice try Drew. Enter \"hometown\", \"favorite food\", or \"hobby\".");
                #endregion

                if (Regex.IsMatch(userFactChoice, @"^[hH][oO][mM][eE][tT][oO][wW][nN]$"))
                {
                    Console.WriteLine($"{studentNames[studentNumber - 1]}'s hometown is {studentHometown[studentNumber - 1]}.");
                }
                else if (Regex.IsMatch(userFactChoice, @"^[hH][oO][bB][bB][yY]$"))
                {
                    Console.WriteLine($"{studentNames[studentNumber - 1]}'s hobby is {studentHobbies[studentNumber - 1]}");
                }
                else
                {
                    Console.WriteLine($"{studentNames[studentNumber - 1]}'s favorite food is {studentFoods[studentNumber - 1]}.");
                }
                knowMore = GetValidInput(@"^[yY]$|^[yY][eE][sS]$|^[nN]$|^[nN][oO]$", "Would you like to know more about this student? (enter yes or no): ",
                    "That wasn't a yes or no, so I'm unsure what you want. Please enter yes or no: ",
                    "That wasn't a yes or no, so I'm unsure what you want. Please enter yes or no: ");
            }



        }
    }
}
