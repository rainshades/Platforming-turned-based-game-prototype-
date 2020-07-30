using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


namespace Albatross
{
    /// <summary>
    /// Controller support for the start menu
    /// Contains a close game button
    /// </summary>
    public class StarMenuUI : MonoBehaviour
    {
        [SerializeField]
        Button CurrentButtonSelected; //Just to show the current button on the inspector

        [SerializeField]
        Button[] buttons = null;
        bool canInteract = true;
        PlayerControllerActionMap actions;
        int selectedButton, buttonInput;

        void Awake()
        {
            actions = new PlayerControllerActionMap();
        }

        void Update()
        {
            actions.WorldInteraction.Movement.performed += ctx => buttonInput = (int)(ctx.ReadValue<Vector2>().y * 10);
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

        public void SwitchMode()
        {
            if (transform.gameObject.activeInHierarchy)
            {
                transform.gameObject.SetActive(false);
            }
            else
            {
                transform.gameObject.SetActive(true);
            }
        }

        void OnEnable()
        {
            actions.UI.Enable();
        }

        void OnDisable()
        {
            actions.UI.Disable();
        }

        public void CloseGame()
        {
            Application.Quit();
        }

    }
}