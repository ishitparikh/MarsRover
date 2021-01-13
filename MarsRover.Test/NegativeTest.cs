using MarsRover.Logic;
using MarsRover.Logic.Common;
using MarsRover.Logic.Interface;
using MarsRover.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRover.Test
{
    [TestClass]
    public class NegativeTest
    {
        IPositionInputValidator positionInputValidator;
        IMovePosition position;
        string upperPoints = "5 5";

        public NegativeTest()
        {
            positionInputValidator = new PositionInputValidator();
            position = new PlateauPosition(positionInputValidator);
        }

        [TestMethod]
        public void Invalid_RoverPosition()
        {
            MoveRoverRequest moveRoverRequest = new MoveRoverRequest()
            {
                UpperPointsInput = upperPoints,
                RoverPositionInput = "12 N",
                MoveCommandsInput = "LMLMLMLMM"
            };

            string updatedPosition = position.MovePosition(moveRoverRequest);

            Assert.IsTrue(updatedPosition == Constants.INVALIDROVERPOSITION);
        }

        [TestMethod]
        public void Invalid_UpperPoints()
        {
            MoveRoverRequest moveRoverRequest = new MoveRoverRequest()
            {
                UpperPointsInput = upperPoints.Replace(" ", ""),
                RoverPositionInput = "3 3 E",
                MoveCommandsInput = "MMRMMRMRRM"
            };

            string updatedPosition = position.MovePosition(moveRoverRequest);

            Assert.IsTrue(updatedPosition == Constants.INVALIDUPPERPOINTS);
        }

        [TestMethod]
        public void Invalid_MoveCommands()
        {
            MoveRoverRequest moveRoverRequest = new MoveRoverRequest()
            {
                UpperPointsInput = upperPoints,
                RoverPositionInput = "3 3 E",
                MoveCommandsInput = "MMOMMRMRRM"
            };

            string updatedPosition = position.MovePosition(moveRoverRequest);

            Assert.IsTrue(updatedPosition == Constants.INVALIDMOVECOMMANDS);
        }

        [TestMethod]
        public void Invalid_RoverDirection()
        {
            MoveRoverRequest moveRoverRequest = new MoveRoverRequest()
            {
                UpperPointsInput = upperPoints,
                RoverPositionInput = "3 3 R",
                MoveCommandsInput = "MMRMMRMRRM"
            };

            string updatedPosition = position.MovePosition(moveRoverRequest);

            Assert.IsTrue(updatedPosition == Constants.INVALIDROVERDIRECTION);
        }

        [TestMethod]
        public void MoveCommandBeyondBounderies()
        {
            MoveRoverRequest moveRoverRequest = new MoveRoverRequest()
            {
                UpperPointsInput = upperPoints,
                RoverPositionInput = "3 3 E",
                MoveCommandsInput = "MMMRM"
            };

            string updatedPosition = position.MovePosition(moveRoverRequest);
            
            string errorMessage = $"Position can not be beyond the bounderies (0 , 0) and ({upperPoints.Split(' ')[0]} , {upperPoints.Split(' ')[1]})";

            Assert.IsTrue(updatedPosition == errorMessage);
        }
    }
}
