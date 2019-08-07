using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    Rigidbody playerRigidbody = null;
    Transform playerTransform = null;
    private bool isGrounded = true;

    // Start is called before the first frame update
    public override void OnStartAuthority()
    {
        if(hasAuthority){
            gameObject.transform.Find("Gun").gameObject.transform.Find("PlayerCamera").gameObject.SetActive(true);
        }
            playerRigidbody = gameObject.GetComponent<Rigidbody>();
            playerTransform = gameObject.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if (this.hasAuthority && playerRigidbody!= null && playerTransform != null) 
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            float playerZMovement = -Input.GetAxis("Horizontal");
            float playerXMovement = -Input.GetAxis("Vertical");
            playerRigidbody.MovePosition(playerTransform.position + playerTransform.forward * playerXMovement * speed + playerTransform.right * playerZMovement * speed);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
