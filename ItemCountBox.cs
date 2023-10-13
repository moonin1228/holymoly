using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCountBox : MonoBehaviour
{
    [SerializeField] Image _itemImg;
    [SerializeField] Text _useCountTxt;
    public void InitSetData(DefineHelper.eSelectItemKind type)
    {
        _useCountTxt.text = "0";
        _itemImg.sprite = ResoucePoolManager._instance.GetItemSpriteFromType(type);
        switch (type)
        {
            case DefineHelper.eSelectItemKind.NoItem:
                _itemImg.color = Color.red;
                break;
            case DefineHelper.eSelectItemKind.Bomb:
                _itemImg.color = Color.white;
                _useCountTxt.gameObject.SetActive(true);
                break;
            case DefineHelper.eSelectItemKind.Clock:
                _itemImg.color = Color.blue;
                _useCountTxt.gameObject.SetActive(true);
                break;
        }
    }

    public void UseCountUp(int count)
    {
        _useCountTxt.text = count.ToString();
    }
}
