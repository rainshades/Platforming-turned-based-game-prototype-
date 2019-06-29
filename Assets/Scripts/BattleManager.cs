using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    GameManager gm;
    TurnManager tm;

    Deck playDeck;

    [SerializeField]
    List<SpellCard> SpellsDisplay = new List<SpellCard>();

    [SerializeField]
    List<SpellCard> HandDisplay = new List<SpellCard>();

    public List<Monster> EnemyMonsters;

    public GameObject monPrefab;
    public GameObject cardPrefab;

    public Transform[] SpawnPoints;
    public Transform[] EnemySpawnPoints;

    public Transform HandObject;

    MonsterObject CurrentMonster;

    [SerializeField]
    List<MonsterObject> AllyField;
    [SerializeField]
    List<MonsterObject> EnemyField;

    Party AllyParty;
    Party EnemyParty;

    Deck AllyDeck;
    Deck EnemyDeck;

    void Start()
    {
        
        gm = FindObjectOfType<GameManager>();
        tm = FindObjectOfType<TurnManager>();
         
        AllyParty = gm.currentParty;
        playDeck = gm.currentDeck;
        EnemyParty = new Party("GRR");
        EnemyParty.Add(EnemyMonsters[0]); //EnemyParty.Add(EnemyMonsters[1]); EnemyParty.Add(EnemyMonsters[2]);

        SpellsDisplay = playDeck.spells;
        HandDisplay = playDeck.Hand;

        for (int i = 0; i < AllyParty.PartyMembers.Count; i++)
        {
            monPrefab.GetComponent<MonsterObject>().thisMonster = AllyParty.PartyMembers[i];
            GameObject nw = Instantiate(monPrefab,SpawnPoints[i].position, SpawnPoints[i].rotation, SpawnPoints[i]);
            tm.TurnOrder.Add(nw.GetComponent<MonsterObject>());
            //Debug.Log("Spawn #" + i); 
        }
        for(int i = 0; i < EnemyParty.PartyMembers.Count; i++)
        {
            monPrefab.GetComponent<MonsterObject>().thisMonster = EnemyParty.PartyMembers[i];
            GameObject nw = Instantiate(monPrefab, EnemySpawnPoints[i].position, EnemySpawnPoints[i].rotation, EnemySpawnPoints[i]);
            tm.TurnOrder.Add(nw.GetComponent<MonsterObject>());
            //Debug.Log("Enemy Spawn #" + i);
        }
    }

    void Update()
    {
        tm.determineTurnOrder(tm.TurnOrder);
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
    
    public void SelectSpell(SpellObject s)
    {

    }


}