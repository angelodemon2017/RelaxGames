using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public static Data data;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        data = new Data();

        Currencies.coinsUpdate += ChangeInt;
    }

    private void Start()
    {
        SceneManager.LoadScene(data.LastScene);
        UIController.Instance.CloseMenu();
    }

    public void ChangeInt(int param) 
    {
        SaveData();
    }

    public void SaveData() 
    {

    }
}

public class Data 
{
    public int Coins = 0;
    public string LastScene;
    public List<LevelData> datas = new List<LevelData>();

    public Data() 
    {
        LastScene = "CampFire";
        datas.Add(new LevelData() 
        {
            IdLevel = "CampFire",
        });
    }
}