using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Gun : NetworkBehaviour {

    NHNetworkedPool bulletsPool;

    public float fireRate=0.1f;
    float lastShotTime;
    [SerializeField]
    Transform spawn;
    bool isFiring = false;

	void Start () {

        if( NetworkServer.active )
            bulletsPool = FindObjectOfType<NHNetworkedPool>();

	}

    void OnGUI()
    {
        if (isLocalPlayer)
            GUI.Label(new Rect(5, Screen.height - 20, 200, 20), "Left click to Fire");
    }
	
	void Update () {

        if (isServer)
        {
            UpdateFire();
        }

        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CmdStartFire();
            }
            if (Input.GetMouseButtonUp(0))
            {
                CmdStopFire();
            }
        }
	}

    [Command]
    void CmdStartFire()
    {
        isFiring = true;
    }

    [Command]
    void CmdStopFire()
    {
        isFiring = false;
    }

    private void UpdateFire()
    {
        if (!isFiring || Time.timeSinceLevelLoad - lastShotTime < fireRate) return;

        GameObject bullet;
        bulletsPool.InstantiateFromPool(spawn.position, spawn.rotation, out bullet);

        lastShotTime = Time.timeSinceLevelLoad;
    }
}
