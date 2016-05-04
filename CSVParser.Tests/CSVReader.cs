using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace UnitTestProject1
{
    [TestClass]
    public class CSVReader
    {
        [TestMethod]
        public void WhenParserIsInvokedItDoesNotReturnNull()
        {
            var testLine = @"Aleshia,Tomkiewicz,Alan D Rosenburg Cpa Pc,14 Taylor St,St.Stephens Ward,Kent,CT2 7PP,01835 - 703597,01944 - 369967,atomkiewicz @hotmail.com,http://www.alandrosenburgcpapc.co.uk";

            var parser = new Service.CSVReader();
            var parsedValue = parser.ParseLine(testLine);

            Assert.IsNotNull(parsedValue);

        }


        [TestMethod]
        public void WhenParserIsInvokedItParses()
        {
            var testLine = "\"Aleshia\",\"Tomkiewicz\",\"Alan D Rosenburg Cpa Pc\",\"14 Taylor St\",\"St.Stephens Ward\",\"Kent\",\"CT2 7PP\",\"01835 - 703597\",\"01944 - 369967\",\"atomkiewicz @hotmail.com\",\"http://www.alandrosenburgcpapc.co.uk\"";
            var expectedValue = new[]
            {
                "Aleshia",
                "Tomkiewicz",
                "Alan D Rosenburg Cpa Pc",
                "14 Taylor St",
                "St.Stephens Ward",
                "Kent",
                "CT2 7PP",
                "01835 - 703597",
                "01944 - 369967",
                "atomkiewicz @hotmail.com",
                "http://www.alandrosenburgcpapc.co.uk"
            };

            var parser = new Service.CSVReader();
            var parsedValue = parser.ParseLine(testLine);

            CollectionAssert.AreEqual(expectedValue, parsedValue);
        }
    }
}
