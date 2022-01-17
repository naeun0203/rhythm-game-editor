using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public struct Note
{
    public int type;
    public int LineNum;
    public double startTime;
    public double endTime;
}
[System.Serializable]
public struct NoteData
{
    public string Music;
    public float BPM;
    public int noteCount;
    public Note[] note;
}
public class MusicData : MonoBehaviour
{
    public NoteData noteData;
    public NoteContral noteContral;
    [ContextMenu("To Json Data")]
    public void SaveNoteData()
    {
        string jsonData = JsonUtility.ToJson(noteData, true);
        string path = Path.Combine(Application.dataPath, "/musmusData.json");
        File.WriteAllText(path, jsonData);
    }
    public void LoadNoteData()
    {
        string path = Path.Combine(Application.dataPath, "/musmusData.json");
        string jsonData = File.ReadAllText(path);
        noteData = JsonUtility.FromJson<NoteData>(jsonData);
    }
    
    public void InputData(GameObject NoteClone)
    {
        noteData.noteCount++;
        Array.Resize(ref noteData.note, noteData.noteCount);
        Debug.Log(NoteLine(NoteClone));
        Debug.Log(StartTime(NoteClone));
        Debug.Log(noteData.noteCount);
        noteData.note[noteData.noteCount-1].startTime = StartTime(NoteClone);
        noteData.note[noteData.noteCount-1].LineNum = NoteLine(NoteClone);

    }
    public int NoteLine(GameObject NoteClone)
    {
        int LineNum = 0;
        switch(NoteClone.transform.position.x)
        {
            case (-3.75f):
                LineNum = 1;
                break;
            case (-1.25f):
                LineNum = 2;
                break;
            case (1.25f):
                LineNum = 3;
                break;
            case (3.75f):
                LineNum = 4;
                break;
        }
        return LineNum;
    }

    public double StartTime(GameObject NoteClone)
    {
        double time = 0;
        for(int i = 0; i < noteContral.BeatBar.Length;  i++)
        {
            if(NoteClone.transform.position.y == noteContral.BeatBar[i].transform.position.y)
            {
                time = i * 0.75;
            }
        }
        return time;
    }
}
