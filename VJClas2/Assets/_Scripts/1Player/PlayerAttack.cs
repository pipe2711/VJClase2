using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float bounceForce;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 🔥 SOLO enemigos normales
        if (collision.CompareTag("Enemy"))
        {
            _rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);

            EnemyMovement enemyMove = collision.GetComponentInParent<EnemyMovement>();
            if (enemyMove != null)
                enemyMove.canMove = false;

            Animator enemyAnim = collision.GetComponentInParent<Animator>();
            if (enemyAnim != null)
                enemyAnim.SetTrigger("KillEnemy");

            GameObject rootEnemy = enemyMove != null ? enemyMove.gameObject : collision.gameObject;
            Destroy(rootEnemy, 0.5f);
        }

        // 🔥 BOSS (solo si cae desde arriba)
        if (collision.CompareTag("Boss") && _rb.velocity.y < 0)
        {
            Boss boss = collision.GetComponentInParent<Boss>();

            if (boss != null)
            {
                boss.TakeDamage(1);
            }
        }
    }
}