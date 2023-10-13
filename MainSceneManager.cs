using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    static MainSceneManager _uniqueInstance;

    [SerializeField] Sprite[] _slotTrans;
    [SerializeField] Color[] _changeColors;
    [SerializeField] GameObject _optionWndPrefab;
    [SerializeField] Canvas mainSceneCanvas;

    Text _txtTitle;
    Text _txtSubTitle;
    StageSelectWnd _SeletWnd;




    int _idx = 0;
    //int _colorCnt = 4;
    float _timeCheck = 2;
    float _changeColorTime = 3;
    float _timeFade = 3;
    float _changeAlphaTime = 3.5f;
    float _changeOffsetTime = 0.5f;
    float _minAlphaValue = 0.05f;
    float _maxAlphaValue = 1;
    bool _isFadeOut = false;
    

    public static MainSceneManager _Instance
    {
        get { return _uniqueInstance; }
    }


    private void Awake()
    {
        _uniqueInstance = this;
    }

    void Start()
    {
        //임시
        InitSettingData();
        //===
    }
    

    private void LateUpdate()
    {
        _timeCheck += Time.deltaTime;
        _timeFade += Time.deltaTime;
        if(_timeCheck >= _changeColorTime)
        {
            _timeCheck = 0;
            _txtSubTitle.CrossFadeColor(ChangeColor(_idx++), _changeColorTime - _changeOffsetTime, false, true);         //정해준 색으로 2번째 인자동안 색이 변한다.
            if (_idx >= _changeColors.Length)
            {
                _idx = 0;
            }
        }
        if(_timeFade >= _changeAlphaTime)
        {
            _timeFade = 0;
            _isFadeOut = !_isFadeOut;
            if(_isFadeOut)
            {
                _txtTitle.CrossFadeAlpha(_minAlphaValue, _changeAlphaTime - _changeOffsetTime, false);              //정해준 값으로 2번째 인자동안 알파값이 변한다.
            }
            else
            {
                _txtTitle.CrossFadeAlpha(_maxAlphaValue, _changeAlphaTime - _changeOffsetTime, false);
            }
        }
    }

    void InitSettingData()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UIMainTitle");
        _txtTitle = go.GetComponent<Text>();
        _txtSubTitle = go.transform.GetChild(0).GetComponent<Text>();
    }

    Color ChangeColor(int id)
    {
        return _changeColors[id];
    }

    public Sprite GetSpriteTrans(DefineHelper.eStageSelectColor color)
    {
        return _slotTrans[(int)color];
    }
    public void ClickOptionButton()
    {
        //_optionWndPrefab.gameObject.SetActive(true);
        Instantiate(_optionWndPrefab, mainSceneCanvas.transform);
    }

    public void ClickStageButton()
    {
        #region [MY CODE]
        //_stageInfo.gameObject.SetActive(true);
        //if (_SeletWnd == null)
        //{
        //    _SeletWnd = _stageInfo.GetComponent<StageSelectWnd>();
        //    _SeletWnd.OpenWindow(0);
        //}
        #endregion

        if (_SeletWnd == null)
        {
            GameObject go = Instantiate(ResoucePoolManager._instance.GetUIPrefabFromType(DefineHelper.eUIWindowType.StageInfoSelectWnd));
            _SeletWnd = go.GetComponent<StageSelectWnd>();
        }
        _SeletWnd.OpenWindow(UserInfoManager._Instance.gameData.clearStage);
        //SoundManager._instance.PlaySFXSound(DefineHelper.eSFXClipType.Click_tock);
        SoundManager._instance.PlaySFXSoundOneShot(DefineHelper.eSFXClipType.Click_tock);
    }
}
