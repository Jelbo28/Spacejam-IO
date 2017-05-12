using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Nickname : NetworkBehaviour {
    [SerializeField]
    public string nickname;

    [SerializeField] public int shipType = 0;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
    

    }

    public void SetNickname(string setName)
    {
        nickname = setName;
    }

    public void SetShip(int setShip)
    {
            //shipType = setShip;
        FindObjectOfType<NetworkCustom>().shipType = setShip;
        //Debug.Log(FindObjectOfType<NetworkCustom>().shipType);
    }

    
}
