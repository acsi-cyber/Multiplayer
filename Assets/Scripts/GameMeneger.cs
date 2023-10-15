using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class GameManager : NetworkBehaviour
{
    [SyncVar]
    public int globalMoney;
    public static int money2;

    public Text globalMoneyText;
    public Text moneyText;

    public GameObject moneyPrefab;

    void Update()
    {
        money2 = globalMoney;
    }

    public void StopGame()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        else if (NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopClient();
        }
        else if (NetworkServer.active)
        {
            NetworkManager.singleton.StopServer();
        }
    }
}
