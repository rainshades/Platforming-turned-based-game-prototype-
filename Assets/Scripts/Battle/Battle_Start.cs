using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle_Start : MonoBehaviour
{
    OverworldEnemy em;
    GameManager gm;
    void Awake()
    {
        em = transform.GetComponent<OverworldEnemy>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.tag == "Player")
        {
            gm = FindObjectOfType<GameManager>();
            gm.enemyParty = em.party;
            gm.enemyDeck = em.deck;
            SceneManager.LoadScene("BattleScene");
        }
    }
}
