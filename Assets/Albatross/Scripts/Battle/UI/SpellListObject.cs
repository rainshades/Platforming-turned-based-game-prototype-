using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// Used in Deck creator to add a spell to deck
/// </summary>
namespace Albatross
{
    public class SpellListObject : MonoBehaviour, IPointerClickHandler
    {
        public SpellCard Spell { get; set; }
        public Text SpellName { get; set; }
        public Image Image { get; set; }
        public DeckBuildHandler Dbh { get; set; }

        void Awake()
        {
            SpellName = GetComponentInChildren<Text>();
            Image = GetComponent<Image>();
            Dbh = FindObjectOfType<DeckBuildHandler>();

            SpellName.text = Spell.name;
            Image.sprite = Spell.artwork;

            transform.name = Spell.name;
        }

        public void UpdatePrefab(SpellCard spell, string SpellName, Sprite sprite)
        {
            Spell = spell; this.SpellName.text = SpellName; Image.sprite = sprite; 
        }

        public void OnPointerClick(PointerEventData pe)
        {
            if(pe.clickCount < 2 || pe.dragging)
            {
                Dbh.SelectedSpell = gameObject;
                Dbh.SpellPreview.sprite = this.Image.sprite; 
            }
        }

        public void SetSpell(SpellCard spell)
        {
            Spell = spell;
        }
    }
}
