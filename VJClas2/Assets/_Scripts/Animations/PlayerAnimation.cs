using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Animator _entrar;
    private NewInput _newInput;
    // Start is called before the first frame update
    void Start()
    {
        _animator=GetComponent<Animator>();
        _newInput=GetComponent<NewInput>();
        _entrar=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveAnim();
        ent();
        AttackAnim();
    }

    public void PlayerMoveAnim()
    {
        _animator.SetBool("isMoving", _newInput.inputX != 0);
    }

    public void ent()
    {
        if(Input.GetKeyDown(KeyCode.P))
            _entrar.SetTrigger("Entrar");
    }

    void AttackAnim()
    {
        if (_newInput.attackPressed)
        {
            _animator.SetTrigger("Attack");
            _newInput.attackPressed = false;
        }
    }
}
