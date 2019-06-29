using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellObject : MonoBehaviour, IPointerClickHandler
{
    BattleManager gm;
    DeckManager dm;

    public SpellCard spell;

    public string description;
    public Sprite cardImage;

    Image attatchedImage; 

    // Start is called before the first frame update
    void Start()
    {
        name = spell.name;
        description = spell.description;
        cardImage = spell.artwork;

        attatchedImage = GetComponent<Image>();
        attatchedImage.sprite = cardImage;
        gm = FindObjectOfType<BattleManager>();
        dm = FindObjectOfType<DeckManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pe)
    {
    }

    public SpellObject Select()
    {
        return this;
    }
}
