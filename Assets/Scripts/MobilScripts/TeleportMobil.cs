using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TeleportMobil : NetworkBehaviour
{
    private bool chek = false;
    private GameObject player;
    public GameObject buttom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            player = collision.gameObject;
            buttom.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            buttom.SetActive(false);
        }
    }

    public void Click()
    {
        player.transform.position = new Vector2(100f, 39f);
    }
}
