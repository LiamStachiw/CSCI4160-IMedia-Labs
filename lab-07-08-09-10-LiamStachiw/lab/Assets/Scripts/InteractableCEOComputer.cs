using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCEOComputer : InteractableObject {
    [SerializeField] private PlayerInteraction player;

    [SerializeField] private string beforeText = "Right-click to use the CEO's computer";
    [SerializeField] private string afterText = "Secret information acquired";

    public override void Activate() {
        player.hasSecrets = true;
    }

    public override string GetInteractionText() {
        if (!player.hasSecrets) {
            return beforeText;
        }
        else {
            return afterText;
        }
    }
}
