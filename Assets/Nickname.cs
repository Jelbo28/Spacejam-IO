using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nickname : MonoBehaviour {
    [SerializeField]
    public string nickname;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetNickname(string setName)
    {
        nickname = setName;
    }
}
