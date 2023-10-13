using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineHelper
{
    #region [Manager Info]
    public enum eSceneIndex
    {
        none,
        MainScene,
        IngameScene
    }
    public enum eIngameState        //게임상태
    {
        none = 0,
        COUNT,
        PLAY,
        END,
        RESULT,

        state_Count
    }
    public enum eStageSelectColor
    {
        Locked = 0,
        Free,
        Selected
    }
    public enum eUIWindowType
    {
        LoadingWnd = 0,
        StageInfoSelectWnd,
        ResultWnd,
        ItemInfoWnd,
        OptionWnd,
        DialogWnd,

        max_count
    }
    public enum eUIPropsType
    {
        CountingProps = 0,
        ResultProps,
        InsectScoreInfoProps,
        stageSlot,

        max_count
    }
    public enum eBGMClipType
    {
        MainScene = 0,
        IngameScene
    }
    public enum eSFXClipType
    {
        Die = 0,
        Click_tock,
        Click_tting,
        Counting_Nor,
        Counting_Fast
    }
    public enum eMuteType
    {
        None,
        Mute
    }
    #endregion



    #region [UI Kind]
    public enum eMessageBoxKind     //메시지박스 종류
    {
        MESSAGE = 0,
        COUNTER
    }
    public enum eResultCounting
    {
        none = 0,
        IndividualScore,
        TotalScore,
        UseItemScore,
        Complete
    }
    public enum eDialogType
    {
        Notification = 0,
        Warnung,
        Exit
    }
    public enum eSelectItemKind
    {
        NoItem          = 0,
        Bomb,
        Clock,
        Max_Count
    }
    #endregion

    #region [Insect Info]
    public enum eInsectKind         //벌레 종류
    {
        GreenInsect = 0,
        RedAnt,


        max_cnt
    }

    public static float _standardSpeed = 2;         //기본속도
    public static float _standardAngle = 45;        //기본회전값
    public static float[] _standardSpeedScalePerInsect = { 1, 2 };      //벌레 종류에 따라 기본속도에 곱해줄 속도 크기값
    public static float[] _standardAngleScalePerInsect = { 1, 1.5f };       //벌레 종류에 따라 기본회전값에 곱해줄 회전 크기값
    public static int[] _baseScorePerInsect = { 8, 15 };                             //벌레 종류별 포인트 값
    //public static int[,] _stageClearScore = new int[4, 3] { { 50, 110, 160 }, { 105, 210, 315 },
    //                                                        { 50, 110, 160 }, { 50, 110, 160 } };
    public static int[] _stageClearScorePerccent = new int[3] { 20, 50, 80 };
    public static int _useItemScore = 10;
    #endregion

    public struct stStageInfo
    {
        public string _name;
        public int _limitTime;
        public int _diffLevel;
        public eInsectKind[] _insectKinds;
        public int[] _insectGenRate;
        public stStageInfo(string name, int t, int level,int[] genRate, params eInsectKind[] kinds)
        {
            _name = name;
            _limitTime = t;
            _diffLevel = level;
            _insectGenRate = genRate;
            _insectKinds = kinds;
        }
    }
}
