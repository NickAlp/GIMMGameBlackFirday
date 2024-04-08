using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InvisibleBarrier : MonoBehaviour
{
    // Layer of the object that can trigger the game win
    public LayerMask winningObjectLayer;

    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();

        // Check if the object entering the barrier is on the winning object layer
        if (grabInteractable != null && (winningObjectLayer & (1 << grabInteractable.gameObject.layer)) != 0)
        {
            // Log a message indicating that the player has won
            Debug.Log("Congratulations! You have won the game!");
        }
    }
}
