﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add dependecies
using NUnit.Framework;
using Factorizor.BLL;
using NUnit.Framework.Internal;

//provide 3 test cases for each BLL class' logic.
namespace Factorizor.Tests
{
    [TestFixture]
    public class Factorizor
    {
        [TestCase(28, true)]
        [TestCase(487, false)]
        [TestCase(-3, false)]
        public void PerfectTests(int x, bool expected)
        {
            PerfectChecker perfect = new PerfectChecker();
            bool result = perfect.IsPerfect(x);

            Assert.AreEqual(expected, result);
        }

        [TestCase(11, true)]
        [TestCase(16, false)]
        [TestCase(-3, false)]
        public void PrimeTests(int x, bool expected)
        {
            PrimeChecker prime = new PrimeChecker();
            bool result = prime.IsPrime(x);

            Assert.AreEqual(expected, result);
        }
    }
}
