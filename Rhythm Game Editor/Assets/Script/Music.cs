using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audio;
    public int BPM = 100;
    public float BeatTime;
    public float BeatSpeed;

    public bool isPlay = false;
    // Start is called before the first frame update
    void Awake()
    {
        BeatTime = 60 / (float)BPM;
        BeatSpeed = BeatTime + 1;
        Debug.Log(BeatTime);
        Debug.Log(BPM);
    }
    private void MusicPlay()
    {
        audio.Play();
        isPlay = true;
    }

    private void MusicPause()
    {
        audio.Pause();
        isPlay = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Debug.Log(audio.time);
            if (!isPlay)
            {
                MusicPlay();
            }
            else 
            {
                MusicPause();
            }
        }


    }
    private void Beat()
    {

    }
}
