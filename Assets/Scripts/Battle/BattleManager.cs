using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    GameManager gm;
    TurnManager tm;

    public string PostBattleScene;

    [SerializeField]
    List<SpellCard> SpellsDisplay = new List<SpellCard>();

    [SerializeField]
    List<SpellCard> HandDisplay = new List<SpellCard>();

    public List<SpellCard> Hand = new List<SpellCard>();

    public List<Monster> EnemyMonsters;

    public GameObject monPrefab;
    public GameObject cardPrefab;

    public Transform[] SpawnPoints;
    public Transform[] EnemySpawnPoints;

    public Transform HandObject;

    MonsterObject CurrentMonster;

    public List<MonsterObject> AllyField;
    public List<MonsterObject> EnemyField;

    Party AllyParty;
    Party EnemyParty;

    Deck AllyDeck;
    Deck EnemyDeck;

    void Start()
    {
        
        gm = FindObjectOfType<GameManager>();
        tm = FindObjectOfType<TurnManager>();
         
        AllyParty = gm.currentParty;
        AllyDeck = gm.currentDeck;

        

        SpellsDisplay = AllyDeck.spells;
        HandDisplay = Hand;

        for (int i = 0; i < AllyParty.PartyMembers.Count; i++)
        {
            monPrefab.GetComponent<MonsterObject>().thisMonster = AllyParty.PartyMembers[i];
            GameObject nw = Instantiate(monPrefab,SpawnPoints[i].position, SpawnPoints[i].rotation, SpawnPoints[i]);
            nw.GetComponent<MonsterObject>().ownedByPlayer = true;
            AllyField.Add(nw.GetComponent<MonsterObject>());
            tm.TurnOrder.Add(nw.GetComponent<MonsterObject>());
            //Debug.Log("Spawn #" + i); 
        }
        for(int i = 0; i < EnemyParty.PartyMembers.Count; i++)
        {
            monPrefab.GetComponent<MonsterObject>().thisMonster = EnemyParty.PartyMembers[i];
            GameObject nw = Instantiate(monPrefab, EnemySpawnPoints[i].position, EnemySpawnPoints[i].rotation, EnemySpawnPoints[i]);
            EnemyField.Add(nw.GetComponent<MonsterObject>());
            tm.TurnOrder.Add(nw.GetComponent<MonsterObject>());
            //Debug.Log("Enemy Spawn #" + i);
        }
    }

    void Update()
    {
        switch (EnemyField.Count) {
            case 1:
                if (EnemyField[0] == null)
                {
                    Debug.Log("You win!");
                    gm.SceneButton(PostBattleScene);
                }
                break;
            case 2:
                if (EnemyField[0] == null && EnemyField[1] == null)
                {
                    Debug.Log("You win!");
                    gm.SceneButton(PostBattleScene);
                }
                break;
            case 3:
                if (EnemyField[0] == null && EnemyField[1] == null && EnemyField[2] == null)
                {
                    Debug.Log("You win!");
                    gm.SceneButton(PostBattleScene);
                }
                break;
            default:
                Debug.Log("Umm There definately too many people (or too few) fuckers on this battlefield");
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

    public void setAllyParty(Party p)
    {
        AllyParty = p;
    }

    public void SetEnemyParty(Party p)
    {
        EnemyParty = p;
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