using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator anim;
    public Vector2 moveVector;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        anim.SetBool("jump", Player.isJump);
    }
}
