using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class Note
{
    private int Type;
    private int LineNum;
    private double startTime;
    private double endTime;

    public Note(int type, int Line, double start, double end)
    {
        Type = type;
        LineNum = Line;
        startTime = start;
        endTime = end;
    }
}
[System.Serializable]
public class NoteData
{
    public string Music;
    public float BPM;
    public int noteCount;
    public List<Note> note = new List<Note>();
}
public class MusicData : MonoBehaviour
{
    public NoteData noteData;
    public NoteContral noteContral;
    [ContextMenu("To Json Data")]
    public void SaveNoteData()
    {
        string jsonData = JsonUtility.ToJson(noteData, true);
        string path = Path.Combine(Application.dataPath + "/Audio/musmusData.json");
        File.WriteAllText(path, jsonData);
    }
    public void LoadNoteData()
    {
        string path = Path.Combine(Application.dataPath, "/Audio/musmusData.json");
        string jsonData = File.ReadAllText(path);
        noteData = JsonUtility.FromJson<NoteData>(jsonData);
    }
    
    public void InputData(GameObject NoteClone)
    {
        noteData.noteCount++;
        noteData.note.Add(new Note(0, NoteLine(NoteClone), StartTime(NoteClone), 0));
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
