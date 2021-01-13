using MarsRover.Logic.Common;
using MarsRover.Logic.Interface;
using MarsRover.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Logic.Common.Enums;

namespace MarsRover.Logic
{
    /// <summary>
    /// PlateauPosition class to move rover over the plateau. 
    /// Uses Open/Close Principle by using IMovePosition interface
    /// </summary>
    public class PlateauPosition : IMovePosition
    {
        /// <summary>
        /// Interface to validate the inputs using Dependency Inversion Principle (DIP) i.e. Dependency Injection
        /// </summary>
        IPositionInputValidator _positionInputValidator;
        RoverPositionVM roverPositionVM;

        public PlateauPosition(IPositionInputValidator positionInputValidator)
        {
            roverPositionVM = new RoverPositionVM();
            _positionInputValidator = positionInputValidator;
        }

        /// <summary>
        /// Function to move the position of the Rover on the Plateau
        /// Declared as a virtual function to be implemented as per the Liskov Substitution Principle when inherited by a subclass e.g. CirclePlatePosition
        /// </summary>
        /// <param name="moveRoverRequest"></param>
        /// <returns></returns>
        public virtual string MovePosition(MoveRoverRequest moveRoverRequest)
        {
            string updatedPosition = string.Empty;
            string errMessage = ValidateInputs(moveRoverRequest);
            var upperPoints = moveRoverRequest.UpperPointsInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            if (string.IsNullOrWhiteSpace(errMessage))
            {
                var roverPositionValues = moveRoverRequest.RoverPositionInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                roverPositionVM.PositionX = int.Parse(roverPositionValues[0]);
                roverPositionVM.PositionY = int.Parse(roverPositionValues[1]);
                roverPositionVM.Direction = (Directions)Enum.Parse(typeof(Directions), roverPositionValues[2]);

                foreach(var move in moveRoverRequest.MoveCommandsInput)
                {
                    switch (move)
                    {
                        case 'L':
                            RotateLeft();
                            break;
                        case 'R':
                            RotateRight();
                            break;
                        default:
                            MoveForward();
                            break;
                    }

                    if (roverPositionVM.PositionX < 0 || roverPositionVM.PositionX > upperPoints[0] || roverPositionVM.PositionY < 0 || roverPositionVM.PositionY > upperPoints[1])
                    {
                        return $"Position can not be beyond the bounderies (0 , 0) and ({upperPoints[0]} , {upperPoints[1]})";
                    }
                }
                updatedPosition = roverPositionVM.PositionX.ToString() + " " + roverPositionVM.PositionY.ToString() + " " + roverPositionVM.Direction.ToString();
            }
            else
            {
                return errMessage;
            }
            return updatedPosition;
        }

        /// <summary>
        /// Validator to validate the inputs, implements Single Responsibility Principle (SRP) by calling ValidateInputs from IPositionInputValidator instead of implementing it in the same class
        /// </summary>
        private string ValidateInputs(MoveRoverRequest moveRoverRequest)
        {
            return _positionInputValidator.ValidateInputs(moveRoverRequest);
        }

        /// <summary>
        /// Function to rotate rover 90 degrees left
        /// </summary>
        private void RotateLeft()
        {
            switch (roverPositionVM.Direction)
            {
                case Directions.N:
                    roverPositionVM.Direction = Directions.W;
                    break;
                case Directions.S:
                    roverPositionVM.Direction = Directions.E;
                    break;
                case Directions.E:
                    roverPositionVM.Direction = Directions.N;
                    break;
                case Directions.W:
                    roverPositionVM.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Function to rotate rover 90 degrees right
        /// </summary>
        private void RotateRight()
        {
            switch (roverPositionVM.Direction)
            {
                case Directions.N:
                    roverPositionVM.Direction = Directions.E;
                    break;
                case Directions.S:
                    roverPositionVM.Direction = Directions.W;
                    break;
                case Directions.E:
                    roverPositionVM.Direction = Directions.S;
                    break;
                case Directions.W:
                    roverPositionVM.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Function to move the rover forward
        /// </summary>
        private void MoveForward()
        {
            switch (roverPositionVM.Direction)
            {
                case Directions.N:
                    roverPositionVM.PositionY += 1;
                    break;
                case Directions.S:
                    roverPositionVM.PositionY -= 1;
                    break;
                case Directions.E:
                    roverPositionVM.PositionX += 1;
                    break;
                case Directions.W:
                    roverPositionVM.PositionX -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}
