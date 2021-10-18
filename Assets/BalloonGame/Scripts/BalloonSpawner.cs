using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] balloons;
    [SerializeField] private float spawnTimer;
    private float countDown;

    private void OnEnable()
    {
        countDown = spawnTimer;
    }

    private void Update()
    {
        if(countDown <= 0 && !BalloonMinigame.GameOver)
        {
            Instantiate(GetRandomBalloon(), GetRandomSpawnPoint(), Quaternion.identity);
            countDown = spawnTimer;
        }
        countDown -= Time.deltaTime;
    }

    private GameObject GetRandomBalloon()
    {
        return balloons[Random.Range(0, balloons.Length)];
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return transform.GetChild(Random.Range(0, transform.childCount)).position;
    }
}
