using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Logic.Common.Enums;

namespace MarsRover.Logic.Models
{
    public class RoverPositionVM
    {
        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public Directions Direction { get; set; }
    }
}
