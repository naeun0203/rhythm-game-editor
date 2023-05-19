using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class EditorManager : Singleton<EditorManager>
{
    public bool isPlay { get; set; }

    public Grid grid;
    public Music music;
    public NoteContral noteContral;
    public GameObject[] Line;
    Dictionary<KeyCode, Action> keyDictionary;

    private void Start()
    {
        keyDictionary = new Dictionary<KeyCode, Action>
        {
            { KeyCode.Space, KeyDownSpace }
        };
    }
    private void Update()
    {
        Controlar();       
    }
    public void InputBeatBar()
    {

    }

    private void Controlar()
    {
        if (Input.anyKeyDown)
        {
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    dic.Value();
                }
            }
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            grid.ScrollGrid(1f);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            grid.ScrollGrid(-1f);
        }
    }

    private void KeyDownSpace()
    {
        if (!isPlay)
        {
            music.MusicPlay();
        }
        else
        {
            music.MusicPause();
        }
    }
}
