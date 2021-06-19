using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        //X Coordinate for Rover
        public int RoverXCoordinate = 0;
        //Y Coordinate for Rover
        public int RoverYCoordinate = 0;
        //X Coordinate for Plateau
        public int PlateauX = 0;
        //Y Coordinate for Plateau
        public int PlateauY = 0;
        //Using for recognizing another rovers on the way
        public int Id = 0;
        //Direction of the rover
        public string RoverDirection = "N";
        //Commands of the rover
        public string Commands = "";

        //Constructor for Creating Rover with initial parameters.
        public Rover(int id,int x, int y, string direction,string commands,int plateauX,int plateauY)
        {
            CheckInitialize(plateauX, plateauY, x, y);
            RoverXCoordinate = x;
            RoverYCoordinate = y;
            RoverDirection = direction;
            Commands = commands;
            PlateauX = plateauX;
            PlateauY = plateauY;
            Id = id;
            
        }
        //Moving rover with its commands.
        public void StartMoving(List<Rover> rovers)
        {
            rovers = rovers.Where(p =>p.Id !=Id).ToList();
            var eachCommand = Commands.ToCharArray();
            foreach (var cmmd in eachCommand)
            {
                switch (cmmd)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move(rovers);
                        break;
                    default:
                        throw new Exception("Undefined parameter exception");
                }
            }
        }
        //Move rover with specific command.
        public void Move(List<Rover> rovers)
        {
            CheckMoving();
            if (RoverDirection == "N")
            {
                RoverYCoordinate += 1;
            }
            else if (RoverDirection == "S")
            {
                RoverYCoordinate -= 1;
            }
            else if(RoverDirection == "E")
            {
                RoverXCoordinate += 1;
            }
            else if(RoverDirection == "W")
            {
                RoverXCoordinate -= 1;
            }
            //If rover has any obstacle on his way it will crash.
            if(rovers.Any(p=>p.RoverXCoordinate == RoverXCoordinate && p.RoverYCoordinate == RoverYCoordinate))
            {
                var collidedRover = rovers.Where(p => p.RoverXCoordinate == RoverXCoordinate && p.RoverYCoordinate == RoverYCoordinate).FirstOrDefault();
                throw new Exception("Rover " + Id + " collided with Rover " + collidedRover.Id);
            }
        }
        //Turning Left 90 degree.
        public void TurnLeft()
        {
            if(RoverDirection == "N")
            {
                RoverDirection = "W";
            }
            else if (RoverDirection == "W")
            {
                RoverDirection = "S";
            }
            else if(RoverDirection == "S")
            {
                RoverDirection = "E";
            }
            else if (RoverDirection == "E")
            {
                RoverDirection = "N";
            }
        }
        //Turning Right 90 degree.
        public void TurnRight()
        {
            if (RoverDirection == "N")
            {
                RoverDirection = "E";
            }
            else if (RoverDirection == "W")
            {
                RoverDirection = "N";
            }
            else if (RoverDirection == "S")
            {
                RoverDirection = "W";
            }
            else if (RoverDirection == "E")
            {
                RoverDirection = "S";
            }
        }
        //Checking rover for not exceeding plateau limits.
        public void CheckMoving()
        {
            #region X>0 and Y>0
            if (PlateauX > 0 && PlateauY > 0)
            {
                if (RoverDirection == "N")
                {
                    if ((RoverYCoordinate + 1) > PlateauY)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "S")
                {
                    if ((RoverYCoordinate - 1) < 0)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "E")
                {
                    if ((RoverXCoordinate + 1) > PlateauX)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "W")
                {
                    if ((RoverXCoordinate - 1) < 0)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
            }
            #endregion
            #region X<0 and Y>0
            else if (PlateauX < 0 && PlateauY > 0)
            {
                if (RoverDirection == "N")
                {
                    if ((RoverYCoordinate + 1) > PlateauY)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "S")
                {
                    if ((RoverYCoordinate - 1) < 0)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "E")
                {
                    if ((RoverXCoordinate + 1) > 0)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "W")
                {
                    if ((RoverXCoordinate - 1) < PlateauX)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
            }
            #endregion
            #region X<0 and Y<0
            else if (PlateauX < 0 && PlateauY < 0)
            {
                if (RoverDirection == "N")
                {
                    if ((RoverYCoordinate + 1) > 0)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "S")
                {
                    if ((RoverYCoordinate - 1) < PlateauY)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "E")
                {
                    if ((RoverXCoordinate + 1) > 0)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "W")
                {
                    if ((RoverXCoordinate - 1) < PlateauX)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
            }
            #endregion
            #region X>0 and Y<0
            else if (PlateauX > 0 && PlateauY < 0)
            {
                if (RoverDirection == "N")
                {
                    if ((RoverYCoordinate + 1) > 0)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "S")
                {
                    if ((RoverYCoordinate - 1) < PlateauY)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "E")
                {
                    if ((RoverXCoordinate + 1) > PlateauX)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
                else if (RoverDirection == "W")
                {
                    if ((RoverXCoordinate - 1) < 0)
                    {
                        throw new Exception("Cannot exceed Plateau!");
                    }
                }
            }
            #endregion
        }
        // If rover outside of plateau cannot be created.
        public void CheckInitialize(int plateauX, int plateauY,int x, int y)
        {
            #region X>0 and Y>0
            if (plateauX > 0 && plateauY > 0)
            {
                if (x > plateauX || y > plateauY || x < 0 || y < 0)
                {
                    throw new Exception("Rover must be inside Plateau");
                }
            }
            #endregion
            #region X<0 and Y>0
            else if (plateauX < 0 && plateauY > 0)
            {
                if (x > 0 || y > plateauY || x < plateauX || y < 0)
                {
                    throw new Exception("Rover must be inside Plateau");
                }
            }
            #endregion
            #region X<0 and Y<0
            else if (plateauX < 0 && plateauY < 0)
            {
                if (x > 0 || y > 0 || x < plateauX || y < plateauY)
                {
                    throw new Exception("Rover must be inside Plateau");
                }
            }
            #endregion
            #region X>0 and Y<0
            else if (plateauX > 0 && plateauY < 0)
            {
                if (x > plateauX || y > 0 || x < 0 || y < plateauY)
                {
                    throw new Exception("Rover must be inside Plateau");
                }
            }
            #endregion
        }
    }
}
