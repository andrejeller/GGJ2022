using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GamePlay : MonoBehaviour {

    public GameObject FundoPreto;
    private int ladoFundoPreto = -1;

    void Start() {
        FundoPreto.transform.position = new Vector2(6.5f * ladoFundoPreto, 0.0f);
    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            TrocarFundoDeLado();
        }

    }


    public void TrocarFundoDeLado() {

        ladoFundoPreto *= -1;
        float goTo = 6.5f * ladoFundoPreto;

        FundoPreto.transform.DOMoveX(goTo, 0.5f);

    }
}
