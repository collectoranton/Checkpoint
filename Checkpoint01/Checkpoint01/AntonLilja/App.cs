using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint01.AntonLilja
{
    class App
    {
        public static void Run()
        {
            Console.Write("Ange kommando: ");
            var command = GetInputFromUser();
            var list = GetCommandsListFromString(command);

            Console.WriteLine();

            PrintTriangles(list);

            Console.WriteLine();
        }

        private static void PrintTriangles(List<Command> list)
        {
            foreach (var command in list)
            {
                var counter = 1;

                if (command.TipIsUp)
                {
                    for (int i = 0; i < command.Height; i++)
                    {
                        for (int j = 0; j < counter; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                        counter++;
                    }
                }

                else
                { 
                    counter = command.Height;
                    for (int i = 0; i < command.Height; i++)
                    {
                        for (int j = 0; j < counter; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                        counter--;
                    }
                }
            }
        }

        private static int GetHeightFromCommandString(string command)
        {
            var commandWithoutCharacter = RemoveFirstCharacter(command);

            if (int.TryParse(commandWithoutCharacter, out int result))
                return result;
            else
                return -1;
        }

        private static string RemoveFirstCharacter(string input)
        {
            var corrected = new StringBuilder(input);
            return corrected.Remove(0, 1).ToString();
        }

        private static Command StringToCommand(string command)
        {
            var tipIsUp = false;

            if (char.ToLower(command[0]) == 'a')
                tipIsUp = true;

            var height = GetHeightFromCommandString(command);

            return new Command(tipIsUp, height);
        }

        private static bool CommandFormatIsValid(string command)
        {
            if (Regex.IsMatch(command.Trim(), @"^[abAB][0-9]+"))
            {
                if (GetHeightFromCommandString(command) != -1)
                    return true;
                else
                    WriteLineColor("För stor höjdparameter", ConsoleColor.Red);
            }

            WriteLineColor($"Felaktigt kommando ({command})", ConsoleColor.Red);
            return false;
        }

        private static bool CommandListIsValid(string[] list)
        {
            if (list.Length == 1 && string.IsNullOrWhiteSpace(list[0]))
            {
                WriteLineColor("Tom lista", ConsoleColor.Red);
                return false;
            }

            var CommandIsValid = true;

            foreach (var command in list)
            {
                if (!CommandFormatIsValid(command))
                    CommandIsValid = false;
            }

            if (CommandIsValid)
                return true;
            else
                return false;
        }

        private static List<Command> GetCommandsListFromString(string input)
        {
            var intermediateList = input.Split('-');
            var outputList = new List<Command>();

            if (CommandListIsValid(intermediateList))
            {
                foreach (var command in intermediateList)
                    outputList.Add(StringToCommand(command));
            }

            return outputList;
        }

        private static string GetInputFromUser()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var input = Console.ReadLine();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                    WriteLineColor("Inmatning kan inte vara tom", ConsoleColor.Red);
                else
                    return input;
            }
        }

        private static void WriteLineColor(string value, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }

    class Command
    {
        public bool TipIsUp { get; }
        public int Height { get; }

        public Command(bool tipIsUp, int height)
        {
            TipIsUp = tipIsUp;
            Height = height;
        }
    }
}
