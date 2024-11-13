using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    // Set up arrays of prefabs for objects based on what direction they move
    // As long as they're organized with the proper floats, this makes sure objects move from one side of the screen to the other properly
    public GameObject[ ] downMoving;
    public GameObject[ ] leftMoving;
    public GameObject[ ] rightMoving;
    public GameObject[ ] upMoving;
    
    public float spawnRangeX = 8.4f;
    public float spawnPointX = 10.0f;
    public float spawnRangeY = 4.5f;
    public float spawnPointY = 6.0f;

    private float startDelay = 2;
    private float spawnInterval = 0.8f;

    void Start(){
        InvokeRepeating("SpawnDownMovers", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftMovers", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightMovers", startDelay, spawnInterval);
        InvokeRepeating("SpawnUpMovers", startDelay, spawnInterval);
        InvokeRepeating("Countdown", 0, 1);
    }

    void SpawnDownMovers(){
        int downIndex = Random.Range(0, downMoving.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPointY, 0);
        Instantiate(downMoving[downIndex], spawnPos, downMoving[downIndex].transform.rotation);
    }

    void SpawnLeftMovers(){
        int leftIndex = Random.Range(0, leftMoving.Length);
        Vector3 spawnPos = new Vector3(spawnPointX, Random.Range(-spawnRangeY, spawnRangeY), 0);
        Instantiate(leftMoving[leftIndex], spawnPos, leftMoving[leftIndex].transform.rotation);
    }

    void SpawnRightMovers(){
        int rightIndex = Random.Range(0, rightMoving.Length);
        Vector3 spawnPos = new Vector3(-spawnPointX, Random.Range(-spawnRangeY, spawnRangeY), 0);
        Instantiate(rightMoving[rightIndex], spawnPos, rightMoving[rightIndex].transform.rotation);
    }

    void SpawnUpMovers(){
        int upIndex = Random.Range(0, upMoving.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -spawnPointY, 0);
        Instantiate(upMoving[upIndex], spawnPos, upMoving[upIndex].transform.rotation);
    }

    // This section was initially separate code called "Timer", but
    // disabling the Game Manager object didn't work to stop spawning
    // things because I used InvokeRepeating.

    private int timeLimit = 61;
    public TextMeshProUGUI timerText;

    void Countdown(){
        timeLimit--;
        timerText.text = "" + timeLimit;
        if(timeLimit < 1){
            timerText.text = "GAME OVER";
            CancelInvoke();
        }
    }
}
