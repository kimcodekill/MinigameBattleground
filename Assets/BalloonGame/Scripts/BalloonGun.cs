using System;
using UnityEngine;
using UnityEngine.UI;

public class BalloonGun : MonoBehaviour
{
    [SerializeField] private BalloonMinigame gameManager;

    private Transform _camera;
    
    private float score;

    private void Awake()
    {
        _camera = Camera.main.transform;
    }

    public void Fire()
    {        
        if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Balloon") && !BalloonMinigame.GameOver)
            {
                Balloon b = hit.transform.gameObject.GetComponent<Balloon>();
                gameManager.AddScore(b.Shoot(hit));
                GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
            }
        }
    }
}
