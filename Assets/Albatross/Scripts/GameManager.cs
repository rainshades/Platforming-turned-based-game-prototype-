using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Albatross
{
    public class GameManager : MonoBehaviour
    {

        public PlayerInventory DemoInventory;//Inventory specifically for the DOJO

        public Deck currentDeck = new Deck("Player's Deck");
        public Party currentParty = new Party("Player's party");


        [SerializeField]
        List<NPCBattleDetails> BattleDetails;
        [SerializeField]
        List<bool> CanNPCBattle; 

        [SerializeField]
        NPCBattleDetails currentBattleDetails;
        public int currentNPCNumber; 

        bool PleaseSetData = false;

        public GameData data = new GameData();
        public string LastScene = "";
        
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        void Update()
        {
            if (PleaseSetData)
            {
                SetData();
            }
        }

        public void SetBattleResults(bool isDefeated, int NPCBattleNumber)
        {
            CanNPCBattle[NPCBattleNumber] = isDefeated;
        }

        public void setCurrentBattleDetails(NPCBattleDetails nbd)
        {
            currentBattleDetails = nbd;
        }

        public bool CanBattle(int NPCNumber)
        {
            return CanNPCBattle[NPCNumber];
        }

        public Party getEnemyParty()
        {
            return currentBattleDetails.party;
        }

        public Deck getEnemyDeck()
        {
            return currentBattleDetails.deck;
        }


        public NPCBattleDetails BattleDetailsAt(int i)
        {
            return BattleDetails[i];
        }

        
        #region Scene Transitions
        public void NewGameButton(string nextScene)
        {
            SceneManager.LoadScene(nextScene);
        }

        public void ToUIScene(string nextScene)
        {
            LastScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nextScene);
        }//To UI Scenes

        public void ToBattleScene(string BattleScene)
        {
            SaveGame();
            LastScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(BattleScene);
        }//Transition to Battle Scenes

        public void ToOverworldScene()
        {
            LoadData();
            SceneManager.LoadScene(LastScene);
        }//Transtion to Overworld Scenes Usually From Battle Scene Wins

        public void EnemyDefeated(NPCBattleDetails nbd)
        {
            //BattleDetails.isDefeated = true;
        }

        #endregion


        #region Save/Load Game


        public void SavedGameButton(string nextScene)
        {
            SceneManager.LoadScene(nextScene);
            LoadData();
        }

        public void SaveGame()
        {
            data.inv = DemoInventory;
            try
            {
                data.PlayerLocation = FindObjectOfType<Player>().transform.position;
                data.HumanHealth = FindObjectOfType<Player>().HumanHealth;
                data.CameraLocation = FindObjectOfType<Camera>().transform.position;
                data.OverWorldManaPool = FindObjectOfType<Player>().OverWorldManaPool;


                data.Save();
            }
            catch
            {
                Debug.Log("Save Error");
            }
        }

        public void SetParty(Party p)
        {
            currentParty = p;
        }

        public void SetDeck(Deck d)
        {
            currentDeck = d;
        }

        public void LoadData()
        {
            string DataPath = Application.persistentDataPath + "/SaveGame.json";
            string PartyPath = Application.persistentDataPath + "/Parties.json";
            string DeckPath = Application.persistentDataPath + "/Deck.json";

            try
            {
                FileStream file = File.Open(DataPath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                string json = (string)bf.Deserialize(file);

                data = JsonUtility.FromJson<GameData>(json);

                file.Close();

            }
            catch
            {
                Debug.LogError("File not Found");
            }

            try
            {
                FileStream file = File.Open(PartyPath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                string json = (string)bf.Deserialize(file);

                currentParty = JsonUtility.FromJson<Party>(json);

                file.Close();
            }
            catch
            {
                Debug.LogError("File not Found");
            }

            try
            {
                FileStream file = File.Open(DeckPath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                string json = (string)bf.Deserialize(file);
                currentDeck = JsonUtility.FromJson<Deck>(json);


                file.Close();

            }
            catch
            {
                Debug.LogError("File not Found");
            }

            PleaseSetData = true;

        }


        public void SetData()
        {
            try
            {
                FindObjectOfType<Player>().transform.position = data.PlayerLocation;
                FindObjectOfType<Player>().HumanHealth = data.HumanHealth;
                FindObjectOfType<Camera>().transform.position = data.CameraLocation;

                DemoInventory = data.inv;
                FindObjectOfType<Player>().OverWorldManaPool = data.OverWorldManaPool;
                PleaseSetData = false;
            }
            catch
            {
                Debug.LogError("Data not set");
            }
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
    #endregion 
   
}