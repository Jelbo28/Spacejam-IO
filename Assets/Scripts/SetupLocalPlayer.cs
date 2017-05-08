using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SetupLocalPlayer : NetworkBehaviour
{
    NHNetworkedPool bulletsPool;


    public float fireRate = 0.1f;
    float lastShotTime;

    bool isFiring = false;

    [SyncVar] public string playerName = "player";
    private CameraFollow camera;

    [SerializeField]
    private Transform[] spawns;
    private int spawnNum = 0;
    private Animator anim;


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

    [Command]
    public void CmdShoot(GameObject projectile)
    {
        if (isLocalPlayer)
            NetworkServer.Spawn(projectile);
    }

	void Start () {
	    if (isLocalPlayer)
	    {
            camera = FindObjectOfType<CameraFollow>();
            camera.SetTarget(transform);
            GetComponent<PlayerMovement>().enabled = true;
            anim = transform.GetChild(2).GetComponent<Animator>();
            anim.speed = 0;
        }
        if (NetworkServer.active)
            bulletsPool = FindObjectOfType<NHNetworkedPool>();
    }

    void Update()
    {

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
        GetComponentInChildren<TextMesh>().text = playerName;
    }


    [Command]
    void CmdStartFire()
    {
        anim.speed = 1;
        isFiring = true;
    }

    [Command]
    void CmdStopFire()
    {
        anim.speed = 0;
        isFiring = false;
    }

    private void UpdateFire()
    {
        if (!isFiring || Time.timeSinceLevelLoad - lastShotTime < fireRate) return;

        GameObject bullet;
        bulletsPool.InstantiateFromPool(spawns[spawnNum].position, spawns[spawnNum].rotation, out bullet);

        lastShotTime = Time.timeSinceLevelLoad;

        if (spawnNum + 1 >= spawns.Length)
        {
            //Debug.Log("pizza");
            spawnNum = 0;
        }
        else
        {
            spawnNum++;
        }
    }

}
