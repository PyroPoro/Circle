using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NoteGenParent : MonoBehaviour
{
    public float speedMultiplier;
    public float bpm;
    public string noteName;
    public float noteSpeed;
    public GameObject note;
    public GameObject note2xSpeed;
    public GameObject noteHolder;
    public TextAsset beatMap;
    public List<float> angles = new List<float>();
    public List<float> beats = new List<float>();
    public Vector3 polarToCart (float radius, float angle){
        float xPos = 0;
        float yPos = 0;
        angle = angle * Mathf.Deg2Rad;
        xPos = radius * Mathf.Cos(angle);
        yPos = radius * Mathf.Sin(angle);
        Vector3 vec = new Vector3(xPos,yPos,0);
        return vec;
    }
    public void generateNote(float displaceFromCenter, float beatsFromCenter, float angle, string type, float noteMoveSpeed, string noteName){
        float distanceToSpawn = displaceFromCenter + (beatsFromCenter * noteMoveSpeed * 60 / bpm); 
        if(type == "normal"){
            GameObject noteClone = Instantiate(note, polarToCart(distanceToSpawn, angle), Quaternion.identity, noteHolder.transform);
            noteClone.GetComponent<NoteController>().moveSpeed = noteMoveSpeed;
            noteClone.name = noteName;
        }else if(type == "2xSpeed"){
            distanceToSpawn *= 2;
            GameObject noteClone = Instantiate(note2xSpeed, polarToCart(distanceToSpawn, angle), Quaternion.identity, noteHolder.transform);
            noteClone.GetComponent<NoteController>().moveSpeed = 2*noteMoveSpeed;
            noteClone.name = noteName;
        }
    }
    public void readNotesFile(){
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
    }

    void Start()
    {
        
    }
}
