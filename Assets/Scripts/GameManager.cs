using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Deck currentDeck = new Deck();
    public Party currentParty = new Party();

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