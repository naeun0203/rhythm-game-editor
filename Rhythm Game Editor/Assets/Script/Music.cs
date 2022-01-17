using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public EditorManager editor;
    public AudioSource audio;
    public int BPM = 100;
    public float BeatTime;

    void Awake()
    {
        BeatTime = 60 / (float)BPM;
        Debug.Log(BeatTime);
        Debug.Log(BPM);
    }
    private void MusicPlay()
    {
        audio.Play();
        editor.isPlay = true;
    }

    private void MusicPause()
    {
        audio.Pause();
        editor.isPlay = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Debug.Log(audio.time);
            if (!editor.isPlay)
            {
                MusicPlay();
            }
            else 
            {
                MusicPause();
            }
        }
    }

    public void ScrollMusic(float time)
    {
        float currentTime = audio.time;
        currentTime += time;
        currentTime = Mathf.Clamp(currentTime, 0f, audio.clip.length - 0.0001f);
        audio.time = currentTime;
        Debug.Log(audio.time);
    }
    private void Beat()
    {

    }
}
