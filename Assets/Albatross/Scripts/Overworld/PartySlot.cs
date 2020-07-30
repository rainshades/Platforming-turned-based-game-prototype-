using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Albatross
{
    //If clicked removes the Monster(ID) from the Party
    public class PartySlot : MonoBehaviour, IPointerClickHandler
    {
        Image image;

        public int PartyPosition;

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
                dm.RemoveFromParty(PartyPosition);
            }
        }
    }
}
