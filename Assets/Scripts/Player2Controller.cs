using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController2 : MonoBehaviour
{
    public GameObject Player2;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 6.0f;
    public float xRange = 8.4f;
    public float yRange = 4.5f;

    void Update()
    {
        // Get player input
        horizontalInput = Input.GetAxis("HorizontalP2");
        verticalInput = Input.GetAxis("VerticalP2");
        // Use player input to move
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        // These if statements keep them from going out of bounds
        if (transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange) {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.y > yRange) {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }

    private Vector3 scaleChange = new Vector3(0.025f, 0.025f, 0.025f);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food")){
            Destroy(other.gameObject);
            transform.localScale += scaleChange;
        }else if (other.gameObject.CompareTag("Hazard")){
            StartCoroutine(Respawn());
            Player2.SetActive(false);
        }
    }

    IEnumerator Respawn(){
        yield return new WaitForSeconds(5);
        Player2.SetActive(true);
    }
}