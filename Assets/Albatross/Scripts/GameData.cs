using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// <summary>
/// DO NOT CALL FROM THIS UNLESS SAVING OR LOADING DATA
/// Meant for the purpose of saving and loading player data for Persistence
/// i.e. A player wants to save, autosaving, loading games from file
/// </summary>

namespace Albatross
{
    [System.Serializable]
    public class GameData
    {

        //Player Persistant Game Data
        public Vector3 PlayerLocation = Vector3.zero;
        public int HumanHealth = 0;
        public float OverWorldManaPool = 0.0f;
        public PlayerInventory inv = null;

        //Script Persistant Game Data
        public Vector3 CameraLocation = Vector3.zero;
        public int Bravery = 0;
        public string LastScene; 
       
        public void Save()
        {
            
            try
            {
                string filepath = Application.persistentDataPath + "/SaveGame.json";

                FileStream file = File.Create(filepath);
                string json = JsonUtility.ToJson(this);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, json);
                file.Close();
            }
            catch
            {
                Debug.LogError("Save Error Found");
            }
        }
    }
}