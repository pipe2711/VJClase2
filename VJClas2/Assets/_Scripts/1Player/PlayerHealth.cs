using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int _currentHealth;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
    }

    IEnumerator GetDamage()
    {
        _currentHealth --;
        _animator.SetBool("isDamage", true);
        Physics2D.IgnoreLayerCollision(3, 6, true);
        yield return new WaitForSeconds(2);
        _animator.SetBool("isDamage", false);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }

    public void ReceibeDamage()
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
    }
}
