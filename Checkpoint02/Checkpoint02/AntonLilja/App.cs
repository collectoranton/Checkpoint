using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint02.AntonLilja
{
    class App
    {
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n----------------------------------------------------\n");
                WriteLineColor("Ange rum i lägenheten:", ConsoleColor.White);
                var input = ReadLineColor(ConsoleColor.Gray);

                Console.WriteLine();

                if (StringIsExitOrQuit(input))
                    break;

                var apartment = new Apartment();

                TryAddRoomsFromArray(input, apartment);

                foreach (var item in apartment.GetLargestRooms())
                {
                    Console.WriteLine(item);
                }
            }

        }

        public static bool StringIsExitOrQuit(string input) => (input.Trim().ToLower() == "exit" || input.Trim().ToLower() == "quit") ? true : false;

        public static void WriteLineColor(string writeLine, ConsoleColor color)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(writeLine);
            Console.ForegroundColor = initialColor;
        }

        public static string ReadLineColor(ConsoleColor color)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            var input = Console.ReadLine();
            Console.ForegroundColor = initialColor;
            return input;
        }

        private static void TryAddRoomsFromArray(string input, Apartment apartment)
        {
            try
            {
                apartment.AddRoomsFromRoomArray(RoomParser.RoomArrayFromString(input));
            }
            catch (Exception e)
            {

                WriteLineColor(e.Message, ConsoleColor.Red);
            }
        }
    }
}
