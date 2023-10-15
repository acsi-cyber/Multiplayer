using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Teleport : NetworkBehaviour
{
    private bool chek = false;
    private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            player = collision.gameObject;
            chek = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            chek = false;
        }
    }

    private void Update()
    {
        if (chek == true & Input.GetKey(KeyCode.E))
        {
            player.transform.position = new Vector2(100f, 39f);
        }
    }
}
