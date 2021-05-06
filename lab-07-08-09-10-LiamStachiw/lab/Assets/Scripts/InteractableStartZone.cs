using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableStartZone : InteractableObject
{
    [SerializeField] private PlayerInteraction player;

    [SerializeField] private string beforeText = "Objective: Find the CEO's secrets.";
    [SerializeField] private string afterText = "Congratulations, you win!";

    public override string GetInteractionText() {
        if (!player.hasSecrets) {
            return beforeText;
        }
        else {
            Time.timeScale = 0;
            return afterText;
        }
    }
}
