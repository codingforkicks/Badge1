using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Battleship.Tests
{
    [TestFixture]
    class InputTests
    {
        [TestCase("A10", true)]
        [TestCase("J9", true)]
        [TestCase("F", false)]
        [TestCase("C14", false)]
        [TestCase("AA1", false)]
        [TestCase("G111", false)]
        [TestCase("4", false)]
        [TestCase("73", false)]
        public void isValid(string coordinates, bool actual)
        {
            bool pass;
            //check if length of input is correct length
            if (coordinates.Length < 2 || coordinates.Length > 3)
            {
                pass = false;
                Assert.AreEqual(pass, actual);
            }

            //grab first letter and subseqent input
            string row = coordinates.Substring(0, 1);
            string column = coordinates.Substring(1, coordinates.Length - 1);

            //check if first letter is A-J and following is 1-10
            if (Regex.Matches(row, @"[a-j,A-J]").Count > 0)
            {
                if (Regex.Matches(column, @"([1-9]|10)").Count > 0)
                {
                    if (int.TryParse(column, out int num))
                    {
                        if(num <= 10)
                        {
                            pass = true;
                            Assert.AreEqual(pass, actual);
                        }
                    }
                }
            }
        }
    }
}
