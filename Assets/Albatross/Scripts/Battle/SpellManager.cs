using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albatross
{
    /// <summary>
    /// Manages Deck and the Spells effects and abilities on the Battle Scene
    /// </summary>
    public class SpellManager : MonoBehaviour
    {
        

        [SerializeField]
        SpellObject CurrentSelectedSpell = null;
        BattleUi battleui = null;

        public MonsterObject currentMonster;

        public GameObject PlayerHand;
        public GameObject PlayerDeckCounter; 

        GameManager gm = null; 

        public GameObject cardPrefab;

        [SerializeField]
        private Trigger CurrentTrigger = Trigger.NoTrigger;

        #region PlayDeck
        /// <summary>
        /// Handles Deck and Hand activities in Battle
        /// Draws, Discards, Refreshes, Shuffles
        /// Detects if certain types of Cards are in the hand or not. 
        /// </summary>
        [System.Serializable]
        internal class PlayDeck
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
                CardsInDiscard.Add(Spell.Spell);
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

        #endregion

        [SerializeField]
        PlayDeck AllyDeck;
        [SerializeField]
        PlayDeck EnemyDeck;

        public Trigger CurrentTrigger1 { get => CurrentTrigger; set => CurrentTrigger = value; }

        void Awake()
        {
            gm = FindObjectOfType<GameManager>();

            AllyDeck = new PlayDeck(gm.currentDeck.Spells);

            EnemyDeck = new PlayDeck(gm.GetEnemyDeck().Spells);

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
                go.GetComponent<SpellObject>().Spell = AllyDeck.CardsInDeck[0];
                AllyDeck.Draw();
                Instantiate(go, PlayerHand.transform);
            }
            if(AllyDeck.CardsInDeck.Count <= 0)
            {
                AllyDeck.Refresh();
            }

            SetTrigger(Trigger.Draw);
        }

        public Trigger GetTrigger()
        {
            return CurrentTrigger1;
        }

        public void SetTrigger(Trigger _newTrigger)
        {
            CurrentTrigger1 = _newTrigger;
        }
    }
}