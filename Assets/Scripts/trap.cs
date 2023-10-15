using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{

    Rigidbody2D rb;

    public GameObject trap1;

    void Start()
    {
        rb = trap1.GetComponent<Rigidbody2D>();   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            rb.isKinematic = false;
        }
    }
}
