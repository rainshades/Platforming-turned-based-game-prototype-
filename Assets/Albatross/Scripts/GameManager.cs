/* Project Albatross
 * Prepared by Eddie Fulton
 * Unpublished/Unfinished
 * Purpose: SceneMangement, SaveStateManagement, Storing objects meant to be used inbetween scenes
 * Status: Member: Testing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Albatross
{
    public class GameManager : MonoBehaviour
    {
        public Deck currentDeck;
        public Party currentParty;

        public Deck enemyDeck;
        public Party enemyParty;

        public List<Monster> mon;
        public List<SpellCard> spell;


        // Start is called before the first frame update
        void Start()
        {
            mon = currentParty.PartyMembers;
            spell = currentDeck.spells;
        }

        // Update is called once per frame
        void Update()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void SceneButton(string nextScene)
        {
            SceneManager.LoadScene(nextScene);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}