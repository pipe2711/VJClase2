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
        if(collision.CompareTag("Enemy"))
        {
            _rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
            
            // Si el collider está en la cabeza (un objeto hijo), buscamos los componentes en el padre (el enemigo completo)
            EnemyMovement enemyMove = collision.GetComponentInParent<EnemyMovement>();
            if (enemyMove != null)
            {
                enemyMove.canMove = false;
            }
            
            // Buscamos el Animator en el objeto que tocamos, en su padre, o en sus hijos
            Animator enemyAnim = collision.GetComponentInParent<Animator>(); // o GetComponentInChildren si está más abajo
            if (enemyAnim == null)
            {
                // Si el padre no lo tiene, tal vez lo tiene un hermano (ej. EnemySprite)
                enemyAnim = collision.transform.parent != null ? collision.transform.parent.GetComponentInChildren<Animator>() : collision.GetComponentInChildren<Animator>();
            }

            if (enemyAnim != null)
            {
                enemyAnim.SetTrigger("kill enemy");
            }
            
            // Destruimos el objeto principal del enemigo (su raíz), no solo la cabeza
            GameObject rootEnemy = enemyMove != null ? enemyMove.gameObject : collision.gameObject;
            Destroy(rootEnemy, 0.5f);
        }
    }
}
