using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace Albatross
{
    public class sayobject : MonoBehaviour
    {

        [SerializeField]
        Flowchart flow;

        [SerializeField]
        string dialogOption;


        void Awake()
        {

        }

        void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.gameObject.tag == "Player")
            {
                flow.ExecuteBlock(dialogOption);
            }
        }
    }
}