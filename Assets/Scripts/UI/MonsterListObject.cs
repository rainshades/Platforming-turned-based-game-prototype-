using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MonsterListObject : MonoBehaviour, IPointerClickHandler
{
    public Monster mon;
    public Text CharacterName;
    public Image Image;
    public DeckBuildHandler dbh;

    void Awake()
    {
        CharacterName = GetComponentInChildren<Text>();
        Image = GetComponent<Image>();
        dbh = FindObjectOfType<DeckBuildHandler>();

        CharacterName.text = mon.name;
        Image.sprite = mon.artwork;

        transform.name = mon.name;
    }

    public void OnPointerClick(PointerEventData pe)
    {
        dbh.PreviewImage.sprite = Image.sprite;
        Debug.Log(name + "Was Clicked");
        if(pe.clickCount > 1)
        {
            dbh.addToParty(mon);
        }
    }

    public void setMon(Monster mon)
    {
        this.mon = mon;
    }
}
