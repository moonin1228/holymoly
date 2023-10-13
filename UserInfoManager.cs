using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data
{
    public  float bgmVolume;
    public  float sfxVolume;
    public  int clearStage;

    public int[] stageStars = new int[4];
}

public class UserInfoManager : MonoBehaviour
{
    static UserInfoManager _uniqueInstance;
    public static UserInfoManager _Instance
    {
        get { return _uniqueInstance; }
    }
    public Data gameData = new Data();
    string dataPath;
    DefineHelper.eSelectItemKind _itemType;

    public int _nowStageNumber { get; set; }
    //public int _clearStage { get; set; }
    //public float _bgmVolume { get; set; }
    //public float _sfxVolume { get; set; }

    private void Awake()
    {
        _uniqueInstance = this;
        DontDestroyOnLoad(gameObject);

        //임시
        //_clearStage = 0;
        //====
        if(File.Exists(Application.dataPath + "/gameData.json"))
        {
            LoadData();
        }
        else
        {
            InitData();
        }
    }

    //데이터 Init함수
    void InitData()
    {
        Debug.Log("Init Data");
        gameData.bgmVolume = 1;
        gameData.sfxVolume = 1;
        gameData.clearStage = 0;
        for(int i = 0; i < 4;i++)
        {
            gameData.stageStars[i] = 0;
        }
        SaveData();
    }

    
    //데이터 저장 및 불러오기
    public void SaveData()
    {
        Debug.Log("SaveData");
        dataPath = Path.Combine(Application.dataPath, "gameData.json");
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(dataPath, json);
    }

    public void LoadData()
    {
        Debug.Log("Load Data");
        dataPath = Path.Combine(Application.dataPath, "gameData.json");
        string readJson = File.ReadAllText(dataPath);
        gameData = JsonUtility.FromJson<Data>(readJson);
    }
}
