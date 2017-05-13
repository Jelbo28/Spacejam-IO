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
        if (NetworkServer.active)
            bulletsPool = FindObjectOfType<NHNetworkedPool>();
        if (isLocalPlayer)
        {
            anim = transform.GetChild(3).GetComponent<Animator>();
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
                //anim.speed = 1;
                anim.SetBool("isShooting", true);
                CmdStartFire();
            }
            if (Input.GetMouseButtonUp(0))
            {
                //anim.speed = 0;
                anim.SetBool("isShooting", false);
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
