using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add dependencies
using NUnit.Framework;
using SG.Calculator.BLL;

namespace SG.Calculator.Tests
{
    //notifies the test runner that this class has tests inside it
    [TestFixture]
    public class SimpleMathTests
    {
        //test
        [Test]
        public void IntegerDivision1()
        {
            SimpleMath math = new SimpleMath();
            int result = math.Divide(5, 2);

            Assert.AreEqual(2, result);
        }

        //multiple test case
        [TestCase(4, 2, 2)]
        [TestCase(13, 6, 2)]
        [TestCase(-20, 5, -4)]
        public void IntegerDivision(int x, int y, int expected)
        {
            SimpleMath math = new SimpleMath();
            int actual = math.Divide(x, y);

            Assert.AreEqual(expected, actual);
        }

        //error catching test
        [Test]
        public void DivideByZeroTest()
        {
            SimpleMath math = new SimpleMath();
            Assert.Throws<DivideByZeroException>(() => math.Divide(5, 0));
        }

        //reset test data: this prevents data from being remaipulated when testing
        [SetUp]
        public void Init()
        {
            // this code runs before each test
        }

        [TearDown]
        public void Cleanup()
        {
            // this code runs after each test
        }

    }
}
