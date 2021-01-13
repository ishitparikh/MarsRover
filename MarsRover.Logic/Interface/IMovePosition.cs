using MarsRover.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Logic.Interface
{
    public interface IMovePosition
    {
        string MovePosition(MoveRoverRequest moveRoverRequest);
    }
}
