using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 3.0f;

    void Update(){
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
