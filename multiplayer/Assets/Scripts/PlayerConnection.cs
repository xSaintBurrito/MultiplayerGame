using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnection : NetworkBehaviour
{

    public GameObject playerPrefab;


    Transform playerTransform;
    Transform playersGunTransform;

    bool isGrounded = true;
    void Start()
    {
        if (isLocalPlayer)
        {
            Debug.Log(connectionToClient);
            CmdSpawnPlayerPrefab();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    [Command]
    void CmdSpawnPlayerPrefab(){
        GameObject playerRepresentation = Instantiate(playerPrefab, gameObject.transform.position, gameObject.transform.rotation);
        NetworkServer.SpawnWithClientAuthority(playerRepresentation, connectionToClient);
    }

}
