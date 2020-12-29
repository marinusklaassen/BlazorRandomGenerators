using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomGenerators.Travesty.UnitTests
{
    [TestClass]
    public class TravestyGeneratorTests
    {
        private readonly string _fileDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

        [TestMethod]
        public void ProcessText_MiddlingGarbling()
        {
            var sampleTextPath = _fileDir + "/TravestyInput.txt";
            var sampleTextStreamReader = new StreamReader(sampleTextPath);
            var sampleText = sampleTextStreamReader.ReadToEnd();

            var travesty = new TravestyGenerator();
            travesty.RandomInt = new Random(0);

            var result = travesty.ProcessText(sampleText, 5);

            var expectedResultPath = _fileDir + "/TravestyExpectedResult.txt";
            var expectedResultStreamReader = new StreamReader(expectedResultPath);
            var expectedResultText = expectedResultStreamReader.ReadToEnd();

            Debug.WriteLine(expectedResultText);
            Debug.WriteLine(result);

            Assert.AreEqual(expectedResultText, result);
        }
    }
}
