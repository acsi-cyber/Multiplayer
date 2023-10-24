using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMeneger : MonoBehaviour
{
    public void pc()
    {
        SceneManager.LoadScene(1);
    }

    public void android()
    {
        SceneManager.LoadScene(3);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
