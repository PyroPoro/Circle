using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memories_NoteGen : NoteGenParent
{
    private float secPerBeat;
    private float beatsPerSec;
    private float startingBeatCount;
    private int noteIndex;
    public float displaceFromCenter;
    void Start()
    {
        secPerBeat = 60/bpm;
        beatsPerSec = bpm/60;
        startingBeatCount = 11;
        noteIndex = 0;
        noteSpeed *= speedMultiplier; 
        displaceFromCenter = 1.5f + (speedMultiplier - 1) * 0.9f;
        readNotesFile();
    }

    // Update is called once per frame
    void Update()
    {
        noteName = (noteIndex + 1).ToString();
        if (noteIndex < beats.Count){
            if (Time.timeSinceLevelLoad - 2 > startingBeatCount * secPerBeat){
                if((noteIndex > 121 && noteIndex < 354) || (noteIndex > 490 && noteIndex < 1000)){
                    generateNote(displaceFromCenter, 5, angles[noteIndex], "2xSpeed", noteSpeed, noteName);
                } else {
                    generateNote(displaceFromCenter, 5, angles[noteIndex], "normal", noteSpeed, noteName);
                }
                startingBeatCount += beats[noteIndex];
                noteIndex += 1;
            }
        }
        
    }
}
