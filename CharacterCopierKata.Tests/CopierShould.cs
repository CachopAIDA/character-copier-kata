using System.Runtime.InteropServices;
using Moq;
using Xunit;

namespace CharacterCopierKata.Tests
{
    public class CopierShould
    {

        private readonly ISource source;
        private readonly IDestination destination;

        public CopierShould()
        {
            this.source = Mock.Of<ISource>();
            this.destination = Mock.Of<IDestination>();
        }

        private void CallCopy(string stringToCopy)
        {
            Mock.Get(source).Setup(s => s.GetContent()).Returns(stringToCopy);

            var copier = new Copier(source, destination);
            copier.Copy();
        }

        [Theory]
        [InlineData("a", 1)]
        [InlineData("ab", 2)]
        public void copy_content_from_source_and_destination_with_1_char(string stringToCopy, int destinationTimes)
        {
            CallCopy(stringToCopy);

            Mock.Get(destination).Verify(d => d.SetContent(It.IsAny<string>()), Times.Exactly(destinationTimes));
            Mock.Get(source).Verify(s => s.GetContent(), Times.Once);
        }

        [Fact]
        public void copy_the_characters_of_asdf_in_destination()
        {
            CallCopy("asdf");

            Mock.Get(destination).Verify(d => d.SetContent(It.Is<string>(s=> s == "a")), Times.Once());
            Mock.Get(destination).Verify(d => d.SetContent(It.Is<string>(s => s == "s")), Times.Once());
            Mock.Get(destination).Verify(d => d.SetContent(It.Is<string>(s => s == "d")), Times.Once());
            Mock.Get(destination).Verify(d => d.SetContent(It.Is<string>(s => s == "f")), Times.Once());
        }

        [Fact]
        public void when_source_is_empty_destination_is_not_called()
        {
            CallCopy("");

            Mock.Get(destination).Verify(d => d.SetContent(It.IsAny<string>()), Times.Never);
        }
    }
}