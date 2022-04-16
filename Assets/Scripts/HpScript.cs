using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HpScript : MonoBehaviour
{
    public Image HpbarFill;
    private float Hp = 100;
    private bool isAlive = true;
    public GameObject game;
    public Canvas gameOverCanvas;
    public GameObject player;
    public AudioSource track;
    private bool isGodMode;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGodMode = PlayerPrefs.GetInt("isGodMode") == 1;
        if(Hp > 100){
            Hp = 100;
        }
        if(Hp <= 0){
            isAlive = false;
            Hp = 0;
        }
        if(HpbarFill.fillAmount > (Hp/100)){
            HpbarFill.fillAmount -= 0.02f;
        }
        if(HpbarFill.fillAmount < (Hp/100)){
            HpbarFill.fillAmount += 0.02f;
        }
        if(Math.Abs(HpbarFill.fillAmount - (Hp/100)) <= 0.02f){
            HpbarFill.fillAmount = Hp/100;
        }
        if(!isGodMode){
            if(!isAlive){
                game.transform.GetChild(3).gameObject.SetActive(false);
                player.SetActive(false);
                track.Pause();
                gameOverCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void addHp(float n){
        Hp += n;
    }
    public void subtractHp(float n){
        Hp -= n;
    }
}
