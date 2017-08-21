using JsonNetConverters.Boolean;
using Newtonsoft.Json;
using Xunit;

namespace JsonNetConvertersTest
{

    public class TestData
    {
        [JsonConverter(typeof(BooleanConverter))]
        public bool Field { get; set; }
    }
    public class IntegrationTest
    {
        [Theory]
        [InlineData("{ Field : 0}", false)]
        [InlineData("{ Field : 1}", true)]
        [InlineData("{ Field : \"0\"}", false)]
        [InlineData("{ Field : \"1\"}", true)]
        public void SerializeHappyPath(string input,bool expectedResult)
        {
            //Act
            var result = JsonConvert.DeserializeObject<TestData>(input);

            //Assert
            Assert.Equal(expectedResult, result.Field);
        }
    }
}
