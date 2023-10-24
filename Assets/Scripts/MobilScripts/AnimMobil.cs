using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMobil : MonoBehaviour
{
    public Animator anim;
    public Vector2 moveVector;
    public Joystick joystick;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(joystick.Horizontal));
        anim.SetBool("jump", PlayerMobil.isJump);
    }
}
