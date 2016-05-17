using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode_6;
using System.IO;

namespace AdventOfCode_6_Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Test_getData_NoFile()
        {
            int[] result = Program.parseFile("../../FileDoesNotExist.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_getData_malformedFile2()
        {
            int[] result = Program.parseFile("../../Test_Malformed.txt");
        }

        [TestMethod]
        public void Test_EmptyFile()
        {
            int[] result = Program.parseFile("../../Test_Empty.txt");
            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 0);
        }

        [TestMethod]
        public void Test_TurnOn()
        {
            int[] result = Program.parseFile("../../Test_TurnOn.txt");
            // 6,6 through 10,10 applied twice
            // should equal 25 lights on, and 50 brightness
            Assert.AreEqual(result[0], 25);
            Assert.AreEqual(result[1], 50);
        }

        [TestMethod]
        public void Test_TurnOff()
        {
            int[] result = Program.parseFile("../../Test_TurnOnThenOff.txt");
            // turns 5,5 through 10,10 on then 9,9 through 10,10 off twice
            // should have 36-4 = 32 lights on
            // should have 32 brightness too (no negatives)
            Assert.AreEqual(result[0], 32);
            Assert.AreEqual(result[1], 32);
        }

        [TestMethod]
        public void Test_Toggle()
        {
            int[] result = Program.parseFile("../../Test_Toggle.txt");
            // toggle 10,10 through 20,20 three times
            // should have 11*11 = 121 lights on
            // should have 11*11*2*3 = 726 brightness 
            Assert.AreEqual(result[0], 121);
            Assert.AreEqual(result[1], 726);
        }

        [TestMethod]
        public void Test_Different_Toggle()
        {
            int[] result = Program.parseFile("../../Test_MultiToggle.txt");
            // toggle 11,11 through 20,20 then 6,6 through 15,15
            // should have (10*10)+(10*10)-(5*5) = 150 lights on
            // should have 10*10*2*2 = 400 brightness
            Assert.AreEqual(result[0], 150);
            Assert.AreEqual(result[1], 400);
        }
    }
}
