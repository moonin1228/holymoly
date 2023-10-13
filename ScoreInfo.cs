using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInfo : MonoBehaviour
{
    [SerializeField] Image _bugsIcon;
    [SerializeField] Text _txtPerPoint;

    public void InitDataSet(DefineHelper.eInsectKind kind)
    {
        _bugsIcon.sprite = ResoucePoolManager._instance.GetInsectTypeIcon(kind);
        _txtPerPoint.text = DefineHelper._baseScorePerInsect[(int)kind].ToString();
    }

    public Color GetInsectKindColor(DefineHelper.eInsectKind kind)
    {
        Color color = Color.white;
        switch (kind)
        {
            case DefineHelper.eInsectKind.RedAnt:
                break;
                //case DefineHelper.eInsectKind.BlackInsect:
                //    break;
        }
        return color;
    }
}
