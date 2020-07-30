using System.Collections.Generic;

namespace Albatross
{
    [System.Serializable]
    public class Deck
    {
        public List<SpellCard> Spells;
        public string Name;

        public void Add(SpellCard sc)
        {
            Spells.Add(sc);
        }

        public Deck()
        {
            Spells = new List<SpellCard>();
            Name = "Deck";
        }

        public Deck(string name)
        {
            Spells = new List<SpellCard>();
            this.Name = name;
        }
    }
}