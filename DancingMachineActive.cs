using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingMachineActive : MonoBehaviour
{
    Animator _aniCtrl;

    private void Awake()
    {
        _aniCtrl = GetComponent<Animator>();
    }

    public void EndDance()
    {
        int index = Random.Range(0, 3);
        _aniCtrl.SetInteger("ChoiceDance", index);


        //int ran = 0;
        //string _aniName = "isDance1";
        //_aniCtrl.SetBool(_aniName, false);
        //ran = Random.Range(0, 3);
        //switch (ran)
        //{
        //    case 0:
        //        _aniName = "isDance1";
        //        break;
        //    case 1:
        //        _aniName = "isDance2";
        //        break;
        //    case 2:
        //        _aniName = "isDance3";
        //        break;
        //}
        //_aniCtrl.SetBool(_aniName, true);
        //Debug.Log(_aniName + "  추는 중~");
    }
}
