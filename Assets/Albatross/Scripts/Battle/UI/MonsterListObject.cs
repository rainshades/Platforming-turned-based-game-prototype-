using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Albatross
{
    public class MonsterListObject : MonoBehaviour, IPointerClickHandler
    {
		//Represents an ID's data in UI for deck building 

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
            if (pe.clickCount < 2 || pe.dragging)
            {
                dbh.PreviewImage.sprite = Image.sprite;
                dbh.selectedMonster = this.gameObject;
            }

        }

        public void setMon(Monster mon)
        {
            this.mon = mon;
        }
    }
}