using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerHitBoxController : MonoBehaviour
{   
    public GameObject missText;
    public Animator CameraAnimator;
    public GameObject outerHitbox;
    public Material greenMat;
    public Material blueMat;
    public GameObject ComboManager;
    public GameObject game;
    public GameObject accManager;
    public GameObject HpManager;
    public int missCount = 0;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "note"){
            missCount++;
            ComboManager.GetComponent<ComboScript>().resetCombo();
            HpManager.GetComponent<HpScript>().subtractHp(20);
            accManager.GetComponent<AccuracyScript>().incrementHitNum();
            CameraAnimator.SetTrigger("Shake");
            Instantiate(missText, new Vector3(0,1,0), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
