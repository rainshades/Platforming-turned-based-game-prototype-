using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Albatross
{
    public class AreaTransition : MonoBehaviour
    {
        public TextMeshProUGUI text;
        public string AreaName;
        bool isPlayed; 
        

        void OnTriggerEnter2D(UnityEngine.Collider2D col)
        {
            if (col.tag.Equals("Player"))
            {
                text.gameObject.SetActive(true);
                text.text = AreaName;
            }
        }
    }
}