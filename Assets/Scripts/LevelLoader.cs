using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject track;
    public GameObject ui;
    void Start()
    {
        player.SetActive(false);
        track.SetActive(false);
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > 2f){
            player.SetActive(true);
            track.SetActive(true);
            ui.SetActive(true);
            track.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music_Volume");
        }
    }
}
