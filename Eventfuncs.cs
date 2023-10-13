using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventfuncs : MonoBehaviour
{
    public void CloseDoorEnd()
    {
        #region[정석]
        //if(owner != null)
        //{
        //    LoadingWnd wnd = owner.GetComponent<LoadingWnd>();
        //    if(wnd != null)
        //    {
        //        wnd.EnableContants();
        //    }
        //}
        #endregion
        LoadingWnd wnd = transform.parent.GetComponent<LoadingWnd>();
        if (wnd != null)
            wnd.EnableContants();
        else
            Debug.LogError("LoadingWnd를 찾을 수가 없습니다.");
    }

    public void OpneDoorEnd()
    {
        LoadingWnd wnd = transform.parent.GetComponent<LoadingWnd>();
        if (wnd != null)
            wnd.Close();
        else
            Debug.LogError("LoadingWnd를 찾을 수가 없습니다.");
    }
}
