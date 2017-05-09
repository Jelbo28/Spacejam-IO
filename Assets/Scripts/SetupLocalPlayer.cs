using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    private CameraFollow camera;
    private Nickname playerName;

	void Start () {
	    if (isLocalPlayer)
	    {
            playerName = FindObjectOfType<Nickname>();
            camera = FindObjectOfType<CameraFollow>();
            camera.SetTarget(transform);
            GetComponent<PlayerMovement>().enabled = true;
            GetComponentInChildren<TextMesh>().text = playerName.nickname;

        }
    }
}
