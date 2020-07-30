using System.Collections.Generic;


namespace Albatross
{

    [System.Serializable]
    public class Party
    {
        public List<Monster> PartyMembers;
        public string Name;

        public void Add(Monster mon)
        {
            if (PartyMembers.Count < 3)
            {
                PartyMembers.Add(mon);
            }
        }

        public Party(string name)
        {
            PartyMembers = new List<Monster>();
            this.Name = name;
        }

        public Party()
        {
            PartyMembers = new List<Monster>();
        }
    }
}
