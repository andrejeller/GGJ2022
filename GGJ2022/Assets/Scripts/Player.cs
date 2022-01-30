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
    [Space]
    public Transform groundcheck;
    public LayerMask whatIsGround;
    private bool jump, doubleJump;

    void Start() {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update() {

        Vector3 dir = Vector3.zero;

        // #if UNITY_ANDROID
        // #elif UNITY_EDITOR
        // #endif
        
        dir.x = Input.acceleration.x * testeS;
        // dir.x = Input.GetAxis("Horizontal") * testeS;
        

        myBody.velocity = new Vector2(dir.x, myBody.velocity.y);

        if (AmIGrounded()) {
            jump = false;
            doubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
           Jump();
        }

        

    }

    /*public void Jump1() {
        myBody.AddForce(Vector2.up * testeJ, ForceMode2D.Impulse);
    }*/

    private bool inFirstJump() {
        return (jump && !doubleJump);
    }

    public void Jump() {

        float forceToAdd = 0;
        if (AmIGrounded() && !inFirstJump()) {
            jump = true;
            //isGrounded = false;
            forceToAdd = testeJ;
        } else if (inFirstJump()) {
            // doubleJump = true;
            // forceToAdd = testeJ / 2;
        }

        myBody.AddForce(Vector2.up * forceToAdd, ForceMode2D.Impulse);
    }

    private bool AmIGrounded() {
        if (myBody.velocity.y <= 0) {
            Collider2D[] coliders = Physics2D.OverlapCircleAll(groundcheck.position, 0.1f, whatIsGround);
            for (int i = 0; i < coliders.Length; i++) {
                if (coliders[i].gameObject != gameObject)
                    return true;
            }

        }

        return false;
    }
}
