using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Shooting : NetworkBehaviour {
    NHNetworkedPool bulletsPool;

    public float fireRate = 0.1f;
    float lastShotTime;

    bool isFiring = false;
    private Animator anim;

    [SerializeField]
    private Transform[] spawns;
    private int spawnNum = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (NetworkServer.active)
            bulletsPool = FindObjectOfType<NHNetworkedPool>();
        if (isLocalPlayer)
        {
            anim = transform.GetChild(2).GetComponent<Animator>();
            anim.speed = 0;
        }

    }

    void OnGUI()
    {
        //if (isLocalPlayer)
        //    GUI.Label(new Rect(5, Screen.height - 20, 200, 20), "Left click to Fire");
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
    }

    [Command]
    public void CmdShoot(GameObject projectile)
    {
        if (isLocalPlayer)
            NetworkServer.Spawn(projectile);
    }

    [Command]
    void CmdStartFire()
    {
        //anim.speed = 1;
        isFiring = true;
    }

    [Command]
    void CmdStopFire()
    {
        //anim.speed = 0;
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
            spawnNum = 0;
        }
        else
        {
            spawnNum++;
        }
    }
}
