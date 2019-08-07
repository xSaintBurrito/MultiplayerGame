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

            CmdSpawnPlayerPrefab();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {

        }

    }
    [Command]
    void CmdSpawnPlayerPrefab(){
        GameObject playerRepresentation = Instantiate(playerPrefab, gameObject.transform.position, gameObject.transform.rotation);
        playerRepresentation.gameObject.transform.Find("Gun").gameObject.transform.Find("PlayerCamera").gameObject.SetActive(true);
        NetworkServer.SpawnWithClientAuthority(playerRepresentation, connectionToClient);
    }

}
