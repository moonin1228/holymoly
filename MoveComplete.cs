using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComplete : MonoBehaviour
{
    [SerializeField] GameObject _ball2;
    [SerializeField] GameObject _ball3;
    void Start()
    {
        iTween.MoveFrom(gameObject, iTween.Hash("x", -15, "z", -3, "delay", 2.8f, "time", 5
                                                   , "easetype", iTween.EaseType.easeOutBounce,
                                                  "oncomplete", "ObjectMoveTo", "oncompletetarget", gameObject));
    }

    void ObjectMoveTo()
    {
        iTween.MoveTo(_ball2, iTween.Hash("y", 8, "z", 10, "time", 4,
                                            "easetype", iTween.EaseType.easeOutElastic,
                                            "oncomplete", "ObjectMoveBy", "oncompletetarget", gameObject));
    }

    void ObjectMoveBy()
    {
        iTween.MoveBy(_ball3, iTween.Hash("y", -10, "z", 6, "time", 6,
                                            "easetype", iTween.EaseType.easeOutQuint));
    }
}
