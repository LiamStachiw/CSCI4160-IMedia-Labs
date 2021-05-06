using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour {

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float fallSpeed = 10f;

    private Vector3 originalPos;

    void Start() {
        originalPos = coinPrefab.transform.position;
    }

    void Update() {
        if (coinPrefab.transform.position.y < -5f) { 
        //if (!coinPrefab.GetComponent<Renderer>().isVisible) {
            Respawn();
        } else {
            coinPrefab.transform.Translate(Vector3.down * (fallSpeed * Time.deltaTime));
        }
    }

    public void Respawn() {
        coinPrefab.transform.position = originalPos;
    }
}
