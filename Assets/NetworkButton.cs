using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkButton : NetworkBehaviour {
    private NetworkManager networkManager;
    [SerializeField]
    public string serverIP;


    void Start () {
        networkManager = FindObjectOfType<NetworkManager>();
	}

    public void StartClient()
    {
        networkManager.networkAddress = serverIP;
        networkManager.StartClient();
    }

    public void StartServer()
    {
        networkManager.networkAddress = "localhost";
        networkManager.StartHost();
    }

    public void SetIP(string IP)
    {
        serverIP = IP;
        GetComponent<Animator>().SetTrigger("Go");
    }
}
