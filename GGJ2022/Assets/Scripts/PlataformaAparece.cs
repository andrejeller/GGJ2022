using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaAparece : MonoBehaviour {

    public GameObject rampa;

    private void Start() {
        rampa.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            rampa.SetActive(true);
        }
    }
}
