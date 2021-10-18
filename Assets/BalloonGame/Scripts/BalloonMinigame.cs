using System;
using UnityEngine;
using UnityEngine.UI;

public class BalloonMinigame : Minigame
{
    [SerializeField] private float playTime = 60f;
    [Header("UI")]
    [SerializeField] private GameObject postgameScreen;
    [SerializeField] private GameObject ingameParent;
    [SerializeField] private Text timerLabel;
    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text postGameScoreLabel;
    
    private int _currentScore;
    private float _currentTime;
    
    public static bool GameOver { get; private set; }

    void Start()
    {
        _currentTime = playTime;
        ToggleGameComponents();
    }
    
    void Update()
    {
        timerLabel.text = Mathf.Round(_currentTime).ToString() + " s";
        
        if(_currentTime <= 0) 
        {
            GameOver = true;
            postGameScoreLabel.text = _currentScore.ToString();
            ToggleGameComponents();
            return;
        }
        
        _currentTime -= Time.deltaTime;
    }

    public void Restart()
    {
        GameOver = false;
        ResetGameLabels();
        ToggleGameComponents();
    }

    public void Exit()
    {
        ARManager.EndCurrentGame();
        Balloon[] balloons = FindObjectsOfType<Balloon>();
        foreach (Balloon balloon in balloons)
            Destroy(balloon.gameObject);
        
        Destroy(gameObject);
    }

    private void ResetGameLabels()
    {
        _currentScore = 0;
        scoreLabel.text = "0";
        
        _currentTime = playTime;
        timerLabel.text = playTime.ToString();
    }

    private void ToggleGameComponents()
    {
        ingameParent.SetActive(!GameOver);
        postgameScreen.SetActive(GameOver);
    }

    public override void AddScore(int score)
    {
        _currentScore += score;
        scoreLabel.text = _currentScore.ToString();
    }
}
