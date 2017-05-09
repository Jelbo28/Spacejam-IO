using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar]
    public string playerName = "player";
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
}
