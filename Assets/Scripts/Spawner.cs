using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject alienPrefab;
    private int _aliensOnScene;

    private void Start()
    {
        SpawnAliens();
    }

    private void OnEnable()
    {
        EventManager.EnemyDestroyed += OnEnemyDestroyed;
    }

    private void OnDisable()
    {
        EventManager.EnemyDestroyed -= OnEnemyDestroyed;
    }

    private void SpawnAliens()
    {
        for(float i = -6; i <= 6; i += 1.5f)
        {
            for(float j = 4; j >= 1; j -= 1.5f)
            {
                Instantiate(alienPrefab, new Vector2(i, j), transform.rotation);
                _aliensOnScene++;
            }
        }
    }

    private void OnEnemyDestroyed()
    {
        _aliensOnScene--;
        if(_aliensOnScene == 0) Invoke(nameof(SpawnAliens), 1f); 
    }
}
