using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private NewInput _newInput;
    public float speed;
    private Rigidbody2D _rb;

    private PlayerJump _playerJump;

    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.score = 0;
        _newInput = GetComponent<NewInput>();
        _playerJump = GetComponent<PlayerJump>();
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement(); 

        float horizontalInput = _newInput.inputX;

        if (horizontalInput > 0.1f && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < -0.1f && facingRight)
        {
        Flip();
        }

    }

    public void Movement()
    {
        //transform.Translate(Vector3.right * speed * _newInput.inputX * Time.deltaTime );
        //transform.Translate(Vector3.up * speed * _oldInput.vertical * Time.deltaTime );
        //_rb.velocity = new Vector2(_newInput.inputX * speed,_rb.velocity.y);
        transform.Translate(Vector3.right * speed * _newInput.inputX * Time.deltaTime);
    
    }

    void FlipCheck()
    {
        float horizontalInput = _newInput.inputX;

        if (horizontalInput > 0.1f && !facingRight)
            Flip();
        else if (horizontalInput < -0.1f && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

}
