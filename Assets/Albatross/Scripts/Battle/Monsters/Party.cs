using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{

    [System.Serializable]
    public class Party
    {
        public List<Monster> PartyMembers = new List<Monster>();
        public string name;

        public void Add(Monster mon)
        {
            if (PartyMembers.Count < 3)
            {
                PartyMembers.Add(mon);
            }
        }

        public Party(string name)
        {
            this.name = name;
        }

        public Party()
        {

        }
    }
}
