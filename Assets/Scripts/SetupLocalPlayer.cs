using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar]
    public string playerName = "player";
    private CameraFollow camera;
    private Nickname playerNickname;

	void Start () {
	    if (isLocalPlayer)
	    {
            playerNickname = FindObjectOfType<Nickname>();
            camera = FindObjectOfType<CameraFollow>();
	        camera.trackTarget = true;
            camera.SetTarget(transform);
            GetComponent<PlayerMovement>().enabled = true;
            CmdChangeName(playerNickname.nickname);

        }
    }

    void Update()
    {
        GetComponentInChildren<TextMesh>().text = playerName;

    }
    [Command]
    public void CmdChangeName(string newName)
    {
        playerName = newName;
    }
}
