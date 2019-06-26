using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    GameManager gm;
    TurnManager tm;

    Phase currentPhase;

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

    [SerializeField]
    List<MonsterObject> TurnOrder = new List<MonsterObject>();

    Party AllyParty;
    Party EnemyParty;

    Deck AllyDeck;
    Deck EnemyDeck;

    void Start()
    {
        
        gm = FindObjectOfType<GameManager>();
        tm = FindObjectOfType<TurnManager>();

        currentPhase = tm.currentPhase;
         
        AllyParty = gm.currentParty;
        playDeck = gm.currentDeck;
        EnemyParty = new Party("GRR");
        EnemyParty.Add(EnemyMonsters[0]); //EnemyParty.Add(EnemyMonsters[1]); EnemyParty.Add(EnemyMonsters[2]);

        SpellsDisplay = playDeck.spells;
        HandDisplay = playDeck.Hand;

        for(int i = 0; i < 6; i++)
        {
            playDeck.DrawCard();
            GameObject nw = Instantiate(cardPrefab, HandObject);   
        }

        for (int i = 0; i < AllyParty.PartyMembers.Count; i++)
        {
            monPrefab.GetComponent<MonsterObject>().thisMonster = AllyParty.PartyMembers[i];
            GameObject nw = Instantiate(monPrefab,SpawnPoints[i].position, SpawnPoints[i].rotation, SpawnPoints[i]);
            //Debug.Log("Spawn #" + i); 
        }
        for(int i = 0; i < EnemyParty.PartyMembers.Count; i++)
        {
            monPrefab.GetComponent<MonsterObject>().thisMonster = EnemyParty.PartyMembers[i];
            GameObject nw = Instantiate(monPrefab, EnemySpawnPoints[i].position, EnemySpawnPoints[i].rotation, EnemySpawnPoints[i]);
            //Debug.Log("Enemy Spawn #" + i);
        }
    }

    void Update()
    {

    }

    public Phase getPhase()
    {
        return currentPhase;
    }

    public List<MonsterObject> DetermineTurnOrder(Party A, Party B)
    {
        List<MonsterObject> tmp;
        for(int i = 0; i < A.PartyMembers.Count; i ++)
        {

        }
        return null;
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

class OldBattleManager: MonoBehaviour
{

    public GameManager gm;

    public Text HelperMessage;
    public int TurnNumber;

    [SerializeField]
    Phase currPhase = Phase.Start;

    [SerializeField]
    MonsterObject mon;

    [SerializeField]
    int currMon;

    [SerializeField]
    MonsterObject MonSelected;

    [SerializeField]
    MonsterObject Targetmon;

    [SerializeField]
    bool canMonAct;

    [SerializeField]
    SpellObject SpellSelected;

    public bool isAttacking;
    public bool isUsingAbility;
    public bool isCastingSpell;

    // Start is called before the first frame update
    void Start()
    {
        setTurnOrder();
    }

    // Update is called once per frame
    void Update()
    {
        gm = FindObjectOfType<GameManager>();

        if (mon.ownedByPlayer)
        {
            switch (currPhase)
            {
                case Phase.Start:
                    HelperMessage.text = "It is currently " + mon.name + "'s turn";
                    Targetmon = null;
                    currPhase = currPhase.NextPhase();
                    break;
                case Phase.Draw:
                    Debug.Log("Draw");
                    currPhase = currPhase.NextPhase();
                    break;
                case Phase.Battle:
                    canMonAct = mon.getCanAct();
                    break;
                case Phase.End:
                    TurnNumber++;
                    currPhase = currPhase.NextPhase();
                    break;
                default:
                    Debug.Log("Something Went wrong");
                    break;
            }
        }
        else //Temporary- Meant to take the place of the AI taking a round
        {
            switch (currPhase)
            {
                case Phase.Start:
                    currPhase = Phase.Battle;
                    Debug.Log("Enemy Start");
                    break;
                case Phase.Battle:
                    currPhase = currPhase.NextPhase();
                    Debug.Log("Enemy Battle");
                    break;
                case Phase.End:
                    TurnNumber++;
                    currMon = 0;
                    currPhase = currPhase.NextPhase();
                    Debug.Log("Enemy Turn Over");
                    break;
                default:
                    Debug.Log("Something Went wrong");
                    break;
            }
        }
    }
    void setTurnOrder()
    {
    }

    public void EndTurn()
    {
    }

    public void AttackButton()
    {
        mon.setCanAct(true);
        isAttacking = true;
        isUsingAbility = false;
        HelperMessage.text = "Select a monster to Attack";
    }

    public void AbilityButton()
    {
        mon.setCanAct(true);
        isUsingAbility = true;
        isAttacking = false;
        HelperMessage.text = "Select Target";
    }
    public void AttackPrompt(MonsterObject target)
    {
        HelperMessage.text = "Would you like to attack: " + Targetmon.name;
    }

    public void AbilityPrompt(MonsterObject target)
    {
        HelperMessage.text = "You activate " + mon.name + "'s ability on " + Targetmon.name;
    }

    public void Attack()
    {
        Targetmon.health -= mon.attack;
        EndTurn();
    }
    public void Ability()
    {
        EndTurn();
    }

    public void SelectMonster(MonsterObject target)
    {
        if (!mon.getCanAct() || target.transform == mon.transform)
        {
            MonSelected = target;
        }
        else if (target.transform != mon.transform)
        {
            Targetmon = target;
            if (isAttacking)
            {
                HelperMessage.text = mon.name + " is attacking " + Targetmon.name;
                Targetmon.health -= mon.attack;
                EndTurn();
            }
            if (isUsingAbility)
            {
                HelperMessage.text = mon.name + " is using it's ability on " + Targetmon.name;
                EndTurn();
            }
            if (isCastingSpell)
            {
                HelperMessage.text = mon.name + " is casting a spell on " + Targetmon.name;
                Destroy(SpellSelected.gameObject);
                EndTurn();
            }
        }
    }

    public void SelectSpell(SpellObject so)
    {
        SpellSelected = so;
        HelperMessage.text = "select a target";
    }

    public SpellObject getCurrentSpell()
    {
        return SpellSelected;
    }

    public MonsterObject getCurrentMonster()
    {
        return MonSelected;
    }


}