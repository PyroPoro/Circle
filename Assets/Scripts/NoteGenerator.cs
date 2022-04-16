using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NoteGenerator : MonoBehaviour
{
    public float speedMultiplier;
    public GameObject note;
    public GameObject note2xSpeed;
    public float bpm;
    float startingDistance = 2.8f;
    public TextAsset beatMap;
    private List<float> angles = new List<float>();
    private List<float> beats = new List<float>();
    public float noteSpawnDistance = 2f;
    private string noteName;
    private int noteCounter = 1;
    public GameObject noteHolder;
    Vector3 polarToCart (float radius, float angle){
        float xPos = 0;
        float yPos = 0;
        angle = angle * Mathf.Deg2Rad;
        xPos = radius * Mathf.Cos(angle);
        yPos = radius * Mathf.Sin(angle);
        Vector3 vec = new Vector3(xPos,yPos,0);
        return vec;
    }
    void generateNote(float radius, float angle, string type){
        if(type == "normal"){
            GameObject noteClone = Instantiate(note, polarToCart(radius, angle), Quaternion.identity, noteHolder.transform);
            noteClone.GetComponent<NoteController>().bpm = this.bpm;
            noteClone.name = noteName;
        }else if(type == "2xSpeed"){
            GameObject noteClone = Instantiate(note2xSpeed, polarToCart(radius, angle), Quaternion.identity, noteHolder.transform);
            noteClone.GetComponent<NoteController>().bpm = this.bpm * 2;
            noteClone.name = noteName;
        }
    }
    void Start()
    {
        bpm *= speedMultiplier;
        noteSpawnDistance *= speedMultiplier;
        startingDistance *= noteSpawnDistance;
        int counter = 0;
        string beatMapText = beatMap.text;
        string temp = "";
        foreach (char ch in beatMapText){
            if(ch == ','){
                if(counter % 2 == 0){
                    angles.Add(float.Parse(temp));
                }else{
                    beats.Add(float.Parse(temp));
                }
                counter++;
                temp = "";
            }else{
                temp += ch;
            }
        }
        Debug.Log(angles.Count);
        Debug.Log(beats.Count);
        float noteInterval = 0;
        for(int k = 0 ; k < angles.Count; k++){
            noteName = noteCounter.ToString();
            noteCounter++;
            if((k > 137 && k < 284) || (k > 378 && k < 525)){
                generateNote(((startingDistance + (noteInterval * noteSpawnDistance)) * 2),angles[k], "2xSpeed");
            }else{
                generateNote((startingDistance + (noteInterval * noteSpawnDistance)),angles[k],"normal");
            }  
            noteInterval += beats[k];
        }
    }
}
