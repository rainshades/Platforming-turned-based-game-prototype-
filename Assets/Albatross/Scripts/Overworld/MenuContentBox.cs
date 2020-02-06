using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albatross
{
    public class MenuContentBox : MonoBehaviour
    {
        [SerializeField]
        GameObject MenuButtons = null;
        PlayerActions inputs;
        float player_speed_saver;
        PlayerController pc;
			//Creates the ability to stop the player from
			//moving by setting their movement from 0 while
			//the menu is open and back to its default value when it is closed

        void Awake()
        {
            inputs = new PlayerActions();
            pc = FindObjectOfType<PlayerController>();
            player_speed_saver = pc.maxSpeed;
        }

        void Update()
        {

            if (MenuButtons.gameObject.activeSelf)
            {
                pc.maxSpeed = 0;
                inputs.UI.ConfirmSelection.performed += ctx => MenuButtons.gameObject.SetActive(false);
            } 
            else
            {
                pc.maxSpeed = player_speed_saver;
                inputs.UI.ConfirmSelection.performed += ctx => MenuButtons.gameObject.SetActive(true);
            } //Opens and closes the menu on the overworld  
        }

        void OnEnable()
        {
            inputs.InputsMap.Enable();
        }
        void OnDisable()
        {
            inputs.InputsMap.Disable();
        }
    }
}