using MarsRover.Logic;
using MarsRover.Logic.Interface;
using MarsRover.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static MarsRover.Logic.Common.Enums;

namespace MarsRover.Test
{
    [TestClass]
    public class PositiveTest
    {
        IPositionInputValidator positionInputValidator;
        IMovePosition position;
        string upperPoints = "5 5";

        public PositiveTest()
        {
            positionInputValidator = new PositionInputValidator();
            position = new PlateauPosition(positionInputValidator);
        }

        [TestMethod]
        public void Input_12N_LMLMLMLMM()
        {
            MoveRoverRequest moveRoverRequest = new MoveRoverRequest()
            {
                UpperPointsInput = upperPoints,
                RoverPositionInput = "1 2 N",
                MoveCommandsInput = "LMLMLMLMM"
            };

            string updatedPosition = position.MovePosition(moveRoverRequest);

            Assert.IsTrue(updatedPosition == "1 3 N");
        }

        [TestMethod]
        public void Input_33E_MMRMMRMRRM()
        {
            MoveRoverRequest moveRoverRequest = new MoveRoverRequest()
            {
                UpperPointsInput = upperPoints,
                RoverPositionInput = "3 3 E",
                MoveCommandsInput = "MMRMMRMRRM"
            };

            string updatedPosition = position.MovePosition(moveRoverRequest);

            Assert.IsTrue(updatedPosition == "5 1 E");
        }
    }
}
