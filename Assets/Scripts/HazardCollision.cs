using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HazardCollision : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    void Start(){
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player1")){
            Player1.SetActive(false);
            StartCoroutine(Respawn1());
        }else if (other.gameObject.CompareTag("Player2")){
            Player2.SetActive(false);
            StartCoroutine(Respawn2());
        }
    }

    IEnumerator Respawn1(){
        yield return new WaitForSeconds(3);
        Player1.SetActive(true);
        Player1.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(3);
        Player1.GetComponent<Collider2D>().enabled = true;
    }
    IEnumerator Respawn2(){
        yield return new WaitForSeconds(3);
        Player2.SetActive(true);
        Player2.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(3);
        Player2.GetComponent<Collider2D>().enabled = true;
    }
}