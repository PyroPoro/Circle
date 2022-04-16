using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource track;
    public Canvas LevelCompleteCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= track.clip.length){
            LevelCompleteCanvas.gameObject.SetActive(true);
        }
    }
}
