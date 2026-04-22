using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    private Animator _anim;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        _anim = GetComponent<Animator>();
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
            StartCoroutine(DieSequence());
        }
    }

    IEnumerator DieSequence()
    {
        if (isDead) yield break;

        isDead = true;
        AudioManager.instance.PlayBossDeath();

        Debug.Log("BOSS DERROTADO");

        // 🔥 detener controlador
        BossController controller = GetComponent<BossController>();
        if (controller != null)
            controller.enabled = false;

        // 🔥 animación muerte
        if (_anim != null)
            _anim.SetTrigger("Death");

        // ⏳ esperar animación de muerte
        yield return new WaitForSeconds(2f);

        // 🏆 mostrar victoria
        if (GameManager.Instance != null)
        {
            GameManager.Instance.BossDefeated();
        }
    }
}