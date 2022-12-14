using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    public  static int         damage = 1;

    private float timer = 1f;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if ((timer -= Time.deltaTime) <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void Launch(Vector2 direction, float force)
    {
        if (direction.x < 0)
        {
            Flip();
        }

        _rigidbody2d.AddForce(direction * force);
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}