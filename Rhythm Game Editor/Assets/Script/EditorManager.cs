using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EditorManager : MonoBehaviour
{
    public bool isPlay { get; set; }
    public bool isScroll { get; set; }
    public float Scroll { get; set; }

    public Grid grid;
    public Music music;
    public NoteContral noteContral;

    private void Update()
    {
        OnScroll();
        if (isPlay)
        {
            grid.MoveGrid();
        }
        if (isScroll)
        {
            grid.ScrollGrid();
        }
        if (Input.GetKeyDown("space"))
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

    private void OnScroll()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            isScroll = true;
            Scroll = 1f;
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            isScroll = true;
            Scroll = -1f;
        }
        else
        {
            isScroll = false;
            Scroll = 0f;
        }
    }
}
