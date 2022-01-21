using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public EditorManager editor;
    public Music music;

    private void BeatBarLocation()
    {

    }
    public void ScrollGrid()
    {
        if (editor.Scroll < 0)
        {
            this.transform.Translate(Vector2.up * 0.5f);
            music.ScrollMusic(-0.1f);
        }
        if (editor.Scroll > 0)
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