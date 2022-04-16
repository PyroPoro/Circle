using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Memories_OuterHitBoxController : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameObject player;
    NoteGenerator noteGenScript;
    public GameObject badText;
    public GameObject okText;
    public GameObject goodText;
    public GameObject greatText;
    public GameObject perfectText;
    public Material greenMat;
    public Material blueMat;
    public Animator CameraAnimator;
    public GameObject noteHolder;
    public GameObject game;
    private Collider2D[] cols;
    public GameObject comboManager;
    private float comboMultiplier;
    public GameObject accuracyManager;
    public GameObject HpManager;
    public int x500 = 0;
    public int x400 = 0;
    public int x300 = 0;
    public int x200 = 0;
    public int x100 = 0;
    void Start()
    {
        scoreText.text = "00000000";
    }

    // Update is called once per frame
    void Update()
    {
        comboMultiplier = comboManager.GetComponent<ComboScript>().getComboMultiplier();
        if(Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.X)){
            cols = Physics2D.OverlapCircleAll(new Vector2(0,0), 1.2f);
            foreach(Collider2D col in cols){
                if(col.gameObject.tag == "note" && col.gameObject.name == noteHolder.transform.GetChild(0).name){
                    float zRotDiff = Mathf.Abs(Quaternion.Angle(transform.rotation, col.gameObject.transform.rotation));
                    if(zRotDiff < 45.0f){
                        float distance = Math.Abs(Vector3.Distance(col.gameObject.transform.position, gameObject.transform.position) - 0.75f);
                        if(distance > 0.45f || zRotDiff > 30.0f){
                            score += (int)(100 * comboMultiplier);
                            comboManager.GetComponent<ComboScript>().resetCombo();
                            Instantiate(badText, new Vector3(0,1.5f,0), Quaternion.identity);
                            accuracyManager.GetComponent<AccuracyScript>().addAccuracy(20);
                            HpManager.GetComponent<HpScript>().subtractHp(15);
                            x100++;
                        }
                        else if(distance > 0.35f || zRotDiff > 20.0f){
                            score += (int)(200 * comboMultiplier);
                            comboManager.GetComponent<ComboScript>().resetCombo();
                            Instantiate(okText, new Vector3(0,1.5f,0), Quaternion.identity);
                            accuracyManager.GetComponent<AccuracyScript>().addAccuracy(40);
                            HpManager.GetComponent<HpScript>().subtractHp(5);
                            x200++;
                        }
                        else if(distance > 0.25f || zRotDiff > 10.0f){
                            score += (int)(300 * comboMultiplier);
                            comboManager.GetComponent<ComboScript>().incrementCombo();
                            Instantiate(goodText, new Vector3(0,1.5f,0), Quaternion.identity);
                            accuracyManager.GetComponent<AccuracyScript>().addAccuracy(60);
                            HpManager.GetComponent<HpScript>().addHp(5);
                            x300++;
                        }
                        else if(distance > 0.15f || zRotDiff > 5.0f){
                            score += (int)(400 * comboMultiplier);
                            comboManager.GetComponent<ComboScript>().incrementCombo();
                            Instantiate(greatText, new Vector3(0,1.5f,0), Quaternion.identity);
                            accuracyManager.GetComponent<AccuracyScript>().addAccuracy(80);
                            HpManager.GetComponent<HpScript>().addHp(15);
                            x400++;
                        }else{
                            score += (int)(500 * comboMultiplier);
                            comboManager.GetComponent<ComboScript>().incrementCombo();
                            Instantiate(perfectText, new Vector3(0,1.5f,0), Quaternion.identity);
                            accuracyManager.GetComponent<AccuracyScript>().addAccuracy(100);
                            HpManager.GetComponent<HpScript>().addHp(25);
                            x500++;
                        }
                        accuracyManager.GetComponent<AccuracyScript>().incrementHitNum();
                        ParticleSystem sepBurst = col.transform.GetComponent<NoteController>().burst;
                        sepBurst.transform.parent = null;
                        sepBurst.Play();
                        Debug.Log(col.gameObject.name);
                        Destroy(col.gameObject);
                        Destroy(sepBurst.gameObject,1f);
                    }
                }
            }
        }
        scoreText.text = score.ToString();
        int numOfZeros = 8 - score.ToString().Length;
        for(int i = 0; i < numOfZeros; i++){
            scoreText.text = "0" + scoreText.text;
        }
    }
    List<string> shake = new List<String> {"123", "353", "474", "475", "476", "477", "492", "541", "647", "960"};
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "123" || other.gameObject.name == "492"){
            this.gameObject.transform.parent.GetChild(0).GetComponent<SpriteRenderer>().material = greenMat;
        }
        if(other.gameObject.name == "353" || other.gameObject.name == "960"){
            this.gameObject.transform.parent.GetChild(0).GetComponent<SpriteRenderer>().material = blueMat;
        }       
        if(shake.Contains(other.gameObject.name)){
            CameraAnimator.SetTrigger("Shake_Intense");
        }
    }
}
