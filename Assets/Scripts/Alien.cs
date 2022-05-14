using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Shooter))]
public class Alien : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject doublePrefab;
    [SerializeField] private GameObject triplePrefab;
    private Rigidbody2D _rigidbody;
    private Shooter _shooter;
    private float _movementDirection;
    private Vector3 _verticalMovement;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _shooter = GetComponent<Shooter>();
        _movementDirection = 1f;
        _verticalMovement = new Vector3(0f, -0.3f, 0f);
        InvokeRepeating(nameof(Shoot), 1f, 3f);
    }

    private void OnEnable()
    {
        EventManager.DirectionChanged += ChangeDirection;
    }

    private void OnDisable()
    {
        EventManager.DirectionChanged -= ChangeDirection;
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.right * speed * _movementDirection;
        if(transform.position.x > 9f) 
        {
            EventManager.OnDirectionChanged(-1f);
        }
        if(transform.position.x < -9f) 
        {
            EventManager.OnDirectionChanged(1f);
        }
        if(transform.position.y < -4f)
        {
            EventManager.OnHPChanged(0);
            EventManager.OnGameOver();
        }
    }

    private void ChangeDirection(float num)
    {
        _movementDirection = num;
        transform.position += _verticalMovement;
    }

    private void Shoot()
    {
        int temp = Random.Range(0, 4);
        if(temp != 1) return;
        _shooter.Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            EventManager.OnEnemyDestroyed();
            DropLoot();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void DropLoot()
    {
        int temp = Random.Range(1,301);
        if(temp > 289 && temp < 300) 
        {
            Instantiate(doublePrefab, transform.position, transform.rotation);
        }
        else if (temp == 300) 
        {
            Instantiate(triplePrefab, transform.position, transform.rotation);
        }
    }
}
