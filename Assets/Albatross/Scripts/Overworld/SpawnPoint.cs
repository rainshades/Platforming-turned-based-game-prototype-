using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns in the character at the begining of the leevl. 
/// </summary>


public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        Player.transform.position = transform.position;
        Instantiate(Player);
    }
}
