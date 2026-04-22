using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 🔥 ENEMIGOS NORMALES
        if (collision.CompareTag("Enemy"))
        {
            EnemyMovement enemyMove = collision.GetComponentInParent<EnemyMovement>();
            if (enemyMove != null)
                enemyMove.canMove = false;

            Animator enemyAnim = collision.GetComponentInParent<Animator>();
            if (enemyAnim != null)
                enemyAnim.SetTrigger("KillEnemy");

            if (enemyMove != null)
                Destroy(enemyMove.gameObject, 0.5f);
        }

        // 🔥 BOSS
        if (collision.CompareTag("Boss"))
        {
            Boss boss = collision.GetComponentInParent<Boss>();

            if (boss != null)
            {
                boss.TakeDamage(1);
            }
        }
    }
}