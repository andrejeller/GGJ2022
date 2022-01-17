using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Player: MonoBehaviour {

    public float testeS = 30.0f;
    public float testeJ = 80.0f;


    private Rigidbody2D myBody;
    //private float speed = testeS;
    //private float jumpForce = testeJ;

    void Start() {
        myBody = GetComponent<Rigidbody2D>();

    }

    void Update() {
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x * testeS;
        myBody.velocity = new Vector2(dir.x, myBody.velocity.y);
        
    }

    public void Jump() {
        myBody.AddForce(Vector2.up * testeJ, ForceMode2D.Impulse);
    }
}
