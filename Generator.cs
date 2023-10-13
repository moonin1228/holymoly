using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] _enermies;
    BoxCollider2D rangeCollider;
    public GameObject rangeObject;
    void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }
    void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }
    Vector2 Return_RandomPosition()
    {
        //Instantiate(_fishObject[3]);
        Vector2 originPosition = rangeObject.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.y;
        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector2 RandomPostion = new Vector2(range_X, range_Z);

        Vector2 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;


 
    }


    public IEnumerator RandomRespawn_Coroutine()
    {
      

        for (int n = 0; n < _enermies.Length; n++)
        {
            yield return new WaitForSeconds(1f);

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject go = Instantiate(_enermies[n], Return_RandomPosition(), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            go.transform.SetParent(this.transform);

        



        }


    }
}
