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
    }

    public class SourceFake : ISource
    {
        public SourceFake(string content)
        {
            this.Content = content;
        }
        public string Content { get; set; }

        public char Next()
        {
            return Content[0];
        }
    }

    public class DestinationFake : IDestination
    {
        public string Content { get; set; }

        public void Append(char character)
        {
            Content = character.ToString();
        }
    }
}