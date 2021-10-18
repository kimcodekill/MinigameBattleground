using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballons : MonoBehaviour
{
    public float speed, xSpeed, zSpeed, score;

 
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!GameController.gameOver)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            transform.Translate(Vector3.left * Time.deltaTime * (Mathf.PingPong(Time.time, xSpeed) - xSpeed / 2));
            transform.Translate(Vector3.forward * Time.deltaTime * (Mathf.PingPong((Time.time + 1), zSpeed) - zSpeed / 2));
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }
    }
}
