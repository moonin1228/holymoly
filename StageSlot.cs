using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSlot : MonoBehaviour
{
    [SerializeField] Image[] _star;
    [SerializeField] Image _lock;
    [SerializeField] Sprite _unLock;
    
    StageSelectWnd _ownerWnd;
    Image _bg;
    int _no;

    DefineHelper.eStageSelectColor _currentState;

    public int _myNumber
    {
        get { return _no; }
    }

    public void InitDataSet(int stageNum, DefineHelper.eStageSelectColor state, int clearDifftLevel,StageSelectWnd owner)
    {
        _ownerWnd = owner;
        _no = stageNum;
        _currentState = state;
        //락 헤제 여부 확인.
        _bg = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        if(_currentState != DefineHelper.eStageSelectColor.Locked)
        {
            //_lock.enabled = false;
            _lock.sprite = _unLock;
        }
        _bg.sprite = MainSceneManager._Instance.GetSpriteTrans(_currentState);
        if(_currentState == DefineHelper.eStageSelectColor.Locked)
        {
            return;
        }
        //클리어 레벨 확인.
        for(int n = 0; n < clearDifftLevel;n++)
        {
            _star[n].enabled = true;
        }
    }

    public void NoneSelect()        //선택되지않은 상태
    {
        if(_currentState != DefineHelper.eStageSelectColor.Locked)
        {
            _currentState = DefineHelper.eStageSelectColor.Free;
        }
        _bg.sprite = MainSceneManager._Instance.GetSpriteTrans(_currentState);
    }

    public void ClickSelect()
    {
        if(_currentState == DefineHelper.eStageSelectColor.Free)
        {
            //내 정보를 상위에 보낸다.
            //내 정보 = 벌레점수정보, 제한시간
            _ownerWnd.ShowSelectStageInfo(_no);
            _currentState = DefineHelper.eStageSelectColor.Selected;
            _bg.sprite = MainSceneManager._Instance.GetSpriteTrans(_currentState);
        }
    }
}
