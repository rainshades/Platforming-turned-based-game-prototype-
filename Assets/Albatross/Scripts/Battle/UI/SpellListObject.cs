using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Albatross
{
    public class SpellListObject : MonoBehaviour, IPointerClickHandler
    {
        public SpellCard spell;
        public Text SpellName;
        public Image Image;
        public DeckBuildHandler dbh;

        void Awake()
        {
            SpellName = GetComponentInChildren<Text>();
            Image = GetComponent<Image>();
            dbh = FindObjectOfType<DeckBuildHandler>();

            SpellName.text = spell.name;
            Image.sprite = spell.artwork;

            transform.name = spell.name;
        }

        public void UpdatePrefab(SpellCard spell, string SpellName, Sprite sprite)
        {
            this.spell = spell; this.SpellName.text = SpellName; this.Image.sprite = sprite; 
        }

        public void OnPointerClick(PointerEventData pe)
        {
            if(pe.clickCount < 2 || pe.dragging)
            {
                dbh.selectedSpell = gameObject;
                dbh.SpellPreview.sprite = this.Image.sprite; 
            }
        }

        public void setSpell(SpellCard spell)
        {
            this.spell = spell;
        }
    }
}
