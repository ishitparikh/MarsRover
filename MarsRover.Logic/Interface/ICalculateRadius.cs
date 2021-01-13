using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Logic.Interface
{
    /// <summary>
    /// An interface for the circle shape to find the radius and circumference.
    /// It can be used addition to IMovePosition for circular plateau. 
    /// It's an example of Interface Segregation Principle (ISP) where find the radius and circumference are only related to Circle shape
    /// </summary>
    public interface ICircleShape
    {
        decimal FindRadius();
        decimal FindCircumference();
    }
}
