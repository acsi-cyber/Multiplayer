using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPeshera : MonoBehaviour
{
    public bool chekEnter = false;
    public bool chekEnter2 = false;
    public GameObject reshotaka1;
    public GameObject reshotaka2;


    private void Update()
    {
        if (chekEnter == true & chekEnter2 == false)
        {
            chekEnter2 = true;
            reshotaka1.SetActive(true);
            reshotaka2.SetActive(true);
        }

        if (Plita1.plitaChek1 == true & Plita2.plitaChek2 == true)
        {
            chekEnter = false;
            reshotaka1.SetActive(false);
            reshotaka2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player")) 
        {
            chekEnter = true;
        }
    }
}
