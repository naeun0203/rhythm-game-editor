using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Note
{
    public int Type; // 0-> short 1-> long
    public int Color; // 0-> red 1-> blue
    public int LineNum;
    public double StartTime;
    public double EndTime; //long노트 사용시 사용

    public Note(int type,int color, int Line, double start, double end)
    {
        Type = type;
        Color = color;
        LineNum = Line;
        StartTime = start;
        EndTime = end;
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
    public EditorManager manager;
    public Grid grid;
    public Dropdown MusicList;
    public Music music;
    public NoteData noteData;
    [ContextMenu("To Json Data")]
    public void SaveNoteData()
    {
        string jsonData = JsonUtility.ToJson(noteData, true);
        string path = Path.Combine(Application.dataPath + "/Audio/" + noteData.Music + "Data.json");
        File.WriteAllText(path, jsonData);
    }
    public void LoadNoteData()
    {
        string path = Path.Combine(Application.dataPath + "/Audio/" + MusicList.options[MusicList.value].text + "Data.json");
        string jsonData = File.ReadAllText(path);
        noteData = JsonUtility.FromJson<NoteData>(jsonData);
        music.ChangeMusic();
        music.Beat();
        music.MusicStop();
        manager.InputBeatBar();
        grid.CreateGrid();
    }
    
    private void Awake()
    {
        LoadNoteData();
    }

    public void InputData(GameObject Note, int color)
    {
        noteData.noteCount++;
        noteData.note.Add(new Note(0, color, NoteLine(Note), music.CurrentMusicTime(Note.transform.position), 0));
        noteData.note = noteData.note.OrderBy(x => x.StartTime).ToList();
    }
    public void OutputData(GameObject NoteClone)
    {

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

}
