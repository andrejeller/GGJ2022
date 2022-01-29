using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GamePlay : MonoBehaviour {


    public static GamePlay instance;
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    }


    private float initialTime, myTime;
    public TextMeshProUGUI scoreText;

    public GameObject FundoPreto, Seta;
    private int ladoFundoPreto = -1;

    void Start() {
        FundoPreto.transform.position = new Vector2(6.5f * ladoFundoPreto, 0.0f);
        Seta.transform.position = new Vector2(0.0f, 0.0f);
        initialTime = Time.time;
    }

    void Update() {

        myTime = Time.time - initialTime;
        scoreText.text = myTime.ToString("00:00"); 

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
        CheckScores();


    }

    private void CheckScores() {
        float bestTime = PlayerPrefs.GetFloat("bestTime");

        if (myTime > bestTime) {
            bestTime = myTime;
            PlayerPrefs.SetFloat("bestTime", bestTime);
            PlayerPrefs.Save();
        }

    }

}
