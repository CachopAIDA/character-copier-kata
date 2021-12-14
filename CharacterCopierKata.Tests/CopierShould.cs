using Moq;
using Xunit;

namespace CharacterCopierKata.Tests
{
    public class CopierShould
    {
        [Fact]
        public void copier_should_call_content_from_source_and_destination()
        {
            var source = Mock.Of<ISource>();
            var destination = Mock.Of<IDestination>();

            var copier = new Copier(source, destination);
            copier.Copy();

            Mock.Get(destination).Verify(d => d.SetContent(It.IsAny<string>()), Times.Once);
            Mock.Get(source).Verify(s => s.GetContent(), Times.Once);
        }
    }
}