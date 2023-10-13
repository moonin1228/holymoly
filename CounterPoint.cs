using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterPoint : MonoBehaviour
{
    [SerializeField] Image _icon;           //벌레 아이콘
    [SerializeField] Text _txtCount;        //죽인 카운트 값

    
    public void InitSetData(Sprite s)       //초기값 초기화
    {
        _icon.sprite = s;
        _txtCount.text = "0";
    }

    public void SetCount(int cnt)           //잡은 벌레 카운트 UP
    {
        _txtCount.text = cnt.ToString();
    }
}
