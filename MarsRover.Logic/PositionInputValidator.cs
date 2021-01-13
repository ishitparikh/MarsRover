using MarsRover.Logic.Common;
using MarsRover.Logic.Interface;
using MarsRover.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Logic
{
    public class PositionInputValidator : IPositionInputValidator
    {
        public PositionInputValidator()
        {

        }

        public string ValidateInputs(MoveRoverRequest moveRoverRequest)
        {
            string errorMessage = string.Empty;
            int upperXValue, upperYValue;

            if (moveRoverRequest.UpperPointsInput.Contains(' ') && moveRoverRequest.UpperPointsInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() == 2)
            {
                var stringValues = moveRoverRequest.UpperPointsInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!Validators.ValidateCoordinates(stringValues[0]) || !Validators.ValidateCoordinates(stringValues[1]))
                {
                    errorMessage = Constants.INVALIDUPPERPOINTS;
                    return errorMessage;
                }
                else
                {
                    upperXValue = int.Parse(stringValues[0]);
                    upperYValue = int.Parse(stringValues[1]);
                }
            }
            else
            {
                errorMessage = Constants.INVALIDUPPERPOINTS;
                return errorMessage;
            }

            if (moveRoverRequest.RoverPositionInput.Contains(' ') && moveRoverRequest.RoverPositionInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() == 3)
            {
                var stringValues = moveRoverRequest.RoverPositionInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                int xValue, yValue;
                if (!Validators.ValidateCoordinates(stringValues[0]) || !Validators.ValidateCoordinates(stringValues[1]))
                {
                    errorMessage = Constants.INVALIDROVERPOSITION;
                    return errorMessage;
                }
                else
                {
                    xValue = int.Parse(stringValues[0]);
                    yValue = int.Parse(stringValues[1]);
                }

                if (xValue > upperXValue || xValue < 0 || yValue > upperYValue || yValue < 0)
                {
                    errorMessage = $"Position can not be beyond the bounderies (0 , 0) and ({upperXValue - 1 } , {upperYValue - 1})";
                    return errorMessage;
                }
                else if (stringValues[2].Length > 1 || !Validators.ValidateDirection(stringValues[2]))
                {
                    errorMessage = Constants.INVALIDROVERDIRECTION;
                    return errorMessage;
                }
            }
            else
            {
                errorMessage = Constants.INVALIDROVERPOSITION;
                return errorMessage;
            }

            if (moveRoverRequest.MoveCommandsInput.Contains(' ') || !Validators.ValidateMoveCommand(moveRoverRequest.MoveCommandsInput))
            {
                errorMessage = Constants.INVALIDMOVECOMMANDS;
                return errorMessage;
            }

            return errorMessage;
        }
    }
}
