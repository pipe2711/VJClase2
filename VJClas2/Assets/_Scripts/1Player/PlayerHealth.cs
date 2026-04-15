using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static Action<int, int> OnHealthChanged;
    public int maxHealth;
    private int _currentHealth;
    public int currentHealth => _currentHealth;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
        _animator = GetComponent<Animator>();

        OnHealthChanged?.Invoke(_currentHealth, maxHealth);
    }

    IEnumerator GetDamage()
    {
        _currentHealth --;

        OnHealthChanged?.Invoke(_currentHealth, maxHealth);
        _animator.SetBool("isDamage", true);
        Physics2D.IgnoreLayerCollision(3, 6, true);
        yield return new WaitForSeconds(2);
        _animator.SetBool("isDamage", false);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }

    /*public void ReceibeDamage()
    {
        if (_currentHealth > 1)
        {
            StartCoroutine(GetDamage());
        }
        else
        {
            //_animator.SetTrigger("isDead");
            Destroy(gameObject);
        }
    }*/

    public void ReceibeDamage()
    {
        if (_currentHealth > 1)
        {
            StartCoroutine(GetDamage());
        }
        else
        {
            _currentHealth = 0;

            OnHealthChanged?.Invoke(_currentHealth, maxHealth); // 👈 importante

            Destroy(gameObject);
        }
    }
}
