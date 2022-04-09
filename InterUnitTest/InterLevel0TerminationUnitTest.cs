using Inter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace InterUnitTest
{
    [TestClass]
    public class InterLevel0TerminationUnitTest
    {
        public static Dictionary<string, TerminationState> Paths { get; } = new()
        {
            { "datas/terminates/number.txt", TerminationState.TERMINATES },
            { "datas/runsForever/loop.txt", TerminationState.RUNS_FOREVER }
        };

        [TestMethod]
        public void Test()
        {
            foreach (var entry in Paths)
            {
                if (entry.Value == TerminationState.TERMINATES)
                    Program.Main(new string[] { entry.Key });
                else
                    Assert.ThrowsException<Exception>(() => Program.Main(new string[] { entry.Key }));
            }
        }
    }
}
