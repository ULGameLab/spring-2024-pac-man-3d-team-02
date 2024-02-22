using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float launchForce = 20.0f; // The force to apply when jumping off the pad

    private Vector3 playerVelocity;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the SimpleController on Pac-Man
            SimpleController playerController = other.GetComponent<SimpleController>();

            if (playerController != null)
            {
                // Use the LaunchPlayer method to apply the force
                playerController.LaunchPlayer(launchForce);


            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SimpleController playerController = other.GetComponent<SimpleController>();
            if (playerController != null)
            {
                playerController.HandleLanding();

            }
        }
    }
}
 

