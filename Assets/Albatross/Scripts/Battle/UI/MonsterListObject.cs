using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Albatross
{
    //Used by the Deck manager to add Monsters (IDs) to the Player's Party
    public class MonsterListObject : MonoBehaviour, IPointerClickHandler
    {

        public Monster Mon { get; set; }
        public Text CharacterName { get; set; }
        public Image Image { get; set; }
        public DeckBuildHandler Dbh { get; set; }

        void Awake()
        {
            CharacterName = GetComponentInChildren<Text>();
            Image = GetComponent<Image>();
            Dbh = FindObjectOfType<DeckBuildHandler>();

            CharacterName.text = Mon.name;
            Image.sprite = Mon.artwork;

            transform.name = Mon.name;
        }

        public void OnPointerClick(PointerEventData pe)
        {
            if (pe.clickCount < 2 || pe.dragging)
            {
                Dbh.PreviewImage.sprite = Image.sprite;
                Dbh.SelectedMonster = gameObject;
            }

        }

        public void SetMon(Monster mon)
        {
            Mon = mon;
        }
    }
}