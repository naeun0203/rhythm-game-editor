using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public EditorManager manager;
    public Music music;
    public GameObject JudgmentLine;
    public GameObject NoteContainer;
    private GameObject[] Beat16;
    private GameObject[] Beat8;
    private float Beat4Location;
    private float Beat8Location;
    private float Beat16Location;

    private void Start()
    {
        Beat16 = GameObject.FindGameObjectsWithTag("Beat16");
        Beat8 = GameObject.FindGameObjectsWithTag("Beat8");
    }

    private void BeatBarLocation()
    {
        Beat4Location = music.BeatTime * 5;
        Beat8Location = Beat4Location/2;
        Beat16Location = Beat8Location / 2;

        Debug.Log(Beat4Location * 8 - JudgmentLine.transform.position.y);
    }
    public void CreateGrid()
    {
        BeatBarLocation();
        for (int i = 0; i < manager.Grid.Length; i++)
        {
            for(int j = 0; j < manager.Grid[i].transform.childCount; j++)
            {
                manager.Grid[i].transform.GetChild(j).transform.position = new Vector3(0, manager.Grid[i].transform.GetChild(0).transform.position.y + (j) * Beat16Location, 0);
            }
            manager.Grid[i].transform.position = new Vector3(0, JudgmentLine.transform.position.y + Beat4Location * 4 * i);
        }
    }
    public void BeatSetActive(bool isBeat16, bool isBeat8)
    {
        for(int i = 0; i < Beat16.Length; i++)
        {
            Beat16[i].SetActive(isBeat16);

        }
        for (int i = 0; i < Beat8.Length; i++)
        {
            Beat8[i].SetActive(isBeat8);
        }
    }
    public void ScrollGrid()
    {
        if (manager.Scroll < 0) // 위로
        {
            MoveGrid(Vector2.up * 0.5f);
            music.ScrollMusic(-0.1f);
        }
        else if (manager.Scroll > 0 ) // 아래로
        {
            MoveGrid(Vector2.down * 0.5f);
            music.ScrollMusic(0.1f);
        }
    }
    public void MoveGrid(Vector2 move)
    {
        for (int i = 0; i < manager.Grid.Length; i++)
        {
            manager.Grid[i].transform.Translate(move);
        }
        NoteContainer.transform.Translate(move);
    }

    public void GridLocation()
    {
        for (int i = 0; i < manager.Grid.Length; i++)
        {
            if (manager.Grid[i].transform.position.y <= - Beat4Location * 8 + JudgmentLine.transform.position.y) // JudgmentLine => -5
            {
                manager.Grid[i].transform.position = new Vector2(0, Beat4Location * 4 + JudgmentLine.transform.position.y);
            }
            if (manager.Grid[i].transform.position.y >= Beat4Location * 8 + JudgmentLine.transform.position.y)
            {
                manager.Grid[i].transform.position = new Vector2(0, JudgmentLine.transform.position.y - Beat4Location * 4 );
            }
        }
    }
}