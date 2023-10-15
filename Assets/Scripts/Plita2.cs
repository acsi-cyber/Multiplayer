using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plita2 : MonoBehaviour
{
    public GameObject plita2;
    public static bool plitaChek2 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            plitaChek2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            plitaChek2 = false;
        }
    }
}
