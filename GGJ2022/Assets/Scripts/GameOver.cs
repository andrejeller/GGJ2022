﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOver: MonoBehaviour {

    public TextMeshProUGUI txtScore, txtBest;
    public GameObject[] objectsToHide;
    public GameObject BG_Preto;


    void Start() {

        BG_Preto.transform.localPosition = new Vector2(-25.0f, BG_Preto.transform.localPosition.y);
        
        for (int i = 0; i < objectsToHide.Length; i++) {
            objectsToHide[i].transform.localScale = Vector2.zero;
        }

        GetAndUpdateScores();
        StartCoroutine(AbrirAnim());
    }


    private void GetAndUpdateScores() {
        
        float best = PlayerPrefs.GetFloat("best");
        float score = PlayerPrefs.GetFloat("score");

        if (score > best) {
            best = score;
            PlayerPrefs.SetFloat("best", best);
            PlayerPrefs.Save();
        }

        txtBest.text = best.ToString();
        txtScore.text = score.ToString();

    }

    public void VoltarAoMenu() {
        StartCoroutine(VoltarAoMenuAnim());
        // SceneManager.LoadScene(0);
    }

    public void AbrirRankingGooglePlay() {

    }




    // POP UPS
    private IEnumerator Show(GameObject qualObjeto) {
        yield return null;
        qualObjeto.transform.DOScale(1.2f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        qualObjeto.transform.DOScale(1.0f, 0.2f);
    }


    private IEnumerator Hide(GameObject qualObjeto) {
        yield return null;
        qualObjeto.transform.DOScale(1.2f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        qualObjeto.transform.DOScale(0.0f, 0.15f);
    }


    private IEnumerator AbrirAnim() {
        yield return null;

        BG_Preto.transform.DOMoveX(-9.0f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        BG_Preto.transform.DOMoveX(-13.0f, 0.2f);

        

        for (int i = 0; i < objectsToHide.Length; i++) {
            StartCoroutine(Show(objectsToHide[i]));
        }

        

    }

    private IEnumerator VoltarAoMenuAnim() {
        yield return null;

        

        for (int i = 0; i < objectsToHide.Length; i++) {
            StartCoroutine(Hide(objectsToHide[i]));
        }

        yield return new WaitForSeconds(0.4f);
        BG_Preto.transform.DOMoveX(0.0f, 0.25f);
        yield return new WaitForSeconds(0.25f);
        BG_Preto.transform.DOMoveX(-25.0f, 0.2f);

        yield return new WaitForSeconds(0.22f);
        SceneManager.LoadScene(0);
    }


}