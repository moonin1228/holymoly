using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountBox : MonoBehaviour
{
    [SerializeField] RectTransform _boardBG;                //카운터의 배경

    float _baseSize = 105;          //카운터 배경의 기본 Y값 사이즈
    float _offsetY = 5;             //카운터 배경간의 거리

    Dictionary<DefineHelper.eInsectKind, CounterPoint> _ptnCounts;          //벌레의 종류수만큼 카운터를 만들어주기위해
    
    public void InitSetData(DefineHelper.eInsectKind[] kinds)
    {
        _ptnCounts = new Dictionary<DefineHelper.eInsectKind, CounterPoint>();
        _boardBG.sizeDelta = new Vector2(_boardBG.sizeDelta.x, _offsetY + (_baseSize * kinds.Length));

        GameObject props = ResoucePoolManager._instance.GetUIPropsPrefabFromType(DefineHelper.eUIPropsType.CountingProps);
        for (int n= 0;n < kinds.Length;n++)
        {
            GameObject go = Instantiate(props, _boardBG);
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(_offsetY, -_offsetY - (_baseSize * n));

            CounterPoint cp = go.GetComponent<CounterPoint>();
            cp.InitSetData(ResoucePoolManager._instance.GetInsectTypeIcon(kinds[n]));
            _ptnCounts.Add(kinds[n], cp);
        }
    }
    public void SetCount(DefineHelper.eInsectKind kind, int count)
    {
        _ptnCounts[kind].SetCount(count);
    }
}
