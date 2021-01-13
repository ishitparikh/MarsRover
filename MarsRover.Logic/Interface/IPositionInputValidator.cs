using MarsRover.Logic.Models;

namespace MarsRover.Logic.Interface
{
    public interface IPositionInputValidator
    {
        string ValidateInputs(MoveRoverRequest moveRoverRequest);
    }
}
