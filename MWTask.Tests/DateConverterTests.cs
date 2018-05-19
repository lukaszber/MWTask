using System;
using MWTask.DateHandlers;
using MWTask.Interafes;
using NUnit.Framework;

namespace MWTask.Tests
{
    [TestFixture]
    public class DateConverterTests
    {
        private IDateConverter _dateConverter;

        [SetUp]
        public void SetUpCultureInfo()
        {
            _dateConverter = new DateConverter();
        }

        [TestCase("01.01.2017", "05.01.2017", "01-05.01.2017")]
        [TestCase("01.01.2017", "05.02.2017", "01.01-05.02.2017")]
        [TestCase("01.01.2016", "05.01.2017", "01.01.2016-05.01.2017")]

        public void GetDateRange_ReturnsCorrectRange(string firstDate, string secondDate, string expectedResult)
        {
            //Act
            var result = _dateConverter.GetDateRange(firstDate, secondDate);

            //Assert
            NUnit.Framework.Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("01.01.2016", "05-01-2017")]
        [TestCase("01-01-2016", "05.01.2017")]
        [TestCase("01.01.2016", "05.13.2017")]
        [TestCase("42.01.2016", "05.13.2017")]
        public void GetDateRange_ThrowsFormatException_WhenArgumentsAreInIncorrectFormat(string firstDate, string secondDate)
        {
            //Act & Assert
            Assert.Throws<FormatException>(() => _dateConverter.GetDateRange(firstDate, secondDate));
        }
    }
}
