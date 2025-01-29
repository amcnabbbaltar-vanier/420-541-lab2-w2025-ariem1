using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 50f;
    private Rigidbody rb;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Death part
        startPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You Win");
        }
        else if (other.CompareTag("DeathPlane"))
        {
            rb.position = startPosition;
        }
    }


    void FixedUpdate()
    {
        //Physics-related operations go here

        //Get input for horizontal and vertical axes
        float moveX = Input.GetAxis("Horizontal"); // x
        float moveZ = Input.GetAxis("Vertical"); // z

        //Caclculate the movement dircetion based on the player's forward and right vectors
        Vector3 movement = (transform.right * moveX) + (transform.forward * moveZ);

        //Apply movement to rigidbody
        rb.AddForce(movement * moveSpeed, ForceMode.Force);


    }

}
