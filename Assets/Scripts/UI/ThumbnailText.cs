using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailText: MonoBehaviour
{
    // S is called before the first frame update
    void Start()
    {
        MonsterObject mon = GetComponentInParent<MonsterObject>();
        Text thistext = GetComponent<Text>();
        thistext.text = mon.name;
    }
}
