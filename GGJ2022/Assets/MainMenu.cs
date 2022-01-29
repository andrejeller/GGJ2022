using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu: MonoBehaviour {

    // -17.8
    public GameObject BG_Preto, EscritoPreto;
    public GameObject PlataformaPreta, PlataformaBranca;
    public GameObject Player, btn_play, btn_info, btn_ranking;

    public GameObject PainelInfo;

    void Start() {

    }

    void Update() {

    }



    // Botoes
    public void Info() {

    }

    public void RankingGooglePlay() {

    }


    public void PlayGame() {
        //Faz uma Animaçao
        //Ai muda a cena
        
        StartCoroutine(PlayGameAnimation());
    }

    public void AbrirPainelInfo() {
        StartCoroutine(AbrirPainel(PainelInfo));
    }

    public void FecharPainelInfo() {
        StartCoroutine(FecharPainel(PainelInfo));
    }


    private IEnumerator AbrirPainel(GameObject qualPainel) {
        yield return null;
        qualPainel.transform.DOScale(1.2f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        qualPainel.transform.DOScale(1.0f, 0.2f);
    }


    private IEnumerator FecharPainel(GameObject qualPainel) {
        yield return null;
        qualPainel.transform.DOScale(1.2f, 0.3f);
        yield return new WaitForSeconds(0.3f);
        qualPainel.transform.DOScale(0.0f, 0.2f);
    }

    private IEnumerator PlayGameAnimation() {
        yield return null;

        BG_Preto.transform.DOMoveX(-4.0f, 0.3f);
        yield return new WaitForSeconds(0.3f);

        EscritoPreto.SetActive(false);
        PlataformaPreta.SetActive(false);
        BG_Preto.transform.DOMoveX(-25.0f, 0.3f);

        yield return new WaitForSeconds(0.05f);
        btn_ranking.SetActive(false);

        yield return new WaitForSeconds(0.05f);
        btn_info.SetActive(false);

        yield return new WaitForSeconds(0.05f);
        PlataformaBranca.SetActive(false);
        Player.SetActive(false);
        
        btn_play.SetActive(false);
        
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }
}
