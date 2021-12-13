using System.Collections.Generic;
using Xunit;

namespace CharacterCopierKata.Tests
{
    public class CopierShould
    {
        [Fact]
        public void When_Copy_then_destination_is_equal_source()
        {
            const string content = "asasdas";
            SourceFake source = new SourceFake(content);
            DestinationFake destination = new DestinationFake();
            Assert.Equal(destination.Content, source.Content);
        }
    }
    public class SourceFake : ISource
    {
        public SourceFake(string content)
        {
            throw new System.NotImplementedException();
        }
        public string Content { get; set; }
    }
    public class DestinationFake : IDestination
    {
        public string Content { get; set; }
    }
}