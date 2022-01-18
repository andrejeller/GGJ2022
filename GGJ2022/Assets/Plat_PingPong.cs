using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_PingPong : MonoBehaviour {
    
    public float intencidade = 8;
    public bool vertical = true;

    private float centro = 0.0f;

    private void Start() {
        centro = transform.position.y;
    }

    void Update() {

        
        float mover = centro + Mathf.PingPong(Time.time, intencidade);
        
        if (vertical) transform.position = new Vector3(transform.position.x, mover, transform.position.z);
        else transform.position = new Vector3(mover, transform.position.y, transform.position.z);
        
        

    }

}
