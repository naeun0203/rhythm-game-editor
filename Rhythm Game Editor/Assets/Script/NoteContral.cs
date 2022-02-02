using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContral : MonoBehaviour
{
    public EditorManager manager;
    public MusicData data;
    public GameObject note;
    public GameObject NoteArea;
    Camera Camera;
    Vector3 mousePos;
    // Start is called before the first frame update
    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        Ray();
        //hitNote();
        if (note.activeSelf == true)
        {
            noteMove();
            if (Input.GetMouseButtonDown(0))
            {
                DisposeObject();
            }
            if (Input.GetMouseButtonDown(1))
            {
                UnDisposeObject();
            }
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
            if (hit.collider.gameObject.CompareTag("Note"))
            {
                noteTrigger = true;
                TriggerObject = hit.collider.gameObject;
            }
            else
            {
                noteTrigger = false;
                TriggerObject = null;
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

    private bool NoteCheck()
    {
        bool Check = true;
        return Check;
    }

    private void DisposeObject()
    {
        if(NoteCheck())
        {
            GameObject NoteClone = Instantiate(note, noteLocation(), Quaternion.identity) as GameObject;
            NoteClone.tag = "Note";
            NoteClone.transform.parent = GameObject.Find("NoteContainer").transform;
            data.InputData(NoteClone, currentColor);
        }
    }
    private int currentColor;
    public void ChangeColor(float colorNum)
    {
        switch (colorNum)
        {
            case 0:
                note.GetComponent<SpriteRenderer>().color = Color.red;
                currentColor = 0;
                break;
            case 1:
                note.GetComponent<SpriteRenderer>().color = Color.blue;
                currentColor = 1;
                break;
        }
    }

    public void UnDisposeObject()
    {
        if(TriggerObject != null)
        {
            Destroy(TriggerObject);
        }
    }
    public bool noteTrigger;
    public GameObject TriggerObject;
/*    private void hitNote()
    {
        RaycastHit2D hit = Physics2D.Raycast(note.transform.position, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Note"))
            {
                noteTrigger = true;
                TriggerObject = hit.collider.gameObject;
            }
        }
    }*/
        private Vector2 noteLocation()
    {
        float x = 0;
        float y = 0;
        for (int i = 0; i < manager.Line.Length - 1; i++)
        {
            if (mousePos.x > manager.Line[i].transform.position.x && mousePos.x < manager.Line[i+1].transform.position.x)
            {
                x = (manager.Line[i].transform.position.x + manager.Line[i + 1].transform.position.x) / 2;
            }
        }
        for (int i = 0; i < manager.BeatBar.Count-1; i++)
        {
            if ( mousePos.y > manager.BeatBar[i].transform.position.y)
            {
                if(mousePos.y < manager.BeatBar[i + 1].transform.position.y)
                {
                    y = manager.BeatBar[i].transform.position.y;
                }
            }
        }
        return new Vector2(x, y);
    }
}
