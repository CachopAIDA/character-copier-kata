using System;

namespace CharacterCopierKata
{
    public class Copier
    {
        private ISource source;
        private IDestination destination;

        public Copier(ISource source, IDestination destination)
        {
            this.destination = destination;
            this.source = source;
        }

        public void Copy()
        {
            foreach ( var _ in source.GetContent())
            {
                destination.SetContent(source.GetContentOneToOne().ToString());
            }
        }
    }
}