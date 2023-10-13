using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBox : MonoBehaviour
{
    //시간관련 연산은 IngameManager
    [SerializeField] Text _txtSec;              //타이머의 초 Text
    [SerializeField] Text _txtMiliSec;      //타이머의 백분초 Text

    //타이머의 초기값 초기화
    public void InitSetData(float timerTime)        //게임의 제한시간을 받아옴
    {
        SettingTimer(timerTime);
    }

    //타이머의 Text 변환
    public void SettingTimer(float remainedTime)            //게임 제한시간 받아옴
    {
        int sec = (int)remainedTime;                                      //남은 초를 int형으로 형변환값
        int msec = (int)((remainedTime - sec) * 100);           //정수값을 빼서 소수점아래 실수만 구한뒤 100을 곱해 2자리만 담는다.

        _txtSec.text = sec.ToString();
        if(msec < 10)
        {
            _txtMiliSec.text = "0" + msec.ToString();
        }
        else
        {
            _txtMiliSec.text = msec.ToString();
        }
    }
}
