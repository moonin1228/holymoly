using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRoot : MonoBehaviour
{
    [SerializeField] GameObject[] _mapBG;


    private void Awake()
    {
        ResoucePoolManager._instance.GetMapSprite(_mapBG);
    }
}
