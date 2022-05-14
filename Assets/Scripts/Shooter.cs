using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector3 offset;
    [SerializeField] private float shootingDirection;
    [SerializeField] private float shootingForce;

    private void Start()
    {
        offset = new Vector3(0f, 0f, 0f);
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * shootingForce * shootingDirection;
        Destroy(bullet, 10f);
    }
}
