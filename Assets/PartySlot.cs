using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Albatross
{
    public class PartySlot : MonoBehaviour, IPointerClickHandler
    {
        public int PartyPosition;
        Image image; 

        void Awake()
        {
            image = GetComponent<Image>();
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {

            DeckBuildHandler dm = FindObjectOfType<DeckBuildHandler>();
            dm.PreviewImage.sprite = dm.Party.PartyMembers[PartyPosition].artwork;

            if (eventData.clickCount >= 2)
            {
                Debug.Log("ID Removed");
                image.sprite = null; 
                dm.removeFromParty(PartyPosition);
            }
        }
    }
}
