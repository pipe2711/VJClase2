using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private NewInput _newInput;
    public float speed;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.score = 0;
        _newInput = GetComponent<NewInput>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Movement(); 
    }

    public void Movement()
    {
        //transform.Translate(Vector3.right * speed * _newInput.inputX * Time.deltaTime );
        //transform.Translate(Vector3.up * speed * _oldInput.vertical * Time.deltaTime );
        _rb.velocity = new Vector2(_newInput.inputX * speed,_rb.velocity.y);
    }
}
