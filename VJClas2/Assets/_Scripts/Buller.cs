using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buller : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.velocity = (transform.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            // Destruye al enemigo
            Destroy(collision.gameObject);
            // Destruye la bala
            Destroy(gameObject);
        }
        // Si choca con otro objeto que sea el nivel (asegúrate de que tengan el tag "Ground" o "Wall")
        else if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
        {
            // Destruye la bala
            Destroy(gameObject);
        }
    }
}
