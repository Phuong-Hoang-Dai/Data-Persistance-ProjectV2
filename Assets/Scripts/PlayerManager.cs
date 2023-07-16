using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    protected static PlayerManager instance;

    public static PlayerManager Instance { get => instance;}
    [NonSerialized] public string m_Name = "";
    public int  m_BestScore = 0;
    private void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 Player Manager allow to exist");
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    class PlayerData
    {
        public string name;
        public int bestScore;
    }

    public void SavePlayer()
    {
        Debug.Log("SavePlayer is called" );
        if (PlayerManager.Instance.m_BestScore > 0)
        {
            PlayerData data = new PlayerData();
            data.name = instance.m_Name;
            data.bestScore = instance.m_BestScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/" +
                RemoveWhiteSpace(instance.m_Name) + ".json", json);
            Debug.Log("Player data is saved");
        }
    }
    public string RemoveWhiteSpace(string text)
    {
        return text.Replace(" ", "");
    } 
    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/" +
            RemoveWhiteSpace(instance.m_Name) + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            instance.m_BestScore = data.bestScore;
        }
    }
}
