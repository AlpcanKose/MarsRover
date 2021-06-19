using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using System.Collections.Generic;
using System;

namespace MarsRoverUnitTest
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void TestingInputs()
        {
            int plateauX = 5;
            int plateauY = 5;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1,1, 2, "N", "LMLMLMLMM", plateauX, plateauY));
            rovers.Add(new Rover(2,3, 3, "E", "MMRMMRMRRM", plateauX, plateauY));

            foreach (var item in rovers)
            {
                item.StartMoving(rovers);
            }
            string testOutput = "";
            foreach (var item in rovers)
            {
                testOutput += (item.RoverXCoordinate + " " + item.RoverYCoordinate + " " + item.RoverDirection+ " ");
            }
            string expectedOutput = "1 3 N 5 1 E ";
            Assert.AreEqual(expectedOutput, testOutput);

        }
        [TestMethod]
        public void TestingInputs2()
        {
            int plateauX = 6;
            int plateauY = 6;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1, 0, 0, "N", "LLLMMMLMRM", plateauX, plateauY));

            foreach (var item in rovers)
            {
                item.StartMoving(rovers);
            }
            string testOutput = "";
            foreach (var item in rovers)
            {
                testOutput += (item.RoverXCoordinate + " " + item.RoverYCoordinate + " " + item.RoverDirection + " ");
            }
            string expectedOutput = "4 1 E ";
            Assert.AreEqual(expectedOutput, testOutput);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Rover must be inside Plateau")]
        public void OutsideOfPlateau1()
        {
            int plateauX = 5;
            int plateauY = 5;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1, 6, 2, "N", "LMLMLMLMM", plateauX, plateauY));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
           "Rover must be inside Plateau")]
        public void OutsideOfPlateau2()
        {
            int plateauX = -5;
            int plateauY = 5;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1, 1, 2, "N", "LMLMLMLMM", plateauX, plateauY));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
           "Rover must be inside Plateau")]
        public void OutsideOfPlateau3()
        {
            int plateauX = -5;
            int plateauY = 5;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1, -6, 2, "N", "LMLMLMLMM", plateauX, plateauY));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Undefined parameter exception")]
        public void UndefinedParameter()
        {
            int plateauX = 5;
            int plateauY = 5;
            Rover rover = new Rover(1, 1, 2, "N", "LMLMAMLMM", plateauX, plateauY);
            rover.StartMoving(new List<Rover>());
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Collision()
        {
            int plateauX = 5;
            int plateauY = 5;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1, 3, 3, "E", "MMRMMRMRRM", plateauX, plateauY));
            rovers.Add(new Rover(1, 4, 3, "E", "MMRMMRMRRM", plateauX, plateauY));
            foreach (var item in rovers)
            {
                item.StartMoving(rovers);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
           "Cannot exceed Plateau!")]
        public void ExceedingPlateau1()
        {
            int plateauX = 5;
            int plateauY = 5;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1, 0, 0, "S", "MMRMMRMRRM", plateauX, plateauY));
            foreach (var item in rovers)
            {
                item.StartMoving(rovers);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
           "Cannot exceed Plateau!")]
        public void ExceedingPlateau2()
        {
            int plateauX = -5;
            int plateauY = -5;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1, 0, 0, "N", "MMMMMM", plateauX, plateauY));
            foreach (var item in rovers)
            {
                item.StartMoving(rovers);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
           "Cannot exceed Plateau!")]
        public void ExceedingPlateau3()
        {
            int plateauX = -5;
            int plateauY = +5;
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover(1, 0, 0, "N", "MMLMMMMMMMM", plateauX, plateauY));
            foreach (var item in rovers)
            {
                item.StartMoving(rovers);
            }
        }

    }
}
