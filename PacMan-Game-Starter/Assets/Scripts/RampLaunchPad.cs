using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampLaunchPad : MonoBehaviour
{
    public float launchSpeedMultiplier = 2f; // Multiplier to the player's speed
    public float launchAngleDegrees = 45f; // Angle of launch in degrees

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the player's movement component
            SimpleController playerController = other.GetComponent<SimpleController>();

            if (playerController != null)
            {
                playerController.PropelPlayer(launchAngleDegrees, launchSpeedMultiplier);

            }
        }
    }
}
