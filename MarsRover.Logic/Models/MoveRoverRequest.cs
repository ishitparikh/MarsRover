using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Logic.Models
{
    public class MoveRoverRequest
    {
        public string UpperPointsInput { get; set; }
        public string RoverPositionInput { get; set; }
        public string MoveCommandsInput { get; set; }
    }
}
