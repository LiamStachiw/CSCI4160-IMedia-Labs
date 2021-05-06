using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int playerScore = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        GetComponent<DropSpawner>().Respawn();
        playerScore += 1;
        Debug.Log("here");
    }
}
