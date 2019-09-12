using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Albatross
{
    public class DeckManager : MonoBehaviour
    {
        BattleManager gm;
        public List<SpellCard> Deck;
        int CardsInDeck;
        public Image cardBack;
        public Sprite cardBackSprite;

        public HorizontalLayoutGroup HandArea;

        public GameObject cardPrefab;

        public Text DeckNumberText;

        // Start is called before the first frame update
        void Start()
        {
            gm = GetComponent<BattleManager>();
            cardBack.sprite = cardBackSprite;
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}