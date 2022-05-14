using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(Shooter))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject doubleBulletPrefab;
    [SerializeField] private GameObject tripleBulletPrefab;
    private PlayerController _playerController;
    private Shooter _shooter;
    private int _hp;
    private int _score;

    private int _currentBulletPrefab = 1;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _shooter = GetComponent<Shooter>();
        _hp = 3;
        _score = 0;
    }

    private void OnEnable()
    {
        EventManager.EnemyDestroyed += OnEnemyDestroyed;
        EventManager.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        EventManager.EnemyDestroyed -= OnEnemyDestroyed;
        EventManager.GameOver -= OnGameOver;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("AlienBullet"))
        {
            _hp--;
            EventManager.OnHPChanged(_hp);
            if(_hp == 0) EventManager.OnGameOver();
        } else if(other.CompareTag("Alien"))
        {
            _hp = 0;
            EventManager.OnHPChanged(_hp);
            EventManager.OnGameOver();
        } else if(other.CompareTag("Double") && _currentBulletPrefab < 3)
        {
            _shooter.bulletPrefab = doubleBulletPrefab;
            _shooter.offset = new Vector3(-0.6f, 0f, 0f);
            _currentBulletPrefab = 2;
        } else if(other.CompareTag("Triple"))
        {
            _shooter.bulletPrefab = tripleBulletPrefab;
            _shooter.offset = new Vector3(-0.7f, 0f, 0f);
            _currentBulletPrefab = 3;
        }
    }

    private void OnEnemyDestroyed()
    {
        _score++;
        EventManager.ScoreChanged(_score);
    }

    private void OnGameOver()
    {
        _playerController.enabled = false;
    }
}
