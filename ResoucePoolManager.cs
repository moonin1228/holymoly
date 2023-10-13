using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoucePoolManager : MonoBehaviour
{
    static ResoucePoolManager _uniqueInstance;
    //MY CODE
    [SerializeField] GameObject[] backGroundMaps;
    [SerializeField] Sprite[] volumeimgs;
    //====
    [SerializeField] string[] _tipStrings;
    [SerializeField] GameObject[] _uiPrefabs;
    [SerializeField] GameObject[] _uiPropsPrefabs;
    [SerializeField] Sprite[] _insectTypeIcons;
    [SerializeField] AudioClip[] _bgmClips;
    [SerializeField] AudioClip[] _sfxClips;
    [SerializeField] Sprite[] _itemTypeIcons;
    [SerializeField] GameObject[] _itemPrefabs;

    //임시
    Dictionary<int, DefineHelper.stStageInfo> _dummyStageInfoList;
    //====
    public static ResoucePoolManager _instance
    {
        get { return _uniqueInstance; }
    }

    private void Awake()
    {
        _uniqueInstance = this;
        DontDestroyOnLoad(this.gameObject);
        
        DummyData();
    }

    public string GetRandomTipString()
    {
        int idx = Random.Range(0, _tipStrings.Length);

        return _tipStrings[idx];
    }

    public GameObject GetUIPrefabFromType(DefineHelper.eUIWindowType wndType)
    {
        return _uiPrefabs[(int)wndType];
    }

    public GameObject GetUIPropsPrefabFromType(DefineHelper.eUIPropsType propsType)
    {
        return _uiPropsPrefabs[(int)propsType];
    }

    public Sprite GetInsectTypeIcon(DefineHelper.eInsectKind kind)
    {
        return _insectTypeIcons[(int)kind];
    }

    public DefineHelper.stStageInfo GetStageInfo(int index)
    {
        return _dummyStageInfoList[index];
    }

    public void GetMapSprite(GameObject[] maps)
    {
        backGroundMaps = maps;
        SetMapBackGround(UserInfoManager._Instance._nowStageNumber);
    }

    void SetMapBackGround(int index)
    {
        for (int i = 0; i < backGroundMaps.Length; i++)
        {
            if ((index - 1) == i)
            {
                backGroundMaps[i].gameObject.SetActive(true);
            }
            else
                backGroundMaps[i].gameObject.SetActive(false);
        }
    }

    public Sprite GetSoundImg(DefineHelper.eMuteType type)
    {
        return volumeimgs[(int)type];
    }

    public AudioClip GetBgmClipFromType(DefineHelper.eBGMClipType type)
    {
        return _bgmClips[(int)type];
    }

    public AudioClip GetSFXClipFromType(DefineHelper.eSFXClipType type)
    {
        return _sfxClips[(int)type];
    }

    public Sprite GetItemSpriteFromType(DefineHelper.eSelectItemKind type)
    {
        return _itemTypeIcons[(int)type];
    }

    public GameObject GetItemPrefabFromType(DefineHelper.eSelectItemKind type)
    {
        return _itemPrefabs[(int)type - 1];
    }

    void DummyData()
    {
        _dummyStageInfoList = new Dictionary<int, DefineHelper.stStageInfo>();
        // 1.
        int[] rate = { 100 };
        DefineHelper.stStageInfo info = new DefineHelper.stStageInfo("조금 지저분한 다용도실", 60, 0, rate, DefineHelper.eInsectKind.GreenInsect);
        // 2.
        rate[0] = 100;
        _dummyStageInfoList.Add(1, info);
        info = new DefineHelper.stStageInfo("깨끗해 보이는 응접실", 60, 0, rate, DefineHelper.eInsectKind.RedAnt);
        // 3.
        rate = new int[] { 75, 100 };
        _dummyStageInfoList.Add(2, info);
        info = new DefineHelper.stStageInfo("복잡한 거실", 90, 0, rate, DefineHelper.eInsectKind.GreenInsect, DefineHelper.eInsectKind.RedAnt);
        // 4.
        rate = new int[] { 55, 100 };
        _dummyStageInfoList.Add(3, info);
        info = new DefineHelper.stStageInfo("너저분한 책상위", 100, 0, rate, DefineHelper.eInsectKind.RedAnt, DefineHelper.eInsectKind.GreenInsect);
        _dummyStageInfoList.Add(4, info);
    }

    public void CheckStageClearScore(int highestScore, int total)
    {
        DefineHelper.stStageInfo nowStage = _dummyStageInfoList[UserInfoManager._Instance._nowStageNumber];
        float percent = (float)total / (float)highestScore * 100;
        for (int i = 0; i < 3;i++)
        {
            if(DefineHelper._stageClearScorePerccent[i] <= percent)
            {
                nowStage._diffLevel = i + 1;
                UserInfoManager._Instance.gameData.stageStars[UserInfoManager._Instance._nowStageNumber - 1] = 
                    nowStage._diffLevel;
                _dummyStageInfoList[UserInfoManager._Instance._nowStageNumber] = nowStage;
                //Debug.Log(UserInfoManager._Instance._nowStageNumber + "번째 스테이지" + i + "번째 클리어");
                
            }
        }
        IngameManager._instance.highestScore = 0;
    }

    public void CheckOpenNextStage()
    {
        if (_dummyStageInfoList[UserInfoManager._Instance._nowStageNumber]._diffLevel >= 2)
        {
            //UserInfoManager._Instance._clearStage = UserInfoManager._Instance._nowStageNumber;
            UserInfoManager._Instance.gameData.clearStage = UserInfoManager._Instance._nowStageNumber;
        }
    }
}
