using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Checkpoint02.AntonLilja
{
    class RoomParser
    {
        public static Room[] RoomArrayFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Inmatning kan inte vara tom/null");

            var commandArray = CommandArrayFromString(input);

            if (CommandArrayIsValid(commandArray))
                return RoomArrayFromCommandArray(commandArray);
            else
                throw new Exception("Ogiltig inmatning (RoomArrayFromString())");
        }

        public static string[] CommandArrayFromString(string input)
        {
            var inputArray = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

            var commandArray = TrimItemsInArray(inputArray);

            if (CommandArrayIsValid(commandArray))
                return commandArray;
            else
                throw new Exception("Ogiltig inmatning (CommandArrayFromString())");
        }

        public static string[] TrimItemsInArray(string[] commandArray)
        {
            var cleanedArray = new string[commandArray.Length];

            for (int i = 0; i < commandArray.Length; i++)
                cleanedArray[i] = commandArray[i].Trim();

            return cleanedArray;
        }

        public static bool CommandArrayIsValid(string[] commandArray)
        {
            foreach (var command in commandArray)
                if (!CommandIsValid(command))
                    throw new Exception($"Ogiltigt kommando ({command})");
            return true;
        }

        public static Room[] RoomArrayFromCommandArray(string[] commandArray)
        {
            var roomArray = new Room[commandArray.Length];

            for (int i = 0; i < commandArray.Length; i++)
                roomArray[i] = RoomFromCommand(commandArray[i]);

            return roomArray;
        }

        public static bool CommandIsValid(string command) => (Regex.IsMatch(command.Trim().ToLower(), @"^[a-zåäö]+\s\d+m2\s(on|off)$")) ? true : false;

        public static Room RoomFromCommand(string command)
        {
            var name = GetNameFromCommand(command);
            var size = GetSizeFromCommand(command);
            var lightIsOn = GetLightStatusFromCommand(command);

            return new Room(name, size, lightIsOn);
        }

        public static string GetNameFromCommand(string command) => command.Split(' ')[0];
        
        public static int GetSizeFromCommand(string command)
        {
            var splitCommand = command.Split(' ');
            if (int.TryParse(Regex.Replace(splitCommand[1], "m2", "").Trim(), out int result))
                return result;
            else
                throw new Exception($"Felaktig rumsyta ({command})");
        }

        public static bool GetLightStatusFromCommand(string command)
        {
            if (Regex.IsMatch(command.Trim().ToLower(), @"^[a-zåäö]+\s\d+m2\s(on)$"))
                return true;
            else
                return false;
        }
    }
}
