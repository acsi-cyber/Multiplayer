using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class TeleportMobil2 : NetworkBehaviour
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
        if(PlayerMobil.money >= 8) 
        {
            SceneManager.LoadScene(4);
        }
    }
}
