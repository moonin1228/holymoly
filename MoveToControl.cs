using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToControl : MonoBehaviour
{
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", 5.0f, "y", 5.0f, "z", 5.0f, "time", 3.0f, "delay", 5));        //gameObject를 y축 5로 3초동안 이동한다. y축 5로 이동하는데 3초가 걸린다. 지정한 위치로 이동한다.
    }
}
