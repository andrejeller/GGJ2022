using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSome: MonoBehaviour {

    public SpriteRenderer sprite;
    public PlatformEffector2D platform;

    [Space] public LayerMask ativado;
    public LayerMask desativado;

    void Start() {
        //sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.T)) {
            platform.colliderMask = ativado;
            Debug.Log("Ativado");
            
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            platform.colliderMask = desativado;
            Debug.Log("Desativado");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name);
    }

}
