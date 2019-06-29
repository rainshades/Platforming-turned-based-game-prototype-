using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    public void OnPointerClick(PointerEventData pe)
    {
        dbh.PreviewImage.sprite = Image.sprite;
        if (dbh.Deck.spells.Count < 20)
        {
            dbh.addToDeck(spell);
        }
    }

    public void setSpell(SpellCard spell)
    {
        this.spell = spell;
    }
}
