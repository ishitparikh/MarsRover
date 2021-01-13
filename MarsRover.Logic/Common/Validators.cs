using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover.Logic.Common
{
    public static class Validators
    {
        public static bool ValidateCoordinates(string coordinateValue)
        {
            string directionRegex = "^[0-9]+$";
            return Regex.IsMatch(coordinateValue, directionRegex);
        }

        public static bool ValidateDirection(string directionValue)
        {
            string directionRegex = "^[NSEW]+$";
            return Regex.IsMatch(directionValue, directionRegex);
        }

        public static bool ValidateMoveCommand(string commandValue)
        {
            string commandRegex = "^[LRM]+$";
            return Regex.IsMatch(commandValue, commandRegex);
        }
    }
}
