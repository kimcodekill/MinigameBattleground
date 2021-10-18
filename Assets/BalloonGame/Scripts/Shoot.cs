using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject arCamera, smoke;
    
    private float score;

    public void Shooting()
    {        
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out RaycastHit hit))
        {
            if ((hit.transform.name == "balloon1(Clone)" || hit.transform.name == "balloon2(Clone)" || hit.transform.name == "balloon3(Clone)") && !GameController.gameOver)
            {
                Debug.Log(hit.transform.gameObject);
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                score += hit.transform.gameObject.GetComponent<Balloon>().Value;
                GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
            }
        }
    }

    
}
