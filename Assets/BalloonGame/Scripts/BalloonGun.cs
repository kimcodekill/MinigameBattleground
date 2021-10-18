using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class BalloonGun : MonoBehaviour
{
    [SerializeField] private BalloonMinigame gameManager;

    private Transform _camera;
    
    private float score;

    private void OnEnable()
    {
        _camera = FindObjectOfType<ARCameraManager>().transform;
    }

    private void Update()
    {
        if(BalloonMinigame.GameOver)
            return;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began) 
                Fire();
        }
    }

    public void Fire()
    {        
        if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Balloon"))
            {
                Balloon b = hit.transform.gameObject.GetComponent<Balloon>();
                gameManager.AddScore(b.Shoot(hit));
                GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
            }
        }
    }
}
