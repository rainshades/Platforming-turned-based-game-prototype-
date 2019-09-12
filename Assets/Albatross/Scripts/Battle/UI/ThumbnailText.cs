using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Albatross
{
    public class ThumbnailText : MonoBehaviour
    {
        void Start()
        {
            MonsterObject mon = GetComponentInParent<MonsterObject>();
            Text thistext = GetComponent<Text>();
            thistext.text = mon.name;
        }
    }
}