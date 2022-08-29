using BarelyFunctionnal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BarelyFunctionnalUnitTest.level0
{
    [TestClass]
    public class Level0UnitTest
    {
        public void Test(List<string> files, bool expected)
        {
            if (expected)
                Program.Main(files.ToArray());
            else
                Assert.ThrowsException<Exception>(() => Program.Main(files.ToArray()));
        }

        [TestMethod]
        public void TestNumber()
        {
            Test(new() { "datas/terminates/number.txt" }, true);
        }

        [TestMethod]
        public void TestLoop()
        {
            Test(new() { "datas/runsForever/loop.txt" }, false);
        }

        [TestMethod]
        public void TestRotate()
        {
            Test(new() { "datas/terminates/rotate.txt" }, true);
        }
    }
}
