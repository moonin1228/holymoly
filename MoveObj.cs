using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    //http://www.pixelplacement.com/itween/index.php
    
    [SerializeField] GameObject _ball;
    [SerializeField] GameObject _capsule;
    Vector3 _cubeStartPos;
    void Start()
    {
        _cubeStartPos = transform.position;
        iTween.RotateBy(gameObject, iTween.Hash("amount", Vector3.up, "time", 5, 
                                                "oncomplete", "MoveToCube", "oncompletetarget",gameObject));
    }

    void MoveToCube()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", _ball.transform.position, "time", 3,
                                                 "oncomplete", "MoveToBall", "oncompletetarget", gameObject));
    }

    void MoveToBall()
    {
        iTween.MoveTo(_ball, iTween.Hash("position", _cubeStartPos, "time", 3,
                                                "oncomplete", "MoveCapsule", "oncompletetarget", gameObject));
    }

    void MoveCapsule()
    {
        iTween.MoveTo(_capsule, iTween.Hash("position", _cubeStartPos - (Vector3.right * 2), "time", 3,
                                                "onstart", "ScaleCapsule", "onstarttarget", gameObject));
    }

    void ScaleCapsule()
    {
        iTween.ScaleAdd(_capsule, iTween.Hash("amount", Vector3.one, "time", 3));
    }
}
//Cube, 5초간 돈다 > 공이 있는 위치로 이동 > 공이 이동값의 반대값으로 이동 > 캡슐이 커지면서 어디선가 옆으로 이동(공 옆으로)
//      Rotate,             MoveTo,                 -MoveTo,                                Scale + MoveTo
