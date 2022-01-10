using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContral : MonoBehaviour
{
    public GameObject note;
    public GameObject NoteArea;
    public GameObject[] Line;
    public GameObject[] BeatBar;
    Camera Camera;
    Vector2 mousePos;
    Ray2D mouse;
    // Start is called before the first frame update
    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        BeatBar = GameObject.FindGameObjectsWithTag("BeatBar");
    }
    void Update()
    {
        if (note.activeSelf == true)
        {
            noteMove();
        }

        if (Input.GetMouseButtonDown(0))
        {
            DisposeObject();
            UnDisposeObject();
        }
    }

    private void noteMove()
    {
        mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
        note.transform.position = noteLocation();
    }
    private void DisposeObject()
    {
        GameObject NoteClone = Instantiate(note, noteLocation(), Quaternion.identity) as GameObject;
        NoteClone.transform.parent = GameObject.FindWithTag("BeatBar").transform;
    }
    private void UnDisposeObject()
    {

    }

    private Vector2 noteLocation()
    {
        float x = 0;
        float y = 0;
        for (int i = 0; i < Line.Length - 1; i++)
        {
            if (mousePos.x > Line[i].transform.position.x && mousePos.x < Line[i+1].transform.position.x)
            {
                x = (Line[i].transform.position.x + Line[i + 1].transform.position.x) / 2;
            }
        }
        for (int i = 0; i < BeatBar.Length - 1; i++)
        {
            if ( mousePos.y > BeatBar[i].transform.position.y && mousePos.y < BeatBar[i + 1].transform.position.y)
            {
                y = BeatBar[i].transform.position.y;
            }
        }
        return new Vector2(x, y);
    }
}
