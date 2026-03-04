using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private NewInput _newInput;
    private Animator _entrar;
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
}
