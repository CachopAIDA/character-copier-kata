using System;
using Xunit;

namespace CharacterCopierKata.Tests
{
    public class CopierShould
    {
        [Fact]
        public void copy_the_first_character_of_source_into_destination()
        {
            const string content = "a";

            var source = new SourceFake(content);
            var destination = new DestinationFake();
            var copier = new Copier(source, destination);

            copier.Copy();

            Assert.Equal(destination.Content, source.Content);
        }

        [Fact]
        public void throw_exception_when_source_is_empty()
        {
            var sourceEmptyFake = new SourceEmptyFake();
            var destination = new DestinationFake();
            var copier = new Copier(sourceEmptyFake, destination);

            var exception = Assert.Throws<Exception>(() => copier.Copy());
            Assert.Equal("The source is empty", exception.Message);
        }
    }

    public class SourceEmptyFake : ISource
    {
        public char Next()
        {
            throw new Exception();
        }
    }

    public class SourceFake : ISource
    {
        public SourceFake(string content)
        {
            this.Content = content;
        }
        public string Content { get; }

        public char Next()
        {
            return Content[0];
        }
    }

    public class DestinationFake : IDestination
    {
        public string Content { get; private set; }

        public void Append(char character)
        {
            Content = character.ToString();
        }
    }
}