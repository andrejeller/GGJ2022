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

    [Space]
    [Header("Sounds")]
    public AudioSource sound;
    public AudioClip NextUp;
    public AudioClip NextDown;
    public AudioClip Click;

    void Start() {
        BG_Preto.transform.localPosition = new Vector2(-25.0f, BG_Preto.transform.localPosition.y);
        
        Player.transform.localScale = Vector2.zero;
        btn_info.transform.localScale = Vector2.zero;
        btn_play.transform.localScale = Vector2.zero;
        btn_ranking.transform.localScale = Vector2.zero;
        EscritoPreto.transform.localScale = Vector2.zero;
        PlataformaPreta.transform.localScale = Vector2.zero;
        PlataformaBranca.transform.localScale = Vector2.zero;

        

        StartCoroutine(AbrirMenu());
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
        sound.PlayOneShot(Click, 1.0f);
    }

    public void FecharPainelInfo() {
        StartCoroutine(FecharPainel(PainelInfo));
        sound.PlayOneShot(Click, 1.0f);
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


    private IEnumerator AbrirMenu() {
        yield return null;

        sound.PlayOneShot(NextUp, 1.0f);
        StartCoroutine(AbrirPainel(Player));
        yield return new WaitForSeconds(0.1f);

        BG_Preto.transform.DOMoveX(-14.0f, 0.3f); 
        yield return new WaitForSeconds(0.3f);

        BG_Preto.transform.DOMoveX(-17.8f, 0.3f);
        sound.PlayOneShot(NextDown, 1.0f);
        yield return new WaitForSeconds(0.1f);

        
        StartCoroutine(AbrirPainel(EscritoPreto));
        StartCoroutine(AbrirPainel(PlataformaPreta)); //0.05
        StartCoroutine(AbrirPainel(PlataformaBranca));
        StartCoroutine(AbrirPainel(btn_info));
        StartCoroutine(AbrirPainel(btn_play));
        StartCoroutine(AbrirPainel(btn_ranking));
        
        yield return new WaitForSeconds(0.3f);
        
        

    }


    private IEnumerator PlayGameAnimation() {
        yield return null;

        BG_Preto.transform.DOMoveX(-4.0f, 0.3f);
        sound.PlayOneShot(NextDown, 1.0f);
        yield return new WaitForSeconds(0.3f);

        EscritoPreto.SetActive(false);
        PlataformaPreta.SetActive(false);
        BG_Preto.transform.DOMoveX(-25.0f, 0.3f);

        
        yield return new WaitForSeconds(0.05f);
        btn_ranking.SetActive(false);

        yield return new WaitForSeconds(0.05f);
        btn_info.SetActive(false);
        sound.PlayOneShot(NextUp, 1.0f);
        yield return new WaitForSeconds(0.05f);
        // PlataformaBranca.SetActive(false);
        Player.SetActive(false);
        
        btn_play.SetActive(false);
        
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }
}
