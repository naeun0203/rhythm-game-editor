using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MusicList
{
    public string Name;
    public AudioClip Music;
}
public class Music : MonoBehaviour
{
    public MusicList[] music;
    public EditorManager editor;
    public MusicData musicData;
    public AudioSource audio;
    public float BeatTime { get; set; }
    public float Beat16 { get; set; }
    public float Beat8 { get; set; }
    public float Beat4 { get; set; }
    public float TotalSec { get; set; }

    public void MusicPlay()
    {
        audio.Play();
        editor.isPlay = true;
    }

    public void MusicPause()
    {
        audio.Pause();
        editor.isPlay = false;
    }
    public void MusicStop()
    {
        audio.Stop();
        editor.isPlay = false;
    }
    public void ChangeMusic()
    {
        for(int i = 0; i < music.Length; i++)
        {
            if (music[i].Name == musicData.MusicList.options[musicData.MusicList.value].text)
            {
                audio.clip = music[i].Music;
            }
        }
    }
    public void ScrollMusic(float time)
    {
        float currentTime = audio.time;
        currentTime += time;
        currentTime = Mathf.Clamp(currentTime, 0f, audio.clip.length - 0.0001f);
        audio.time = currentTime;
    }
    public double CurrentMusicTime(Vector2 position)
    {
        double currentTime = audio.time;
        double positionTime = 0.2 * (position.y + 5);
        return positionTime + currentTime;
    }
    public void Beat()
    {
        BeatTime = 60 / (float)musicData.noteData.BPM;
        Beat4 = BeatTime;
        Beat8 = Beat4 / 2;
        Beat16 = Beat8 / 2;

        TotalSec = (int)audio.clip.length;
    }
}
