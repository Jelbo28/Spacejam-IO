using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar] public string playerName = "player";
    private CameraFollow camera;

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            playerName = GUI.TextField(new Rect(25, Screen.height - 40, 100, 300), playerName);
            if (GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Change"))
            {
                CmdChangeName(playerName);
            }
        }
        //playerName = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), playerName);
    }

    [Command]
    public void CmdChangeName(string newName)
    {
        playerName = newName;
    }

	void Start () {
	    if (isLocalPlayer)
	    {
            camera = FindObjectOfType<CameraFollow>();
            camera.SetTarget(transform);
            GetComponent<PlayerMovement>().enabled = true;     
        }
    }

    void Update()
    {
        GetComponentInChildren<TextMesh>().text = playerName;
    }
}
