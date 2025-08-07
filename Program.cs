using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace To_Do_List
{
    class Program
    {
        static void Main(string[] args)
        {

           

           
            ArrayList tasksList = new ArrayList();
            string option = "";
            while (option != "Exist")
            {
                saywelcom();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter 1 to add a new task");
              
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter 2 to remove a task");


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter 3 to view your List");


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter 4 to modify your List");


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter Exist to close your List");

                option = Console.ReadLine();
                if (option == "1")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    try
                    {
                        Console.WriteLine("enter name of the task to add to List");
                        string task = Console.ReadLine();
                        Console.WriteLine("Enter the time required to complete this task in minutes");
                        int time = int.Parse(Console.ReadLine());
                        if (time <= 0)
                        {
                            while (time <= 0)
                            {
                                Console.WriteLine("Time must be positive try again");
                                time = int.Parse(Console.ReadLine());
                            }
                            new requiredTime(task, time);
                            Addtasks(tasksList, task);
                            DisplayList(tasksList);


                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Focus in the input and try again");
                    }





                }
                if (option == "2")
                {
                    Console.ForegroundColor = ConsoleColor.Red;


                    Console.WriteLine("enter name of the task to remove from List");
                    string task = Console.ReadLine();
                    Removetasks(tasksList, task);
                    DisplayList(tasksList);



                }
                if (option == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    DisplayList(tasksList);

                }
                if (option == "4")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("Enter the task you want to modify ");
                    string task = Console.ReadLine();
                    Console.WriteLine("Enter the modification");
                    string replace = Console.ReadLine();
                    Removetasks(tasksList, task);
                    Addtasks(tasksList, replace);
                    DisplayList(tasksList);

                }
                else
                {
                    Console.WriteLine("enter Exist if you want to cloose the list ");
                    if (option == "Exist")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;

                        return;
                    }
                }


            }


        }





        //welcom message
        static void saywelcom()
        {
            string s1 = "-----------------------------";
            string s2 = "Here is To-Do-List ,Welcome";
            string s3 = "-----------------------------";

            int width = Console.WindowWidth;
            int center = (width - s2.Length) / 2;

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(new string(' ', center) + s1);
            Console.WriteLine(new string(' ', center) + s2);
            Console.WriteLine(new string(' ', center) + s3);

        }
        
        
        
        
        
        //this Method ADD tasks 
        static void Addtasks(ArrayList tasks, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("The task cannot be empty");
            }
            else
            {
                tasks.Add(input);
            }
        } //this Method REMOVE tasks 
        static void Removetasks(ArrayList tasks, string input)
        {
            if (tasks.Contains(input))
            {
                tasks.Remove(input);
            }
            else
            {
                Console.WriteLine("Your task doesn't already exist  ");
            }
        } //this Method VIEW tasks
        static void DisplayList(ArrayList tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("you don't have list yet");
                Console.WriteLine("Create Your list");
            }
            else
            {
                foreach (string items in tasks)
                {
                    Console.WriteLine("Now your List contains");
                    Console.WriteLine($"*{items}");
                }
            }

        }
        class requiredTime
        {
            public string Task { get; set; }
            public int Time  { get; set; }
            public requiredTime(string name,int time)
            {
                Task = name;
                Time = time;
                Console.WriteLine($"task is {name} during {time}");
            }
        }

    }
}
