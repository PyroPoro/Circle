using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AccuracyScript : MonoBehaviour
{
    public Text accText;
    public Image ProgBar;
    private float totalAccuracy = 0;
    public AudioSource track;
    private int hitNum = 0;
    private float accuracy = 0;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        ProgBar.fillAmount = track.time / track.clip.length;
        if (hitNum == 0){
            accText.text = "00.00%";
        }else{
            accuracy = (totalAccuracy / hitNum);
            if(accuracy % 1 == 0){
                accText.text = accuracy.ToString() + ".00%";
            }else{
                accText.text = Math.Round(accuracy,2).ToString() + "%";
            }
        }
    }
    public void addAccuracy(float n){
        totalAccuracy += n;
    }
    public void incrementHitNum(){
        hitNum++;
    }
    public void decrementHitNum(){
        hitNum--;
    }
    public float getAcc(){
        return accuracy;
    }
}
