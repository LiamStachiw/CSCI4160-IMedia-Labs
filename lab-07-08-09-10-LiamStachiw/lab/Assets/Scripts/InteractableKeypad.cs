using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableKeypad : InteractableObject {
    [SerializeField] private bool autoOpen = false;

    [SerializeField] private bool autoClose = false;
    [SerializeField] private float autoCloseDelay = 8f;

    [SerializeField] private bool isUnlocked = false;

    [SerializeField] private string openText = "Right-click to open";
    [SerializeField] private string closeText = "Right-click to close";
    [SerializeField] private string lockedText = "Find the code to unlock this door";

    [SerializeField] private Animator doorAnimator;
    [SerializeField] private PlayerInteraction player;

    private bool isOpen = false;

    public override void Activate() {
        if (player.hasCode) {
            isUnlocked = true;
        }
        if(!isOpen && isUnlocked) {
            OpenDoor();
        } else if(isOpen) {
            CloseDoor();
        }
    }

    private void OpenDoor() {
        isOpen = true;
        doorAnimator.SetBool("Open", true);
    }

    private void CloseDoor() {
        isOpen = false;
        doorAnimator.SetBool("Open", false);
    }

    public override string GetInteractionText() {
        if (!player.hasCode) {
            return lockedText;
        }
        else if (!isOpen) {
            return openText;
        }
        else {
            return closeText;
        }
    }
}
