using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFromControl : MonoBehaviour
{
    void Start()
    {
        iTween.MoveFrom(gameObject, iTween.Hash("x", -10, "z", 9, "y", -12, "time", 5));
    }
}
