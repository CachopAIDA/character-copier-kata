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
                do
                {
                    var character = source.Next();
                    destination.Append(character);
                } while (source.HasNext());
            }
            catch 
            {
                throw new Exception("The source is empty");
            }
        }
    }
}