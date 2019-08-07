using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle_Start : MonoBehaviour
{
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
