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
        

        void OnTriggerEnter2D(Collider2D col)
        {
            text.text = AreaName;
            text.gameObject.SetActive(true);
        }
        
    }
}