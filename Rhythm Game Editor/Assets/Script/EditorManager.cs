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
    public GameObject[] Line;
    public List<Transform> BeatBar = new List<Transform>();
    public GameObject[] Grid;

    void Awake()
    {
        Grid = GameObject.FindGameObjectsWithTag("Grid");
        for(int i = 0; i < Grid.Length; i++)
        {
            for(int j = 0; j < Grid[i].transform.childCount; j++)
            {
                BeatBar.Add(Grid[i].transform.GetChild(j));
            }
        }

    }
    private void Update()
    {
        controlar();

        grid.GridLocation();
        
    }
    public void InputBeatBar()
    {

    }

    private void controlar()
    {
        OnScroll();
        if (isPlay)
        {
            grid.MoveGrid(Vector2.down * Time.smoothDeltaTime * 5);
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
