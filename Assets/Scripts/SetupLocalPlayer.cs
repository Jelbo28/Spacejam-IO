using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SyncVar] public string playerName = "player";
    private CameraFollow camera;
	// Use this for initialization
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
<<<<<<< HEAD
<<<<<<< HEAD
            anim = GetComponent<Animator>();
            anim.speed = 0;
        }
        if (NetworkServer.active)
            bulletsPool = FindObjectOfType<NHNetworkedPool>();

=======
	        GetComponent<TestManager>().enabled = true;
	    }
>>>>>>> parent of 8f5ec96... The bullets don't work :-1:
=======
	        GetComponent<TestManager>().enabled = true;
	    }
>>>>>>> parent of 8f5ec96... The bullets don't work :-1:
    }

    void Update()
    {
            GetComponentInChildren<TextMesh>().text = playerName;
    }

}
