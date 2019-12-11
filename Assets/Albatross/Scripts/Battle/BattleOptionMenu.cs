/* Project Albatross 
 * Prepared by Eddie Fulton
 * Unpublished/Unfinished
 * Purpose: Allows for the use of controllers for selecting for the UI
 * Status: TentativeMember: Testing 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Albatross
{
    public class BattleOptionMenu : MonoBehaviour
    {
        PlayerActions pa;

        [SerializeField]
        Button currentButton;

        [SerializeField]
        GameObject[] Battleoptions = null;

        Vector2 OptionsSelector = Vector2.zero;
        int XAxisSelection, YAxisSelection;
        bool canInteract = false;

        // Start is called before the first frame update
        void Awake()
        {
            currentButton = Battleoptions[0].GetComponent<Button>();
            pa = new PlayerActions();
        }

        // Update is called once per frame
        void Update()
        {
            // pa.InputsMap.Walk.performed += ctx => OptionsSelector = ctx.ReadValue<Vector2>();
        }

        IEnumerator MenuChange(Vector2 input)
        {
            if (input.x < 0 && XAxisSelection < Battleoptions.Length / 2 - 1) XAxisSelection++;

            else if (input.x > 0 && XAxisSelection > 0) XAxisSelection--;
            else if (input.x < 0 && XAxisSelection > 0) XAxisSelection = 0;
            yield return new WaitForSeconds(1f);

            canInteract = true;
        }
        void OnEnable()
        {
            pa.InputsMap.Enable();
        }

        void OnDisable()
        {
            pa.InputsMap.Disable();
        }
    }
}
