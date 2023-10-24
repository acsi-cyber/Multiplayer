using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject win;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            win.SetActive(true);
            Invoke(nameof(Menu), 5f);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
