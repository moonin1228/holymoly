using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingWnd : MonoBehaviour
{
    [SerializeField] GameObject _contantRoot;
    [SerializeField] Text _txtStaticLoading;
    [SerializeField] Slider _bar;
    [SerializeField] Text _txtTipString;

    Animator _aniController;

    int _limitCount = 6;
    float _checkTime = 0;
    int _count = 0;
    #region [MY CODE]
    //float _loadingDelay = 10;
    //float _loadingtimer = 0;
    //int _dotCount = 6;
    //int _currentDotCnt = 0;
    //float _dotTimer = 0;
    #endregion

    private void Awake()
    {
        _aniController = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        //test용
        OpenWindow();
        //===
    }

    private void Update()
    {
        if(_contantRoot.activeSelf)
        {
            _checkTime += Time.deltaTime;
            if (_checkTime >= 0.5f)
            {
                _checkTime = 0;
                _txtStaticLoading.text = "Loading";
                for(int n = 0; n < _count; n++)
                {
                    _txtStaticLoading.text += ".";
                }
                if(++_count >= _limitCount)
                    _count = 0;
            }
            #region [MY CODE]
            //if (_loadingtimer < _loadingDelay)
            //{
            //    _loadingtimer += (Time.deltaTime / _loadingDelay);
            //    SetLoadingProgress(_loadingtimer);
            //}
            //_dotTimer += Time.deltaTime;
            //if (_dotTimer > 0.5f)
            //{
            //    SetLoadingText();
            //    _dotTimer = 0;
            //}
            #endregion
        }
    }
    public void OpenWindow()
    {
        _contantRoot.SetActive(false);
        _txtTipString.text = ResoucePoolManager._instance.GetRandomTipString();
        SetLoadingProgress(0);
        _txtStaticLoading.text = "Loading";
        _count++;
    }

    public void SetLoadingProgress(float pro)
    {
        _bar.value = pro;
        if(_bar.value == 1)
        {
            _contantRoot.SetActive(false);
            _aniController.SetTrigger("Open");
        }
    }

    public void EnableContants()
    {
        SceneControlManager._instance._isLoading = true;
        _contantRoot.SetActive(true);
    }

    public void Close()
    {
        SceneControlManager._instance._isLoading = false;
        Destroy(gameObject);
    }

    #region [MY CODE]
    //public void SetLoadingText()
    //{
    //    _txtStaticLoading.text = "Loading";
    //    for (int n = 0; n < _count; n++)
    //    {
    //        _txtStaticLoading.text += ".";
    //    }
    //    if (++_count >= _limitCount)
    //    {
    //        _count = 0;
    //    }

    //    #region [MY CODE]
    //    //if (_dotCount > _currentDotCnt)
    //    //{
    //    //    _txtStaticLoading.text += ".";
    //    //    _currentDotCnt++;
    //    //}
    //    //else
    //    //{
    //    //    _currentDotCnt = 0;
    //    //    _txtStaticLoading.text = "Loading";
    //    //}
    //    #endregion
    //}
    #endregion
}
