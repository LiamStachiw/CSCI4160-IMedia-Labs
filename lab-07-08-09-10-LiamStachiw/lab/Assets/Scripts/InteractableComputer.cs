using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableComputer : InteractableObject
{
    [SerializeField] private PlayerInteraction player;

    [SerializeField] private string beforeText = "Right-click to use computer";
    [SerializeField] private string afterText = "CEO's code acquired";

    public override void Activate() {
        player.hasCode = true;
    }

    public override string GetInteractionText() {
        if (!player.hasCode) {
            return beforeText;
        }
        else {
            return afterText;
        }
    }
}
