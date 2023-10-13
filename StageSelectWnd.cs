using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectWnd : MonoBehaviour
{
    #region [MY CODE]
    [SerializeField] GameObject _windowBG;
    [SerializeField] RectTransform _openPos;
    [SerializeField] RectTransform _closePos;
    #endregion

    //[SerializeField] Transform _sPos;       //startPos
    [SerializeField] Transform _stageSlotParents;       //StageMap. 스테이지버튼 생성위치들의 Parent
    [SerializeField] RectTransform _contant;
    [SerializeField] Text _stageName;
    [SerializeField] Text _stageLimitTime;
    ItemInfownd itemWnd = null;

    List<StageSlot> _stageList = new List<StageSlot>();
    List<ScoreInfo> _infoList = new List<ScoreInfo>();

    float _basePosY = 100;
    float _offsetY = 10;
    
    public void OpenWindow(int clearStage)  //0 = 1,       1 = 2 ,       2 = 3,         3 = 4
    {
        iTween.MoveTo(_windowBG, iTween.Hash("position", _openPos.position, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic));
        _stageName.text = string.Empty;
        _stageLimitTime.text = "0";
        //slot 생성
        GameObject props = ResoucePoolManager._instance.GetUIPropsPrefabFromType(DefineHelper.eUIPropsType.stageSlot);
        for (int n = 0; n < _stageSlotParents.childCount; n++)
        {
            GameObject go = Instantiate(props, _stageSlotParents.GetChild(n));
            RectTransform rtf = go.GetComponent<RectTransform>();
            rtf.anchoredPosition = Vector2.zero;
            StageSlot slot = go.GetComponent<StageSlot>();
            DefineHelper.eStageSelectColor stageColor = DefineHelper.eStageSelectColor.Locked;
            //DefineHelper.stStageInfo info = ResoucePoolManager._instance.GetStageInfo(n + 1);
            
            //n == 현재 스테이지 번호
            if (n <= clearStage)
                stageColor = DefineHelper.eStageSelectColor.Free;
            //slot.InitDataSet(n + 1, stageColor, info._diffLevel, this);
            slot.InitDataSet(n + 1, stageColor, UserInfoManager._Instance.gameData.stageStars[n], this);
            _stageList.Add(slot);
        }
    }
    public void ClickCloseButton()
    {
        iTween.MoveTo(_windowBG, iTween.Hash("position", _closePos.position, "time", 0.5f));
    }

    public void ShowSelectStageInfo(int no)
    {
        DefineHelper.stStageInfo info =  ResoucePoolManager._instance.GetStageInfo(no);
        UserInfoManager._Instance._nowStageNumber = no;
        for(int n = 0; n < _stageList.Count;n++)
        {
            if(_stageList[n]._myNumber == no)
                continue;
            _stageList[n].NoneSelect();
        }
        _stageName.text = info._name;
        _stageLimitTime.text = info._limitTime.ToString();
        // ScoreInfo 생성
        for(int n = 0; n < _infoList.Count;n++)
        {
            Destroy(_infoList[n].gameObject);       //ScoreInfo 생성전 전에 만들어놨던 걸 비운다.
        }
        _infoList.Clear();
        _contant.sizeDelta = new Vector2(_contant.sizeDelta.x, (_offsetY + _basePosY) * info._insectKinds.Length);
        GameObject props = ResoucePoolManager._instance.GetUIPropsPrefabFromType(DefineHelper.eUIPropsType.InsectScoreInfoProps);
        for (int n = 0; n < info._insectKinds.Length;n++)
        {
            GameObject go = Instantiate(props, _contant);
            RectTransform rtf = go.GetComponent<RectTransform>();
            rtf.anchoredPosition = new Vector2(rtf.anchoredPosition.x, -(_offsetY + _basePosY) * n);
            ScoreInfo si = go.GetComponent<ScoreInfo>();
            si.InitDataSet(info._insectKinds[n]);
            _infoList.Add(si);
        }
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    public void ClickNextButton()
    {
        if (UserInfoManager._Instance._nowStageNumber != 0)
        {
            if (itemWnd == null)
            {
                GameObject go = Instantiate(ResoucePoolManager._instance.GetUIPrefabFromType(DefineHelper.eUIWindowType.ItemInfoWnd));
                itemWnd = go.GetComponent<ItemInfownd>();
            }
            else
            {
                itemWnd.gameObject.SetActive(true);
            }
            itemWnd.OpenItemInfoWnd();
        }
    }
}
