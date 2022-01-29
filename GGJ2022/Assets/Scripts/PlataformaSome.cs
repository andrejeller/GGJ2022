using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSome: MonoBehaviour {

    public bool PlataformaPreta = false;
    public PlatformEffector2D platform;

    [Space] public LayerMask ativado;
    public LayerMask desativado;

    void Start() {
        
    }

    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "FundoPreto") {
            if (PlataformaPreta) platform.colliderMask = desativado;
            else if (!PlataformaPreta) platform.colliderMask = ativado;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "FundoPreto") {
            if (PlataformaPreta) platform.colliderMask = ativado;
            else if (!PlataformaPreta) platform.colliderMask = desativado;
        }
    }

}
