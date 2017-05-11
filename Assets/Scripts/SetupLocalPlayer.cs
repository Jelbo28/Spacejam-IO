using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar]
    public string playerName = "player";
    [SerializeField]
    [SyncVar]
    public int shipType = 0;
    //[SyncVar]
    //public GameObject playerHealth;
    //[SyncVar]
    //public int connectNum;
    private CameraFollow camera;
    private Nickname playerNickname;
    //private int connections = 0;

	void Start () {
	    if (isLocalPlayer)
	    {
            //connectNum = connections;
            playerNickname = FindObjectOfType<Nickname>();
            shipType = playerNickname.shipType;
            camera = FindObjectOfType<CameraFollow>();
	        camera.trackTarget = true;
            camera.SetTarget(transform);
            GetComponent<PlayerMovement>().enabled = true;
            CmdChangeName(playerNickname.nickname);

        }
        //connections++;
    }

    void Update()
    {
        GetComponentInChildren<TextMesh>().text = playerName;
        //Debug.Log(Network.connections[connectNum]);
    }

    public void SetShip(int setShip)
    {
        shipType = setShip;
    }

    //public void Disconnect()
    //{
    //    if (isLocalPlayer)
    //        Network.CloseConnection(Network.connections[connectNum], false);
    //}

    [Command]
    public void CmdChangeName(string newName)
    {
        playerName = newName;
    }

    //[Command]
    //public void UpdateHealth(int newHealth)
    //{

    //}
}
