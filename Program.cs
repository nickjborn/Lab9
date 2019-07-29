using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> studentList = MakeStudentList();
            bool shouldContinue = false;

            do
            {
                Console.Clear();
                studentList = studentList
                    .OrderBy(arr => arr[0])
                    .ToList();

                bool search = PickAddOrSearch();
                if (search)
                {
                    int selectedStudent = AskUserForStudent(studentList);
                    InterpretStudentData(selectedStudent, studentList);
                }
                else
                {
                    studentList.Add(AddStudent());
                }

                shouldContinue = AskToContinue();
                studentList = studentList
                    .OrderBy(arr => arr[0])
                    .ToList();

            } while (shouldContinue);

            Console.WriteLine("Alrighy then! See ya!");

        }



        static List<string[]> MakeStudentList()
        {

            List<string[]> studentList = new List<string[]>();

            studentList.Add(new string[] { "AAAAname", "Color", "Hometown", "Food" });
            studentList.Add(new string[] { "Bob", "Red", "Denver", "Pizza" });
            studentList.Add(new string[] { "Frank", "Blue", "Tucson", "Burritos" });
            studentList.Add(new string[] { "Debbie", "Green", "Flagstaff", "Carrots" });
            studentList.Add(new string[] { "Sue", "Yellow", "Chicago", "Mayonnaise" });
            studentList.Add(new string[] { "Mark", "Orange", "New York", "Tuna sandwich" });
            studentList.Add(new string[] { "Damien", "Pink", "Boston", "Bread" });
            studentList.Add(new string[] { "Angie", "Red", "Los Angles", "Pasta" });
            studentList.Add(new string[] { "Carol", "Blue", "Anchorage", "Hummus" });
            studentList.Add(new string[] { "Luke", "Blue", "Melbourne", "Cheese" });
            studentList.Add(new string[] { "Stan", "Black", "Detroit", "Beans" });
            studentList.Add(new string[] { "Karen", "Purple", "Seattle", "Chicken" });
            studentList.Add(new string[] { "Amy", "Red", "Portland", "Eggs" });
            studentList.Add(new string[] { "Derek", "Blue", "Nashville", "Toast" });
            studentList.Add(new string[] { "John", "Yellow", "Jacksonville", "Cookies" });
            studentList.Add(new string[] { "Ellen", "Blue", "Birmingham", "Cake" });
            studentList.Add(new string[] { "Courtney", "Orange", "Aberdeen", "Egg rolls" });
            studentList.Add(new string[] { "Fred", "Red", "London", "Rice" });
            studentList.Add(new string[] { "Zed", "Green", "Toronto", "Baklava" });
            studentList.Add(new string[] { "Mariah", "Blue", "Lima", "Candy" });
            studentList.Add(new string[] { "Lauren", "Red", "Bismark", "Beef" });

            return studentList;

        }

        static int AskUserForStudent(List<string[]> studentList)
        {
            Console.WriteLine("Which student would you like to learn more about? (enter a  number 1-20):");
            int studentNumber = 0;
            bool validNumber = false;

            do
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out studentNumber))
                {
                    if (studentNumber <= studentList.Count - 1 && studentNumber > 0)
                    {
                        validNumber = true;
                    }
                    else
                    {
                        validNumber = false;
                        Console.WriteLine("Hmm... that doesn't seem to be a student in this class... try another number, 1-20");
                    }
                }
                else
                {
                    Console.WriteLine("That's not even a number... try that again.");
                    validNumber = false;
                }

            } while (!validNumber);


            return studentNumber;

        }

        static void InterpretStudentData(int student, List<string[]> studentList)
        {
            string[] studentData = studentList[student];
            bool validInput = false;



            Console.WriteLine($"Ah yes, {studentData[0]}. What would you like to know about them? (favorite color/hometown/favorite food)");

            do
            {
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "hometown")
                {
                    Console.WriteLine($"Oh, {studentData[0]}? They're from {studentData[2]}.");
                    return;
                }
                else if (userInput == "favorite food")
                {
                    Console.WriteLine($"Oh, {studentData[0]}? Their favorite food is {studentData[3]}.");
                    return;
                }
                else if (userInput == "favorite color")
                {
                    Console.WriteLine($"Oh, {studentData[0]}? Their favorite color is {studentData[1]}.");
                    return;
                }
                else
                {
                    Console.WriteLine("You'll need to type 'hometown','favorite food', or 'favorite color'.");
                    validInput = false;
                }

            } while (!validInput);


        }

        static bool AskToContinue()
        {
            bool shouldContinue = true;
            bool validInput = false;

            Console.WriteLine("Want to go again? (y/n)");
            do
            {
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    validInput = true;
                    shouldContinue = true;
                }
                else if (input == "n")
                {
                    validInput = true;
                    shouldContinue = false;
                }
                else
                {
                    Console.WriteLine("Well, that's not the answer I was looking for... type either 'y' or 'n' to continue");
                    validInput = false;
                }


            } while (!validInput);



            return shouldContinue;
        }

        static bool PickAddOrSearch()
        {
            bool validInput = false;
            Console.WriteLine("Welcome to the class! Would you like to search or add a student? [enter search or add]");
            do
            {
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "search")
                {
                    return true;
                }
                else if (userInput == "add")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Hmm... this is embarrising, I don't know what you mean. You'll need to type either 'search' or 'add'.");
                    validInput = false;
                }

            } while (!validInput);
            return false;

        }

        static string[] AddStudent()
        {
            string name = RequestData("What's the student's name?");
            string color = RequestData("What's the student's favorite color?");
            string hometown = RequestData("What's the student's hometown?");
            string food = RequestData("What's the student's favorite food?");

            return (new string[] {name, color, hometown, food});

        }

        static string RequestData(string request)
        {
            bool validInput = false;
            Console.WriteLine(request);
            string answer = "awesome";
            do
            {
                answer = Console.ReadLine();
                
                if(answer != "")
                {
                    validInput = true;
                }
                else
                {
                    validInput = false;
                    Console.WriteLine("Please enter something. Anything...");
                }
            } while (!validInput);

            return answer;
            
        }

    }
}
