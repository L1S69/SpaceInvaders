using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text score;
    [SerializeField] private Text hp;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.GameOver += OnGameOver;
        EventManager.ScoreChanged += OnScoreChanged;
        EventManager.HPChanged += OnHPChanged;
    }

    private void OnDisable()
    {
        EventManager.GameOver -= OnGameOver;
        EventManager.ScoreChanged -= OnScoreChanged;
        EventManager.HPChanged -= OnHPChanged;
    }

    private void OnScoreChanged(int num)
    {
        score.text = $"{num}";
    }

    private void OnHPChanged(int num)
    {
        hp.text = $"{num}";
    }
    
    private void OnGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
