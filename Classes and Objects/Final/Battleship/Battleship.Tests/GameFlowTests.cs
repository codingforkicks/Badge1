using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    public class GameFlowTests
    {
        [TestCase ("A9")]
        [TestCase("J10")]
        public void GetShotCoordinates(string coordinates)
        {
            char row = coordinates[0];
            int column = int.Parse(coordinates.Remove(0, 1));
            int letterToNumber = (int)row % 32;

            Coordinate newCoordinate = new Coordinate(letterToNumber, column);

            int xCoordinate = newCoordinate.XCoordinate;
            int yCoordinate = newCoordinate.YCoordinate;

            Assert.AreEqual(letterToNumber, xCoordinate);
            Assert.AreEqual(column, yCoordinate);
        }
    }
}
