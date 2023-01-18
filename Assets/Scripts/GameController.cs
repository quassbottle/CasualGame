using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [SerializeField] private TMP_Text _scoreText;
    public float maxY = 37f;
    public bool win;
    //public int score = 0;
    //private int _highscore;

    private void Start()
    {
        //_highscore = PlayerPrefs.GetInt("Highscore");
    }
    private void Awake()
    {
        InitSingleton();
    }
    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        //_highscore = Math.Max(score, _highscore);
        
        //string text = $"Score: {score}\nHighscore: {_highscore}";
        if (Player.instance.isDead && !win)
        {
            _scoreText.text = "Press \"R\" to restart.";
        }
        else if (win)
        {
            _scoreText.text = "Demo level has been completed! Press \"R\" to restart.";
        }
        //else _scoreText.text = text;
        if (Input.GetKeyDown(KeyCode.R))
        {
            //PlayerPrefs.SetInt("Highscore", _highscore);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
