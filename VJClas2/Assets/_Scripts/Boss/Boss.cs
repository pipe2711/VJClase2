using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    private Animator _anim;
    private bool isDead = false;

    private BossController controller;

    void Start()
    {
        currentHealth = maxHealth;
        _anim = GetComponent<Animator>();
        controller = GetComponent<BossController>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        Debug.Log("Boss HP: " + currentHealth);

        if (currentHealth > 0)
        {
            if (_anim != null)
                _anim.SetTrigger("Hit");
        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        if (controller != null)
            controller.enabled = false; // 🔥 detiene IA

        if (_anim != null)
            _anim.SetTrigger("Death");

        Debug.Log("BOSS DERROTADO");

        Destroy(gameObject, 2f);
    }
}