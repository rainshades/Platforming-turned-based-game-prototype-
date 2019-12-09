using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



namespace Albatross
{
    public class BattleManager : MonoBehaviour
    {
        GameManager gm;
        TurnManager tm;
        TargetUI TargetUI;
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
            TargetUI = FindObjectOfType<TargetUI>();

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
                    EnemyField.RemoveAt(i);
                }               
            }

            for(int i = 0; i < AllyField.Count; i++)
            {
                if (AllyField[i].health > 1)
                {
                    TargetUI.GetHPObjects()[i].GetComponent<Text>().text = "HP: " + AllyField[i].health;
                }
                if(AllyField[i].health <= 1 && AllyField[i] != null)
                {
                    TargetUI.GetHPObjects()[i].GetComponent<Text>().text = "HP: " + 0;
                    AllyField.RemoveAt(i);
                }
            }
            
            switch (AllyField.Count)
            {
                case 1:
                    if (AllyField[0].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }//Loads the beginning of the Level
                    break;
                case 2:
                    if (AllyField[0].health == 0 && AllyField[1].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }//Loads the beginning of the Level
                    break;
                case 3:
                    if (AllyField[0].health == 0 && AllyField[1].health == 0 && AllyField[2].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }//Loads the beginning of the Level
                    break;
                
            }
            switch (EnemyField.Count)
            {
                case 1:
                    if (EnemyField[0].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }//Loads where the player was before the battle, the enemy defeated.
                     //Sets the players party health to the same amount of health they had at the end of the battle
                     //If one of party members died it sets them to 1hp
                    break;
                case 2:
                    if (EnemyField[0].health == 0 && EnemyField[1].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }//Loads where the player was before the battle, the enemy defeated.
                     //Sets the players party health to the same amount of health they had at the end of the battle
                     //If one of party members died it sets them to 1hp
                    break;
                case 3:
                    if (EnemyField[0].health == 0 && EnemyField[1].health == 0 && EnemyField[2].health == 0)
                    {
                        SceneManager.LoadScene(PostBattleScene);
                    }//Loads where the player was before the battle, the enemy defeated.
                     //Sets the players party health to the same amount of health they had at the end of the battle
                     //If one of party members died it sets them to 1hp
                    break;
            }
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