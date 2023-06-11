using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    public int coins;
    public bool isUIOpen = false;
    public Dictionary<string, int> storage;
    public List<GameObject> plants;
    public int exp;
    public int level;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class UserData
    {
        public int coins;
        public int exp;
        public int level;
        // public Dictionary <GameObject, int> storage;
        public List<string> storageKey;
        public List<int> storageValue;
    }
    public void SaveData()
    {
        UserData data = new UserData();
        data.coins = coins;
        data.exp = exp;
        data.level = level;
        data.storageKey = new List<string>();
        data.storageValue = new List<int>();

        foreach (var s in storage)
        {
            data.storageKey.Add(s.Key);
            data.storageValue.Add(s.Value);
        }

        // return JsonConvert.SerializeObject( myDictionary );

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);
            coins = data.coins;
            exp = data.exp;
            level = data.level;
            storage = new Dictionary<string, int>();
            for(int i = 0; i < data.storageKey.Count;i++)
            {
                storage.Add(data.storageKey[i], data.storageValue[i]);
            }
            
        }
        else
        {
            InitiateData();
        }
    }

    public void InitiateData()
    {
        coins = 100;
        exp = 0;
        level = 0;
        storage = new Dictionary<string, int>();
        foreach (GameObject plantObject in plants)
        {
            storage.Add(plantObject.GetComponent<Plant>().plantName, 0);
        }
    }

    public void DeleteData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
