using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Memories_NoteGenerator : MonoBehaviour
{
    public GameObject note;
    public GameObject note2xSpeed;
    public float bpm;
    public float speedMultiplier;
    float startingDistance = 16.85f;
    public TextAsset beatMap;
    private List<float> angles = new List<float>();
    private List<float> beats = new List<float>();
    public float noteSpawnDistance = 2;
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
            noteClone.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }else if(type == "2xSpeed"){
            GameObject noteClone = Instantiate(note2xSpeed, polarToCart(radius, angle), Quaternion.identity, noteHolder.transform);
            noteClone.GetComponent<NoteController>().bpm = this.bpm * 2;
            noteClone.name = noteName;
            noteClone.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void Start()
    {
        bpm *= speedMultiplier;
        noteSpawnDistance *= speedMultiplier;
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
        for(int k = 0 ; k < angles.Count; k++){
            noteName = noteCounter.ToString();
            noteCounter++;
            if((k > 121 && k < 354)){// || (k > 195 && k < 261)){
                generateNote((startingDistance * noteSpawnDistance * 2),angles[k], "2xSpeed");
                startingDistance += beats[k];
            }else{
                generateNote((startingDistance * noteSpawnDistance),angles[k],"normal");
                startingDistance += beats[k];
            }  
        }
        Debug.Log("All notes have been generated");
    }
}
