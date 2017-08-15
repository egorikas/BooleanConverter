using System;
using System.Collections.Generic;
using System.Text;
using JsonNetConverters.Boolean;
using Newtonsoft.Json;
using Xunit;
using Moq;

namespace JsonNetConvertersTest
{
    public class ReadJsonTest
    {
        [Theory]
        [InlineData("1", true)]
        [InlineData("0", false)]
        public void ReadJson_ValidInput_SuccessResult(string input, bool expectedResult)
        {
            //Arrange
            var converter = new BooleanConverter();
            var jsonReaderMock = new Mock<JsonReader>();
            jsonReaderMock.SetupGet(x => x.TokenType).Returns(JsonToken.String);
            jsonReaderMock.SetupGet(x => x.Value).Returns("wrongInput");

            //Act
            //var result = converter.ReadJson()
        }
    }
}
