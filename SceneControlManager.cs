using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoBehaviour
{
    static SceneControlManager _uniqueInstance;

    [HideInInspector] public bool _isOpenEscapeWnd = false;
    [HideInInspector] public bool _isLoading = false;
    [SerializeField] GameObject _escapeOptionWnd;
    EscapeOptionWnd _escapeWindow = null;
    //임시
    //EscapeOptionWnd _wndExit;
    //==
    DefineHelper.eSelectItemKind itemType;
    DefineHelper.eSceneIndex _prevScene;
    DefineHelper.eSceneIndex _currScene;
    public DefineHelper.eSceneIndex currentScene
    {
        get { return _currScene; }
    }
    public static SceneControlManager _instance
    {
        get { return _uniqueInstance; }
    }


    private void Awake()
    {
        _uniqueInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //임시
        //SceneManager.LoadScene(DefineHelper.eSceneIndex.MainScene.ToString());
        StartMainScene();
        //====
    }
    private void Update()
    {
        #region[강사님 코드]
        //if (Input.GetButtonDown("Cancel"))
        //{
        //    LoadingWnd wnd = GameObject.FindObjectOfType<LoadingWnd>();
        //    if(wnd != null)
        //        return;
        //    if (_wndExit == null)
        //    {
        //        GameObject prefab = ResoucePoolManager._instance.GetUIPrefabFromType(DefineHelper.eUIWindowType.LoadingWnd);
        //        GameObject go = Instantiate(prefab, transform);
        //        _wndExit = go.GetComponent<EscapeOptionWnd>();
        //        _wndExit.OpenDialogWindow("게임을 종료하시겠습니까?", DefineHelper.eDialogType.Exit);
        //    }
        //    else if (_wndExit.gameObject.activeSelf)
        //        _wndExit.PushCancel();
        //    else
        //        _wndExit.OpenDialogWindow("게임을 종료하시겠습니까?", DefineHelper.eDialogType.Exit);
        //}
        #endregion
        if (_isLoading) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isOpenEscapeWnd)
            {
                _escapeWindow.ClickCancelButton();
            }
            else
            {
                _isOpenEscapeWnd = true;
                if (currentScene == DefineHelper.eSceneIndex.IngameScene)
                    Time.timeScale = 0;
                if (_escapeWindow == null)
                {
                    GameObject go = Instantiate(_escapeOptionWnd);
                    _escapeWindow = go.GetComponent<EscapeOptionWnd>();
                }
                else
                {
                    _escapeWindow.gameObject.SetActive(true);
                }

            }
        }
    }

    public void StartMainScene()
    {
        _prevScene = _currScene;
        _currScene = DefineHelper.eSceneIndex.MainScene;
        StartCoroutine(LoadingScene(DefineHelper.eSceneIndex.MainScene.ToString()));

        SoundManager._instance.PlayBGMSound(DefineHelper.eBGMClipType.MainScene);
    }

    public void StartIngameScene(DefineHelper.eSelectItemKind type)
    {
        _prevScene = _currScene;
        _currScene = DefineHelper.eSceneIndex.IngameScene;
        StartCoroutine(LoadingScene(DefineHelper.eSceneIndex.IngameScene.ToString(), type));
        SoundManager._instance.PlayBGMSound(DefineHelper.eBGMClipType.IngameScene);
    }

    IEnumerator LoadingScene(string sceneName,DefineHelper.eSelectItemKind itemType = DefineHelper.eSelectItemKind.NoItem)
    {
        GameObject prefab = ResoucePoolManager._instance.GetUIPrefabFromType(DefineHelper.eUIWindowType.LoadingWnd);
        GameObject go = Instantiate(prefab, transform);
        LoadingWnd wnd = go.GetComponent<LoadingWnd>();
        wnd.OpenWindow();
        yield return new WaitForSeconds(2);
        AsyncOperation aOper =  SceneManager.LoadSceneAsync(sceneName);
        while(!aOper.isDone)
        {
            wnd.SetLoadingProgress(aOper.progress);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        wnd.SetLoadingProgress(aOper.progress);
        while(wnd != null)
            yield return null;
        // 씬 시작처리....
        if(_currScene == DefineHelper.eSceneIndex.IngameScene)
        {
            int no = UserInfoManager._Instance._nowStageNumber;
            DefineHelper.stStageInfo info = ResoucePoolManager._instance.GetStageInfo(no);
            IngameManager._instance.InitializeSettings(info, itemType);
        }   
    }
}
