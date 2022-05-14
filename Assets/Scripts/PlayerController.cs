using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Shooter))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rigidbody;
    private Shooter _shooter;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rigidbody.velocity = new Vector2(horizontal, vertical) * speed;

        if(Input.GetKeyDown(KeyCode.Space)) _shooter.Shoot();
    }
}
