using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByControl : MonoBehaviour
{
    void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash("z", 15, "y", 9, "time", 1.8f, "delay", 5.1f, "easetype", iTween.EaseType.easeOutBounce));        //해당하는 값만큼 이동. 위치를 바꿔도!
    }
}
