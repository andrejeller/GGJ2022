using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class GamePlay: MonoBehaviour {


    public static GamePlay instance;
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    }


    private float initialTime, myTime;
    public TextMeshProUGUI scoreText;

    public GameObject FundoPreto, Seta;
    private int ladoFundoPreto = -1;

    [Space]
    public GameObject fadeGameOver_Preto, fadeGameOver_Branco;

    [Space]
    [Header("Sounds")]
    public AudioSource sound;
    public AudioClip ChangeColor;
    public AudioClip Click;
    public AudioClip ColetarCor;
    public AudioClip NextUp;
    public AudioClip NextDown;

    void Start() {
        FundoPreto.transform.position = new Vector2(6.5f * ladoFundoPreto, 0.0f);
        Seta.transform.position = new Vector2(0.0f, 0.0f);
        initialTime = Time.time;

        fadeGameOver_Preto.transform.position = new Vector2(-Screen.width / 2, fadeGameOver_Preto.transform.position.y);
        fadeGameOver_Branco.transform.position = new Vector2(-Screen.width / 2, fadeGameOver_Branco.transform.position.y);
    }

    void Update() {

        myTime = Time.time - initialTime;
        scoreText.text = myTime.ToString("00:00");

        // if (Input.GetKeyDown(KeyCode.LeftControl)) {
        //    TrocarFundoDeLado();
        // }

        if (Input.GetKeyDown(KeyCode.T)) {
            FimDeJogo();
        }


    }


    public void TrocarFundoDeLado() {

        float seta_goTo = 2.6f * ladoFundoPreto;
        ladoFundoPreto *= -1;
        float goTo = 6.5f * ladoFundoPreto;

        sound.PlayOneShot(ChangeColor, 1.0f);
        FundoPreto.transform.DOMoveX(goTo, 0.5f);
        Seta.transform.DOLocalMoveX(seta_goTo, 0.6f);

    }


    public void FimDeJogo() {
        Debug.Log("Fim!");
        PlayerPrefs.SetFloat("score", myTime);
        StartCoroutine(FimDeJogoAnimacao());
    }

    private IEnumerator FimDeJogoAnimacao() {
        yield return null;

        sound.PlayOneShot(NextUp, 1.0f);
        fadeGameOver_Preto.transform.DOMoveX(Screen.width / 2, 0.3f);
        fadeGameOver_Branco.transform.DOMoveX(Screen.width / 2, 0.3f);
        yield return new WaitForSeconds(0.3f);

        fadeGameOver_Preto.transform.DOMoveX(-Screen.width / 2, 0.3f);
        // fadeGameOver_Branco.transform.DOMoveX(-Screen.width / 2, 0.3f);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(2);

    }

    public void SomColetarCor() {
        sound.PlayOneShot(ColetarCor, 1.0f);
    }


}
