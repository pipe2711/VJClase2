using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;

    public float jumpForce = 20f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Método para saltar
    public void Jump()
    {
        if (Mathf.Abs(_rb.velocity.y) < 0.01f)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _anim.SetTrigger("Jump");
        }
    }

    void Update()
    {

    }
}