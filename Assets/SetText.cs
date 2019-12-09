using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Albatross
{
    public class SetText : MonoBehaviour
    {
        [SerializeField]
        SpellSelector sm;
        [SerializeField]
        TextMeshProUGUI textMesh;

        void Start()
        {
            sm = FindObjectOfType<SpellSelector>();
            textMesh = transform.GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            textMesh.SetText(sm.currentSpell.description);
        }
    }
}