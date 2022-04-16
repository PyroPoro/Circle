using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightItUp_LevelCompleteScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AccuracyManager;
    public GameObject OuterHitbox;
    public GameObject InnerHitbox;
    public Text score;
    public Text Acc;
    public Text x500;
    public Text x400;
    public Text x300;
    public Text x200;
    public Text x100; 
    public Text Misses; 
    void Start()
    {
        score.text = OuterHitbox.GetComponent<LightItUp_OuterHitBoxController>().score.ToString();
        Acc.text = AccuracyManager.GetComponent<AccuracyScript>().accText.text;
        x500.text = OuterHitbox.GetComponent<LightItUp_OuterHitBoxController>().x500.ToString();
        x400.text = OuterHitbox.GetComponent<LightItUp_OuterHitBoxController>().x400.ToString();
        x300.text = OuterHitbox.GetComponent<LightItUp_OuterHitBoxController>().x300.ToString();
        x200.text = OuterHitbox.GetComponent<LightItUp_OuterHitBoxController>().x200.ToString();
        x100.text = OuterHitbox.GetComponent<LightItUp_OuterHitBoxController>().x100.ToString();
        Misses.text = InnerHitbox.GetComponent<InnerHitBoxController>().missCount.ToString();
    }
}
