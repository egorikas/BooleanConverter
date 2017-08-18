using System;
using JsonNetConverters.Boolean;
using Newtonsoft.Json;
using Xunit;
using Moq;

namespace JsonNetConvertersTest
{
    public class ReadJsonTest
    {
        [Theory]
        [InlineData("1", JsonToken.String, true)]
        [InlineData("0", JsonToken.String, false)]
        [InlineData(1, JsonToken.Integer, true)]
        [InlineData(0, JsonToken.Integer, false)]
        public void ReadJson_ValidInput_SuccessResult(string input, JsonToken type, bool expectedResult)
        {
            //Arrange
            var converter = new BooleanConverter();
            var jsonReaderMock = new Mock<JsonReader>();
            jsonReaderMock.SetupGet(x => x.TokenType).Returns(type);
            jsonReaderMock.SetupGet(x => x.Value).Returns(input);

            //Act
            var result = converter.ReadJson(jsonReaderMock.Object, null, null, null);

            //Arrange
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void ReadJson_InputNotInteger_ExceptionThrown()
        {
            //Arrange
            var converter = new BooleanConverter();
            var jsonReaderMock = new Mock<JsonReader>();
            jsonReaderMock.SetupGet(x => x.TokenType).Returns(JsonToken.Float);

            //Act
            var ex = Assert.Throws<ArgumentException>(
                () => converter.ReadJson(jsonReaderMock.Object, null, false, null));

            //Arrange
            Assert.Equal(ex.Message, "Unexpected token. Integer or String was expected, got Float");
        }

        [Theory]
        [InlineData(JsonToken.Integer)]
        [InlineData(JsonToken.String)]
        public void ReadJson_ValidTokenInvalidResult_ExceptionThrown(JsonToken tokenType)
        {
            //Arrange
            var converter = new BooleanConverter();
            var jsonReaderMock = new Mock<JsonReader>();
            jsonReaderMock.SetupGet(x => x.TokenType).Returns(tokenType);
            jsonReaderMock.SetupGet(x => x.Value).Returns("wrongValue");

            //Act
            var ex = Assert.Throws<ArgumentException>(
                () => converter.ReadJson(jsonReaderMock.Object, null, false, null));

            //Arrange
            Assert.Equal(ex.Message, "wrongValue isn't a number");
        }

        [Fact]
        public void ReadJson_MoreThan0_ExceptionThrown()
        {
            //Arrange
            var converter = new BooleanConverter();
            var jsonReaderMock = new Mock<JsonReader>();
            jsonReaderMock.SetupGet(x => x.TokenType).Returns(JsonToken.Integer);
            jsonReaderMock.SetupGet(x => x.Value).Returns(3);

            //Act
            var ex = Assert.Throws<ArgumentException>(
                () => converter.ReadJson(jsonReaderMock.Object, null, false, null));

            //Arrange
            Assert.Equal(ex.Message, "Input value should be 1 or 0");
        }
    }
}
