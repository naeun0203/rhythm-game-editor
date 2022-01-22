using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContral : MonoBehaviour
{
    public MusicData data;
    public GameObject note;
    public GameObject NoteArea;
    public GameObject[] Line;
    public Transform[] BeatBar;
    Camera Camera;
    Vector3 mousePos;
    Vector3 NotePos;
    Ray ray;
    // Start is called before the first frame update
    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        BeatBar = GameObject.FindGameObjectWithTag("Grid").GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        Ray();
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

    private void Ray()
    {
        mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(mousePos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            if (hit.collider.name == this.gameObject.name)
            {
                NoteEnabled();
            }
        }
        else
        {
            NoteDisable();
        }
    }
    private void noteMove()
    {
        note.transform.position = noteLocation();
    }
    private void NoteEnabled()
    {
        note.SetActive(true);
    }
    private void NoteDisable()
    {
        note.SetActive(false);

    }
    private void DisposeObject()
    {
        GameObject NoteClone = Instantiate(note, noteLocation(), Quaternion.identity) as GameObject;
        NoteClone.transform.parent = GameObject.FindWithTag("BeatBar").transform;
        data.InputData(NoteClone);
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
