using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Music music;
    public GameObject GridPool;
    private void Update()
    {
        if(music.isPlay)
        {
            MoveGrid();
        }
    }

    private void MoveGrid()
    {
        this.transform.Translate(Vector2.down * Time.smoothDeltaTime * 6 * music.BeatSpeed);
    }
    private void NewGrid()
    {
        
    }
}
