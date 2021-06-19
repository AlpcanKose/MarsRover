using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rover list for moving sequentially and checking collision.
            List<Rover> rovers = new List<Rover>();

            #region Creating Plateau and Rovers
            int id = 1;
            int plateauX = 0;
            int plateauY = 0;
            TakeInputForPlateau(out plateauX, out plateauY);
            var flag = true;
            while (flag)
            {
                var rover = CreateRover(plateauX,plateauY,id);
                if (rover == null)
                {
                    flag = false;
                }
                else
                {
                    rovers.Add(rover);
                    id++;
                }
            }
            #endregion

            #region Moving
            foreach (var item in rovers)
            {
                item.StartMoving(rovers);
            }
            #endregion

            #region Output

            foreach (var item in rovers)
            {
                Console.WriteLine(item.RoverXCoordinate + " " + item.RoverYCoordinate + " " + item.RoverDirection);
            }
            #endregion
        }
        //Creating limits.
        static void TakeInputForPlateau(out int plateauX, out int plateauY)
        {
            var plateau = Console.ReadLine();
            var plateauArray = plateau.Split(' ');
            plateauX = Int32.Parse(plateauArray[0]);
            plateauY = Int32.Parse(plateauArray[1]);
            
        }
        //Creating rover with all parameters.
        static Rover CreateRover(int plateauX,int plateauY,int id)
        {
            var rover = Console.ReadLine();
            var roverArray = rover.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (roverArray.Length == 0)
            {
                return null;
            }
            var commands = Console.ReadLine();
            if (commands.Length == 0)
            {
                return null;
            }
            return new Rover(id,Int32.Parse(roverArray[0]), Int32.Parse(roverArray[1]), roverArray[2], commands,plateauX,plateauY);
            
        }
    }
}
