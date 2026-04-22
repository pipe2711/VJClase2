using UnityEngine;

public class BossAttackHitbox : MonoBehaviour
{
    private bool alreadyHit = false;

    private void OnEnable()
    {
        alreadyHit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alreadyHit) return;

        if (collision.CompareTag("Player"))
        {
            alreadyHit = true;

            Debug.Log("PLAYER GOLPEADO");

            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.ReceibeDamage();
            }
        }
    }
}