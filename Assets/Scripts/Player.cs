using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gm;
    public Party p;
    public Deck d;

    List<Monster> PotentialPartyMembers = new List<Monster>();
    List<SpellCard> CardInventory = new List<SpellCard>();

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        
        if(gm == null)
        {
            gm = new GameManager();
        }

        gm.currentParty = p;
        gm.currentDeck = d;
    }

    public List<Monster>GetPotentialPartyMembers()
    {
        return PotentialPartyMembers;
    }

    public List<SpellCard> GetCardInventory()
    {
        return CardInventory;
    }
}
