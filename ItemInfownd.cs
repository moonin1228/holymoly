using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfownd : MonoBehaviour
{
    //클릭한 아이템이 뭔지 확인하는 변수
    DefineHelper.eSelectItemKind _itemType;
    [SerializeField] Image[] _itemBGIcons;

    public void OpenItemInfoWnd()
    {
        //열릴때 클릭된 정보들 다 초기화
        _itemType = DefineHelper.eSelectItemKind.NoItem;
        //SelectItemBG(_itemType);
    }

    public void ClickNoItemButton()
    {
        _itemType = DefineHelper.eSelectItemKind.NoItem;
        SelectItemBG(_itemType);
    }
    public void ClickBombItemButton()
    {
        _itemType = DefineHelper.eSelectItemKind.Bomb;
        SelectItemBG(_itemType);
    }
    public void ClickClockItemButton()
    {
        _itemType = DefineHelper.eSelectItemKind.Clock;
        SelectItemBG(_itemType);
    }
    public void ClickCloseButton()
    {
        gameObject.SetActive(false);
    }

    void SelectItemBG(DefineHelper.eSelectItemKind type)
    {
        for(int i = 0; i < (int)DefineHelper.eSelectItemKind.Max_Count;i++)
        {
            if(i == (int)type)
            {
                _itemBGIcons[i].color = Color.green;
            }
            else
            _itemBGIcons[i].color = Color.white;
        }
        
    }

    public void ClickStartGameButton()
    {
        SceneControlManager._instance.StartIngameScene(_itemType);
    }
}
