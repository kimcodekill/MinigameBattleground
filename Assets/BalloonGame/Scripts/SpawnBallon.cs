using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallon : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] ballons;
    public float spawnTimer;
    private float countDown = 0;
    
   
    void Start()
    {
        
    }

    private void Update()
    {
        
       
        if(countDown <= 0 && !GameController.gameOver)
        {
            
                Instantiate(ballons[Random.Range(0, ballons.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            

            countDown = spawnTimer;
        }
        countDown -= Time.deltaTime;
    }


    
}
