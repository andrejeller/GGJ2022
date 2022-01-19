using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GamePlay : MonoBehaviour {


    public static GamePlay instance;
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public GameObject FundoPreto, Seta;
    private int ladoFundoPreto = -1;

    void Start() {
        FundoPreto.transform.position = new Vector2(6.5f * ladoFundoPreto, 0.0f);
        Seta.transform.position = new Vector2(0.0f, 0.0f);
    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            TrocarFundoDeLado();
        }

    }


    public void TrocarFundoDeLado() {

        float seta_goTo = 2.6f * ladoFundoPreto;
        ladoFundoPreto *= -1;
        float goTo = 6.5f * ladoFundoPreto;

        FundoPreto.transform.DOMoveX(goTo, 0.5f);
        Seta.transform.DOLocalMoveX(seta_goTo, 0.6f);

    }


    public void FimDeJogo() {
        Debug.Log("Fim!");
    }
}
