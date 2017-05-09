using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AnimatorManager : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
            GetComponent<NetworkAnimator>().SetParameterAutoSend(0, false);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
