using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCustom : NetworkManager
{
    [SerializeField]
    private string[] shipLocations;
    public int shipType;
    //subclass for sending network messages
    //public override void OnStartClient(NetworkClient client)
    //{
    //    base.OnStartClient(client);
    //}
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }
    //void Start()
    //{
    //    Debug.Log(FindObjectOfType<Nickname>().shipType);
    //}
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = message.chosenClass;
        //Debug.Log("server add with message " + selectedClass);
        //GameObject player = Instantiate(Resources.Load("Player", typeof(GameObject))) as GameObject;
        //Debug.Log(FindObjectOfType<NetworkCustom>().shipType);
        GameObject ship = Instantiate(Resources.Load(shipLocations[selectedClass], typeof(GameObject))) as GameObject;
        //ship.transform.SetParent(player.transform, false);
        NetworkServer.AddPlayerForConnection(conn, ship, playerControllerId);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        NetworkMessage test = new NetworkMessage();

        test.chosenClass = shipType;

        ClientScene.AddPlayer(conn, 0, test);
    }


    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        //base.OnClientSceneChanged(conn);
    }
}
