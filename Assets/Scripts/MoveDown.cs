using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 3.0f;

    void Update(){
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
