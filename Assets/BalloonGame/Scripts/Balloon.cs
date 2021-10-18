using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private ParticleSystem smokeSystem;
    [SerializeField] private Vector3 speed; 
    [SerializeField] private int value;

    void Update()
    {
        if (BalloonMinigame.GameOver)
        {
            Destroy(gameObject);
            return;
        }

        transform.Translate(Vector3.up * (Time.deltaTime * speed.y));

        float xSpeed = Mathf.PingPong(Time.time, speed.x) - speed.x / 2;
        float zSpeed = Mathf.PingPong((Time.time + 1), speed.z) - speed.z / 2;
        transform.Translate(Vector3.left * (Time.deltaTime * xSpeed));
        transform.Translate(Vector3.forward * (Time.deltaTime * zSpeed));    
    }

    public int Shoot(RaycastHit hit)
    {
        ParticleSystem ps = Instantiate(smokeSystem, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(ps.gameObject, 5f);
        Destroy(gameObject);
        return value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }
    }
}
