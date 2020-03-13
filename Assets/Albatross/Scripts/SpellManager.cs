/* Project Albatross 
 * Prepared by Eddie Fulton
 * Purpose: Hold and Mangement of Spells to be used in the action script
 * Status: Member: Testing 
 */
 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Albatross
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField]
        SpellObject CurrentSelectedSpell = null;
        BattleUi battleui = null;

        [SerializeField]
        MonsterObject currentMonster;

        public GameObject PlayerHand;
        public GameObject PlayerDeckCounter; 

        GameManager gm = null; 

        public GameObject cardPrefab; 

        private class PlayDeck
        {
            public List<SpellCard> CardsInDeck = new List<SpellCard>();
            public List<SpellCard> CardsInHand = new List<SpellCard>();
            public List<SpellCard> CardsInDiscard = new List<SpellCard>();

            public PlayDeck(List<SpellCard> Deck)
            {
                CardsInDeck = Deck;
            }

            public void Draw()
            {
                CardsInHand.Add(CardsInDeck[0]);
                CardsInDeck.RemoveAt(0);
            }

            public void Discard(SpellObject Spell)
            {
                CardsInDiscard.Add(Spell.spell);
            }

            public void Refresh()
            {
                CardsInDeck = CardsInDiscard;
                CardsInDiscard.Clear();
                Shuffle();
            }

            public void Shuffle()
            {

            }

        }
        [SerializeField]
        PlayDeck AllyDeck;
        PlayDeck EnemyDeck; 

        void Awake()
        {
            TurnManager tm = FindObjectOfType<TurnManager>();
            gm = FindObjectOfType<GameManager>();
            currentMonster = tm.getCurrentMonster();


            AllyDeck = new PlayDeck(gm.currentDeck.spells);

            EnemyDeck = new PlayDeck(gm.enemyDeck.spells);

            DrawCard();
            DrawCard();
            DrawCard();

        }
        void Update()
        {
            PlayerDeckCounter.GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(""+AllyDeck.CardsInDeck.Count);
        }

        public void setSpell(SpellObject spell)
        {
            CurrentSelectedSpell = spell;
        }

        public SpellObject getCurrentSpell()
        {
            return CurrentSelectedSpell;
        }

        public void DrawCard()
        {
            if (AllyDeck.CardsInDeck.Count > 0)
            {
                GameObject go = cardPrefab;
                go.GetComponent<SpellObject>().spell = AllyDeck.CardsInDeck[0];
                AllyDeck.Draw();
                Instantiate(go, PlayerHand.transform);
            }
            if(AllyDeck.CardsInDeck.Count <= 0)
            {
                AllyDeck.Refresh();
            }
        }
    }
}