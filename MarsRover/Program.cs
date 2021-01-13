using MarsRover.Logic;
using MarsRover.Logic.Common;
using MarsRover.Logic.Interface;
using MarsRover.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string upperRightPointsInput = Console.ReadLine().Trim();
            if (!string.IsNullOrWhiteSpace(upperRightPointsInput))
            {
                string roverPositionInput = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(roverPositionInput))
                {
                    string moveCommands = Console.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(roverPositionInput))
                    {
                        IPositionInputValidator positionInputValidator = new PositionInputValidator();
                        IMovePosition position = new PlateauPosition(positionInputValidator);

                        MoveRoverRequest moveRoverRequest = new MoveRoverRequest();
                        moveRoverRequest.UpperPointsInput = upperRightPointsInput;
                        moveRoverRequest.RoverPositionInput = roverPositionInput;
                        moveRoverRequest.MoveCommandsInput = moveCommands;

                        string updatedRoverPosition = position.MovePosition(moveRoverRequest);
                        Console.WriteLine(updatedRoverPosition);
                    }
                    else
                    {
                        Console.WriteLine(Constants.INVALIDMOVECOMMANDS);
                    }
                }
                else
                {
                    Console.WriteLine(Constants.INVALIDROVERPOSITION);
                }
            }
            else
            {
                Console.WriteLine(Constants.INVALIDUPPERPOINTS);
            }


            Console.ReadLine();
        }
    }
}
