using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public float timer = 60f;
    public static bool gameOver = false;
    private GameObject postgameScreen;
    private Text finalScore;

    void Start()
    {
        postgameScreen = GameObject.Find("Postgame");
        finalScore = GameObject.Find("FinalScore").GetComponent<Text>();
        Debug.Log(postgameScreen);
        postgameScreen.SetActive(false);
    }

    
    void Update()

    {
        
        
        
        GameObject.Find("Timer").GetComponent<Text>().text = Mathf.Round(timer).ToString() + " s";
        if(timer >= 0) 
        {
            timer -= Time.deltaTime;
        }
        else
        {
            postgameScreen.SetActive(true);
            finalScore.text = GameObject.Find("Score").GetComponent<Text>().text;
            gameOver = true;
        }
    }

    public void Restart()
    {
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
