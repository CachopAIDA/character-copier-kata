using Moq;
using Xunit;

namespace CharacterCopierKata.Tests
{
    public class CopierShould
    {
        [Fact]
        public void copy_content_from_source_and_destination_with_1_char()
        {
            var source = Mock.Of<ISource>();
            var destination = Mock.Of<IDestination>();
            Mock.Get(source).Setup(s => s.GetContent()).Returns("a");

            var copier = new Copier(source, destination);
            copier.Copy();

            Mock.Get(destination).Verify(d => d.SetContent(It.IsAny<string>()), Times.Once);
            Mock.Get(source).Verify(s => s.GetContent(), Times.Once);
        }

        [Fact]
        public void copy_from_source_and_destination_with_2_char()
        {
            var source = Mock.Of<ISource>();
            var destination = Mock.Of<IDestination>();
            Mock.Get(source).Setup(s => s.GetContent()).Returns("ab");

            var copier = new Copier(source, destination);
            copier.Copy();

            Mock.Get(destination).Verify(d => d.SetContent(It.IsAny<string>()), Times.Exactly(2));
            Mock.Get(source).Verify(s => s.GetContent(), Times.Once);
        }
    }
}