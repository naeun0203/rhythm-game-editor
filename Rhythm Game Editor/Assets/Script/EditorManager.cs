using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EditorManager : MonoBehaviour
{
    public bool isPlay { get; set; }
    public float Beat { get; set; }
    public bool isScroll { get; set; }
    public float Scroll { get; set; }

    private void Update()
    {
        OnScroll();
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
