using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    public float detectionRange = 6f;
    public float attackRange = 2f;
    public float attackCooldown = 2.5f;

    private float _nextAttackTime;

    private Animator _anim;

    [Header("Hitbox")]
    public GameObject attackPoint;
    public float hitboxActiveTime = 0.2f;

    private bool isAttacking = false;
    private bool isDead = false;

    void Start()
    {
        _anim = GetComponent<Animator>();

        if (attackPoint != null)
            attackPoint.SetActive(false);
    }

    void Update()
    {
        if (isDead) return;
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            Flip();

            if (distance <= attackRange)
            {
                Attack();
            }
            else
            {
                if (!isAttacking)
                {
                    MoveTowardsPlayer();
                    _anim.SetBool("IsRunning", true);
                }
            }
        }
        else
        {
            _anim.SetBool("IsRunning", false);
        }
    }

    void MoveTowardsPlayer()
    {
        if (isAttacking || isDead) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    void Flip()
    {
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Attack()
    {
        if (isDead) return;
        if (isAttacking) return;
        if (Time.time < _nextAttackTime) return;

        _nextAttackTime = Time.time + attackCooldown;

        StartCoroutine(DoAttack());
    }

    IEnumerator DoAttack()
    {
        isAttacking = true;

        _anim.SetBool("IsRunning", false);
        _anim.SetTrigger("BossAttack1");

        if (attackPoint != null)
        {
            attackPoint.SetActive(true);
            Debug.Log("HITBOX ON");
        }

        yield return new WaitForSeconds(hitboxActiveTime);

        if (attackPoint != null)
        {
            attackPoint.SetActive(false);
            Debug.Log("HITBOX OFF");
        }

        isAttacking = false;
    }
}