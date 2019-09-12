using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


namespace Albatross
{
    public class StarMenuUI : MonoBehaviour
    {
        [SerializeField]
        Button CurrentButtonSelected; //Just to show the current button on the inspector

        [SerializeField]
        Button[] buttons = null;
        bool canInteract = true;
        PlayerActions actions;
        int selectedButton, buttonInput;

        void Awake()
        {
            actions = new PlayerActions();
        }

        // Update is called once per frame
        void Update()
        {
            actions.InputsMap.Walk.performed += ctx => buttonInput = (int)(ctx.ReadValue<Vector2>().y * 10);
            actions.UI.ConfirmSelection.performed += ctx => buttons[selectedButton].onClick.Invoke();

            if (buttonInput != 0 && canInteract)
            {
                canInteract = false;
                StartCoroutine(MenuChange(buttonInput));
            }

            if (buttons[selectedButton] == CurrentButtonSelected)
            {
                buttons[selectedButton].image.color = buttons[selectedButton].colors.highlightedColor;
            }
            CurrentButtonSelected = buttons[selectedButton];

            buttons[selectedButton].Select();

        }

        IEnumerator MenuChange(int input)
        {
            if (input < 0 && selectedButton < buttons.Length - 1) selectedButton++;

            else if (input > 0 && selectedButton > 0) selectedButton--;
            else if (input < 0 && selectedButton > 0) selectedButton = 0;
            yield return new WaitForSeconds(1f);

            canInteract = true;
        }

        void OnEnable()
        {
            actions.InputsMap.Enable();
        }

        void OnDisable()
        {
            actions.InputsMap.Disable();
        }

    }
}