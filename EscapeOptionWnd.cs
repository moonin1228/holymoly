using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EscapeOptionWnd : MonoBehaviour
{
    #region[MY CODE]
    //public void ClickExitButton()
    //{
    //    Time.timeScale = 1;
    //    SceneControlManager._instance.StartMainScene();
    //}
    //public void ClickCancelButton()
    //{
    //    //3초 카운트후 이어하기?
    //    Time.timeScale = 1;
    //    IngameManager._instance._isOpenEscapeWnd = false;
    //    Destroy(gameObject);
    //}
    #endregion
    #region[MY CODE]
    public void ClickOkButton()
    {
        if (SceneControlManager._instance.currentScene == DefineHelper.eSceneIndex.IngameScene)
        {
            Time.timeScale = 1;
            SceneControlManager._instance._isOpenEscapeWnd = false;
            SceneControlManager._instance.StartMainScene();
        }
        else
        {
            UserInfoManager._Instance.SaveData();
#if UNITY_EDITOR            //전처리기 = 컴파일할때 걸러질지 말지 검사?체크?
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
    public void ClickCancelButton()
    {
        if (SceneControlManager._instance.currentScene == DefineHelper.eSceneIndex.IngameScene)
        {
            Time.timeScale = 1;
            SceneControlManager._instance._isOpenEscapeWnd = false;
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
        else
        {
            SceneControlManager._instance._isOpenEscapeWnd = false;
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    #endregion
    #region[강사님코드]
    //    [SerializeField] Text _txtDialog;
    //    [SerializeField] EventTrigger _firstBtn;
    //    [SerializeField] EventTrigger _secondBtn;
    //    [SerializeField] Button _closeBtn;

    //    public void OpenDialogWindow(string dialMessage,DefineHelper.eDialogType type = DefineHelper.eDialogType.Notification)
    //    {
    //        gameObject.SetActive(true);
    //        _txtDialog.text = dialMessage;

    //        if (SceneControlManager._instance.currentScene == DefineHelper.eSceneIndex.IngameScene)
    //            Time.timeScale = 0;
    //        SettingButtonBranchFromType(type);
    //    }

    //    public void PushCancel()
    //    {
    //        if (SceneControlManager._instance.currentScene == DefineHelper.eSceneIndex.IngameScene)
    //            Time.timeScale = 1;
    //        gameObject.SetActive(false);
    //    }

    //    /// <summary>
    //    /// 대화창의 type에 따라 버튼 변경 함수
    //    /// </summary>
    //    /// <param name="type">DialogType</param>

    //    void SettingButtonBranchFromType(DefineHelper.eDialogType type)
    //    {
    //        EventTrigger.Entry entryClickFirst = new EventTrigger.Entry();
    //        entryClickFirst.eventID = EventTriggerType.PointerClick;
    //        EventTrigger.Entry entryClickSecond = new EventTrigger.Entry();
    //        entryClickSecond.eventID = EventTriggerType.PointerClick;
    //        switch(type)
    //        {
    //            case DefineHelper.eDialogType.Notification:
    //                _firstBtn.transform.GetChild(0).GetComponent<Text>().text = "OK";
    //                _firstBtn.transform.GetChild(1).GetComponent<Text>().text = "OK";
    //                _firstBtn.gameObject.SetActive(true);
    //                _secondBtn.gameObject.SetActive(false);
    //                entryClickFirst.callback.AddListener(delegate { ClickCancelButton(); });
    //                _firstBtn.triggers.Add(entryClickFirst);
    //                _closeBtn.onClick.AddListener(ClickCancelButton);
    //                break;
    //            case DefineHelper.eDialogType.Warnung:
    //                _firstBtn.transform.GetChild(0).GetComponent<Text>().text = "Cancel";
    //                _firstBtn.transform.GetChild(1).GetComponent<Text>().text = "Cancel";
    //                _secondBtn.transform.GetChild(0).GetComponent<Text>().text = "OK";
    //                _secondBtn.transform.GetChild(1).GetComponent<Text>().text = "OK";
    //                _firstBtn.gameObject.SetActive(true);
    //                _secondBtn.gameObject.SetActive(true);
    //                entryClickFirst.callback.AddListener(delegate { ClickCancelButton(); });
    //                _firstBtn.triggers.Add(entryClickFirst);
    //                entryClickSecond.callback.AddListener(delegate { ClickOkButton(); });
    //                _secondBtn.triggers.Add(entryClickSecond);
    //                _closeBtn.onClick.AddListener(ClickCancelButton);
    //                break;
    //            case DefineHelper.eDialogType.Exit:
    //                _firstBtn.transform.GetChild(0).GetComponent<Text>().text = "Cancel";
    //                _firstBtn.transform.GetChild(1).GetComponent<Text>().text = "Cancel";
    //                _secondBtn.transform.GetChild(0).GetComponent<Text>().text = "Exit";
    //                _secondBtn.transform.GetChild(1).GetComponent<Text>().text = "Exit";
    //                _firstBtn.gameObject.SetActive(true);
    //                _secondBtn.gameObject.SetActive(true);
    //                entryClickFirst.callback.AddListener(delegate { ClickExitCancelButton(); });
    //                _firstBtn.triggers.Add(entryClickFirst);
    //                entryClickSecond.callback.AddListener(delegate { ClickExitButton(); });
    //                _firstBtn.triggers.Add(entryClickSecond);
    //                _closeBtn.onClick.AddListener(ClickExitCancelButton);
    //                break;
    //        }
    //    }

    //    void ClickExitCancelButton()
    //    {
    //        if (SceneControlManager._instance.currentScene == DefineHelper.eSceneIndex.IngameScene)
    //            Time.timeScale = 1;
    //        gameObject.SetActive(false);
    //    }

    //    void ClickExitButton()
    //    {
    //#if UNITY_EDITOR
    //        UnityEditor.EditorApplication.isPlaying = false;
    //#else
    //        Application.Quit();
    //#endif

    //        if(SceneControlManager._instance.currentScene == DefineHelper.eSceneIndex.IngameScene)
    //            Time.timeScale = 1;
    //        gameObject.SetActive(false);
    //    }

    //    void ClickCancelButton()
    //    {
    //        if (SceneControlManager._instance.currentScene == DefineHelper.eSceneIndex.IngameScene)
    //            Time.timeScale = 1;
    //        gameObject.SetActive(false);
    //    }

    //    void ClickOkButton()
    //    {
    //        if (SceneControlManager._instance.currentScene == DefineHelper.eSceneIndex.IngameScene)
    //            Time.timeScale = 1;
    //        gameObject.SetActive(false);
    //    }
    #endregion


}
