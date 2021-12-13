using System;
using System.Linq;
using System.Security.Cryptography;
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

        [Fact]
        public void copy_full_source_content_to_destination()
        {
            const string content = "content";
            var source = new FullSourceFake(content);
            var destination = new FullDestinationFake();
            var copier = new Copier(source, destination);

            copier.Copy();
            
            Assert.Equal(destination.Content, source.Content);
        }
    }

    public class FullDestinationFake : DestinationFake
    {
        public override void Append(char character)
        {
            base.Content += character;
        }
    }

    public class FullSourceFake : SourceFake
    {
        private int index = 0;

        public FullSourceFake(string content) : base(content)
        {
        }

        public override char Next()
        {
            return base.Content[index++];
        }

        public override bool HasNext()
        {
            return index < base.Content.Length;
        }
    }

    public class SourceEmptyFake : ISource
    {
        public char Next()
        {
            throw new Exception();
        }

        public bool HasNext()
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

        public virtual char Next()
        {
            return Content[0];
        }

        public virtual bool HasNext()
        {
            return false;
        }
    }

    public class DestinationFake : IDestination
    {
        public string Content { get; protected set; }

        public virtual void Append(char character)
        {
            Content = character.ToString();
        }
    }
}