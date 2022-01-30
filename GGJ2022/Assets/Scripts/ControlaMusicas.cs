using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlaMusicas: MonoBehaviour {

    [Space]
    [Header("Sounds")]
    public AudioSource sound01;
    public AudioSource sound02;
    private bool primeira = true;

    void Start() {
        primeira = true;
        sound01.volume = 1.0f;
        sound02.volume = 0.0f;
    }

    
    public void TrocarVolume() {
        if (primeira) {
            sound01.DOFade(0.0f, 0.4f);
            sound02.DOFade(1.0f, 0.4f);
            primeira = false;
        } else {
            sound01.DOFade(1.0f, 0.4f);
            sound02.DOFade(0.0f, 0.4f);
            primeira = true;
        }

        
    }

}
