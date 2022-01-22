using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public EditorManager editor;
    public Music music;
    public GameObject Beat16;
    public GameObject Beat8;
    public Toggle ToggleBeat16;
    public Toggle ToggleBeat8;
    private void BeatBarLocation()
    {

    }
    public void Beat16SetActive()
    {
        if(ToggleBeat16.isOn)
        {
            Beat16.SetActive(true);
        }
        else if (!ToggleBeat16.isOn)
        {
            Beat16.SetActive(false);
        }
    }
    public void Beat8SetActive()
    {
        if (ToggleBeat8.isOn)
        {
            Beat8.SetActive(true);
        }
        else if (!ToggleBeat16.isOn)
        {
            Beat8.SetActive(false);
        }
    }
    public void ScrollGrid()
    {
        if (editor.Scroll < 0) // 위로
        {
            this.transform.Translate(Vector2.up * 0.5f);
            music.ScrollMusic(-0.1f);
        }
        else if (editor.Scroll > 0 ) // 아래로
        {
            this.transform.Translate(Vector2.down * 0.5f);
            music.ScrollMusic(0.1f);
        }
    }
    public void MoveGrid()
    {
        this.transform.Translate(Vector2.down * Time.smoothDeltaTime * 5);
    }
}