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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Albatross
{
    public class GameManager : MonoBehaviour
    {

        public PlayerInventory DemoInventory;//Inventory specifically for the DOJO

        public Deck currentDeck;
        public Party currentParty;

        public Deck enemyDeck = null;
        public Party enemyParty = null;

        public List<Monster> mon;
        public List<SpellCard> spell;

        [SerializeField]
        GameData data = new GameData();

        void Start()
        {
            mon = currentParty.PartyMembers;
            spell = currentDeck.spells;

            DontDestroyOnLoad(this.gameObject);
        }

        void Update()
        {
        }

        public void SceneButton(string nextScene)
        {
            SceneManager.LoadScene(nextScene);
        }

        public void SaveGame()
        {
            data.PlayerLocation = FindObjectOfType<Player>().transform.position;
            data.HumanHealth = FindObjectOfType<Player>().HumanHealth;
            data.currentParty = currentParty;
            data.CameraLocation = FindObjectOfType<Camera>().transform.position;
            data.currentDeck = currentDeck;
            data.inv = DemoInventory;
            data.OverWorldManaPool = FindObjectOfType<Player>().OverWorldManaPool;

            string filepath = Application.persistentDataPath + "/SaveGame.json";

            FileStream file = File.Create(filepath);
            string json = JsonUtility.ToJson(data);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, json);
            file.Close();
        }

        public void LoadData()
        {
            string filepath = Application.persistentDataPath + "/SaveGame.json";
            FileStream file = File.Open(filepath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            string json = (string)bf.Deserialize(file);
            Debug.Log(json);

            data = JsonUtility.FromJson<GameData>(json);

            file.Close();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}