using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plita1 : MonoBehaviour
{
    public GameObject plita1;
    public static bool plitaChek1 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            plitaChek1 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            plitaChek1 = false;
        }
    }
}
