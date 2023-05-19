using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    private EditorManager manager;
    public Music music;
    public GameObject JudgmentLine;
    public GameObject NoteContainer;
    public GameObject[] GridObject;
    private GameObject[] Beat16;
    private GameObject[] Beat8;
    private float Beat4Location, Beat8Location, Beat16Location;
    public List<Transform> BeatBar = new List<Transform>();
    private void Awake()
    {
        manager = EditorManager.Instance;
        Beat16 = GameObject.FindGameObjectsWithTag("Beat16");
        Beat8 = GameObject.FindGameObjectsWithTag("Beat8");
    }
    /// <summary>
    /// BeatBar 받아오기
    /// </summary>
    private void init()
    {
        for (int i = 0; i < GridObject.Length; i++)
        {
            for (int j = 0; j < GridObject[i].transform.childCount; j++)
            {
                BeatBar.Add(GridObject[i].transform.GetChild(j));
            }
        }
    }
    private void Update()
    {
        GridLocation();
        if (manager.isPlay)
        {
            MoveGrid(Vector2.down * Time.smoothDeltaTime * 500);
        }
    }
    /// <summary>
    /// BPM에 따른 BeatBar 간격 조정
    /// </summary>
    private void BeatBarLocation()
    {
        Beat4Location = music.BeatTime * 500;
        Beat8Location = Beat4Location * 0.5f;
        Beat16Location = Beat8Location * 0.5f;
    }

    public void CreateGrid()
    {
        BeatBarLocation();
        for (int i = 0; i < GridObject.Length; i++)
        {
            for(int j = 0; j < GridObject[i].transform.childCount; j++)
            {
                GridObject[i].transform.GetChild(j).transform.position = new Vector3(0, GridObject[i].transform.GetChild(0).transform.position.y + (j) * Beat16Location, 0);
            }
            GridObject[i].transform.position = new Vector3(0, JudgmentLine.transform.position.y + Beat4Location * 4 * i);
        }
    }
    public void BeatSetActive(bool isBeat16, bool isBeat8)
    {
        foreach(var beat16 in Beat16)
        {
            beat16.SetActive(isBeat16);
        }
        foreach (var beat8 in Beat8)
        {
            beat8.SetActive(isBeat8);
        }
    }
    public void ScrollGrid(float scroll)
    {
        if (scroll < 0) // 위로
        {
            MoveGrid(Vector2.up * 50f);
            music.ScrollMusic(-0.1f);
        }
        else if (scroll > 0 ) // 아래로
        {
            MoveGrid(Vector2.down * 50f);
            music.ScrollMusic(0.1f);
        }
    }
    public void MoveGrid(Vector2 move)
    {
        for (int i = 0; i < GridObject.Length; i++)
        {
            GridObject[i].transform.Translate(move);
        }
        NoteContainer.transform.Translate(move);
    }

    public void GridLocation()
    {
        for (int i = 0; i < GridObject.Length; i++)
        {
            if (GridObject[i].transform.position.y <= - Beat4Location * 8 + JudgmentLine.transform.position.y) // JudgmentLine => -5
            {
                GridObject[i].transform.position = new Vector2(0, Beat4Location * 4 + JudgmentLine.transform.position.y);
            }
            if (GridObject[i].transform.position.y >= Beat4Location * 8 + JudgmentLine.transform.position.y)
            {
                GridObject[i].transform.position = new Vector2(0, JudgmentLine.transform.position.y - Beat4Location * 4 );
            }
        }
    }
}