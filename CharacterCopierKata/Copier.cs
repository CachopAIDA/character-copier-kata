using System;

namespace CharacterCopierKata
{
    public class Copier
    {
        private ISource source;
        private IDestination destination;

        public Copier(ISource source, IDestination destination)
        {
            this.source = source;
            this.destination = destination;
        }

        public void Copy()
        {
            try
            {
                var character = source.Next();
                destination.Append(character);
            }
            catch 
            {
                throw new Exception("The source is empty");
            }
        }
    }
}