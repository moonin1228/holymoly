using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //스틱 컨트롤러 참조해오기
    public bl_Joystick _stick;
    public float speed;






    void Update()
    {
        Vector3 dir = new Vector3(_stick.Horizontal, _stick.Vertical, 0); //x, y 축이동

        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
    }
}
