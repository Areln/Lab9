using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        //only needs to be 5
        static List<string> studentNames = new List<string>() { "Aaron", "Kelly", "Josh", "Seth", "Bailey" };
        static List<string> studentHometowns = new List<string>() { "Sterling Heights", "Warren", "Sterling Heights", "Ann Arbor", "Saginaw" };
        static List<string> studentFavFoods = new List<string>() { "Cinnamon Rolls", "Apples", "Pizza", "Watermelon", "Ice Cream" };
        static List<string> studentFavColor = new List<string>() { "Black", "Red", "Yellow", "Green", "Blue" };
        static int userInput;
        static string exiting = "n";
        static void Main(string[] args)
        {
            while (exiting != "y")
            {
                int selection = ParseIntFromString("1) Get Student Information \n2) Add Student\n3) Exit");
                switch (selection)
                {
                    case 1:
                        AskForStudent();
                        break;
                    case 2:
                        AddStudent();
                        break;
                        case 3:
                        Rerun();
                        break;
                    default:
                        break;
                }
            }

        }
        static void AskForStudent()
        {
            userInput = ParseIntFromString($"Welcome to our C# class. Which student would you like to learn more about? (enter anumber 1-{studentNames.Count}, 0 to exit):")-1;
            switch (userInput)
            {
                case -1:
                    Rerun();
                    break;
                default:
                    Console.WriteLine($"Student {userInput+1} is {studentNames[userInput]}.");
                    MoreInfo(userInput);
                    break;
            }
        }

        static void AddStudent() 
        {
            studentNames.Add(GetInput("I will need you to answer a few questions for me.\n1) What is the new students name. ", true));
            studentHometowns.Add(GetInput($"2) Where is {studentNames[studentNames.Count-1]} from? ", true));
            studentFavFoods.Add(GetInput($"3) What is {studentNames[studentNames.Count - 1]}'s favorite food? ", true));
            studentFavColor.Add(GetInput($"3) What is {studentNames[studentNames.Count - 1]}'s favorite color? ", true));
            Console.WriteLine($"{studentNames[studentNames.Count-1]} has been added to the list as number {studentNames.Count}");
        }



        static void GetHomeTown(int index)
        {
            switch (ParseIntFromString($"{studentNames[index]} is from {studentHometowns[index]}. Would you like to know more?\n1) Yes\n2) No"))
            {
                case 1:
                    MoreInfo(index);
                    break;
                case 2:
                    Rerun();
                    break;
                default:
                    Console.WriteLine("try again");
                    GetHomeTown(index);
                    break;
            }
        }
        static void GetFavColor(int index)
        {
            switch (ParseIntFromString($"{studentNames[index]}'s Favorite Color is {studentFavColor[index]}. Would you like to know more?\n1) Yes\n2) No)"))
            {
                case 1:
                    MoreInfo(index);
                    break;
                case 2:
                    Rerun();
                    break;
                default:
                    Console.WriteLine("try again");
                    GetFavColor(index);
                    break;
            }
        }
        static void GetFavFood(int index)
        {
            switch (ParseIntFromString($"{studentNames[index]}'s favorite food is {studentFavFoods[index]}. Would you like to know more?\n1) Yes\n2) No)"))
            {
                case 1:
                    MoreInfo(index);
                    break;
                case 2:
                    Rerun();
                    break;
                default:
                    Console.WriteLine("try again");
                    GetFavFood(index);
                    break;
            }
        }
        static void MoreInfo(int index)
        {
            int selection = ParseIntFromString("What else would you like to know?\n1)Home Town\n2)Favorite Food\n3)Favorite Color");
            switch (selection)
            {
                case 1:
                    GetHomeTown(index);
                    break;
                case 2:
                    GetFavFood(index);
                    break;
                case 3:
                    GetFavColor(index);
                    break;
                case 4:
                    Rerun();
                    break;
                default:
                    Console.WriteLine("Try again");
                    MoreInfo(index);
                    break;
            }
        }
        static void Rerun()
        {
            exiting = GetInput("Would you like to exit?(y/n): ");
        }
        static string GetInput(string message, bool blankSpace = false)
        {
            if (!blankSpace)
            {
                Console.WriteLine(message);
                return Console.ReadLine();
            }
            else
            {
                string input = GetInput(message);
                if (input == "")
                {
                    return GetInput(message, blankSpace);
                }
                else
                {
                    return input;
                }
            }

        }
        static int ParseIntFromString(string message)
        {
            try
            {
                return int.Parse(GetInput(message));
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again: ");
                return ParseIntFromString(message);
            }
        }
    }
}
