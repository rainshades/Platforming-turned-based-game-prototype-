using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Albatross
{
    public class BattleManager : MonoBehaviour
    {
        GameManager gm;
        TurnManager tm;
        FieldSpawner fs;

        public List<MonsterObject> AllyField;
        public List<MonsterObject> EnemyField;

        public string PostBattleScene;

        [SerializeField]
        List<SpellCard> SpellsDisplay = new List<SpellCard>();

        [SerializeField]
        List<SpellCard> HandDisplay = new List<SpellCard>();

        public List<SpellCard> Hand = new List<SpellCard>();

        [SerializeField]
        GameObject cardPrefab = null;
       
        public Transform HandObject = null;

        MonsterObject CurrentMonster = null;
      
        Deck AllyDeck = null;
        Deck EnemyDeck = null;
               
        void Start()
        {

            gm = FindObjectOfType<GameManager>();
            tm = FindObjectOfType<TurnManager>();
            fs = FindObjectOfType<FieldSpawner>();

            AllyField = fs.AllyField;
            AllyDeck = gm.currentDeck;

            EnemyField = fs.EnemyField;
            EnemyDeck = gm.enemyDeck;
        
            SpellsDisplay = AllyDeck.spells;
            HandDisplay = Hand;
        }

        void Update()
        {

            for(int i = 0; i < EnemyField.Count; i++)
            {
                if(EnemyField[i].health <= 0 && EnemyField[i] != null)
                {
                    Destroy(EnemyField[i].gameObject);
                }
            }

            for(int i = 0; i < AllyField.Count; i++)
            {
                if(AllyField[i].health <= 0 && AllyField[i] != null)
                {
                    AllyField[i].gameObject.SetActive(false);
                }
            }

            if(AllyField.Count == 0)
            {

            }//Loads the beginning of the Level

            if(EnemyField.Count == 0)
            {

            }//Loads where the player was before the battle, the enemy defeated.
             //Sets the players party health to the same amount of health they had at the end of the battle
             //If one of party members died it sets them to 1hp
        }

        public void setAllyDeck(Deck d)
        {
            AllyDeck = d;
        }

        public void setEnemyDeck(Deck d)
        {
            EnemyDeck = d;
        }

        public void DrawCard()
        {
            if (AllyDeck.spells.Count > 0)
            {
                Hand.Add(AllyDeck.spells[0]);
                cardPrefab.GetComponent<SpellObject>().spell = AllyDeck.spells[0];

                AllyDeck.spells.RemoveAt(0);
                GameObject nw = Instantiate(cardPrefab, HandObject);
            }
        }
    }
}