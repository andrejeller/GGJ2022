using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roda : MonoBehaviour {

    public GameObject a, b, c, d;
    public float lado = -1;
    public float j = 5.0f;

    void Update() {
        float vel = j * Time.timeScale * lado;
        transform.Rotate(new Vector3(0, 0, 1), vel);
        a.transform.Rotate(new Vector3(0, 0, 1), -vel);
        b.transform.Rotate(new Vector3(0, 0, 1), -vel);
        c.transform.Rotate(new Vector3(0, 0, 1), -vel);
        d.transform.Rotate(new Vector3(0, 0, 1), -vel);
    }
}
