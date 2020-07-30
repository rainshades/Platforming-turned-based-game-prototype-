using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Albatross
{
    //Holds The name of the region the player is moving to
    //and then sets the textmesh to active when the player triggers it
    public class AreaTransition : MonoBehaviour
    {
        public TextMeshProUGUI Text = null;
        public string AreaName = null;
        public AudioClip Audio = null;
        public GameObject AreaToCreate = null;
        void OnTriggerEnter2D(Collider2D col)
        {
            Text.text = AreaName;
            Text.gameObject.SetActive(true);
            AudioSource ao = FindObjectOfType<AudioSource>();
            ao.clip = Audio;
            ao.Play();
            //Destroy(gameObject);
        }
        
    }
}