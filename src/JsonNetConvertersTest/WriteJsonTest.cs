using System;
using System.Collections.Generic;
using System.Text;
using JsonNetConverters.Boolean;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace JsonNetConvertersTest
{
    public class WriteJsonTest
    {
        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 0)]
        public void WriteJson_NullableInput_Success(bool? input, int result)
        {
            //Arrange
            var converter = new BooleanConverter();
            var jsonWriterMock = new Mock<JsonWriter>();

            //Act
            converter.WriteJson(jsonWriterMock.Object, input, null);

            //Arrange
            jsonWriterMock.Verify(x => x.WriteValue(result));
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 0)]
        public void WriteJson_NonNullableInput_Success(bool input, int result)
        {
            //Arrange
            var converter = new BooleanConverter();
            var jsonWriterMock = new Mock<JsonWriter>();

            //Act
            converter.WriteJson(jsonWriterMock.Object, input, null);

            //Arrange
            jsonWriterMock.Verify(x => x.WriteValue(result));
        }
    }
}
