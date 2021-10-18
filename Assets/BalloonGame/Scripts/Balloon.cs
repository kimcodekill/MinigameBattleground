using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private Vector3 speed; 
    [SerializeField] private float value;

    public float Value => value;

    void Update()
    {
        if (!GameController.gameOver)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * speed.y));

            float xSpeed = Mathf.PingPong(Time.time, speed.x) - speed.x / 2;
            float zSpeed = Mathf.PingPong((Time.time + 1), speed.z) - speed.z / 2;
            transform.Translate(Vector3.left * (Time.deltaTime * xSpeed));
            transform.Translate(Vector3.forward * (Time.deltaTime * zSpeed));
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
