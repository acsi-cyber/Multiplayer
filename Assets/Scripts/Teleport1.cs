using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Teleport1 : NetworkBehaviour
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

    public void Update()
    {
        if (chek == true & Input.GetKey(KeyCode.E) & GameManager.money2 >= 10)
        {
            player.transform.position = new Vector2(280f, 40f);
        }
    }
}
