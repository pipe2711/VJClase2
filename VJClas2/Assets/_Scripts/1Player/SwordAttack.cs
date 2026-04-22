using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Golpe detectado con: " + collision.name);

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("ENEMIGO GOLPEADO");

            EnemyMovement enemyMove = collision.GetComponentInParent<EnemyMovement>();
            if (enemyMove != null)
            {
                enemyMove.canMove = false;
            }

            Animator enemyAnim = collision.GetComponentInParent<Animator>();
            if (enemyAnim != null)
            {
                enemyAnim.SetTrigger("kill enemy");
            }

            GameObject rootEnemy = enemyMove != null ? enemyMove.gameObject : collision.gameObject;
            Destroy(rootEnemy, 0.5f);
        }
    }
}