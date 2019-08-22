using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuContentBox : MonoBehaviour
{
    [SerializeField]
    GameObject MenuButtons = null;
    PlayerActions inputs;
    float player_speed_saver;
    PlayerController pc; 

    // Start is called before the first frame update
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
        }
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
