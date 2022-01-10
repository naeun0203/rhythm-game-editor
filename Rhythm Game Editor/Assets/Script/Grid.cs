using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : Poolable
{
    public Music music;
    private void Update()
    {
        if (music.isPlay)
        {
            MoveGrid();
        }
        if (this.transform.position.y <= -10)
        {
            DestoryGrid();
            CreateGrid();
        }
    }
        private void MoveGrid()
    {
        this.transform.Translate(Vector2.down * Time.smoothDeltaTime * 3 * music.BeatSpeed);
    }
    private void DestoryGrid()
    {
        Push();
    }
    private void CreateGrid()
    {
        ObjectPoolManager.Instance().pool.Pop().transform.position = new Vector2(0, 8);
    }
}
