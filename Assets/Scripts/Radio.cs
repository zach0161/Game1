using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Radio : MonoBehaviour
{

    public AudioSource music;
    public AudioSource voice;
    public List<AudioClip> randomLines;
    public List<AudioClip> storyLines;
    public Timer timer;
    public float musicOriginalVolume;
    public VideoPlayer videoPlayer;
    public GameObject xylophone;

    // Start is called before the first frame update
    void Start()
    {
        musicOriginalVolume = music.volume;
        playIntro();
        StartCoroutine(playRandomLines());
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying)
        {
            music.Play();
        }
        if (voice.isPlaying || videoPlayer.isPlaying || xylophone.activeSelf) {
            music.volume = 0.1f;
        } else {
            music.volume = music.volume;
        }

        


        

    }

    void playIntro() {
        voice.PlayOneShot(storyLines[0]);
    }

    public void playBook() {
        voice.PlayOneShot(storyLines[1]);
    }

    public void playXylophone() {
        voice.PlayOneShot(storyLines[2]);
    }

    public void playAlmostDone() {
        voice.PlayOneShot(storyLines[3]);
    }

    IEnumerator playRandomLines() {
        yield return new WaitForSeconds(30f);
        if (!voice.isPlaying) {
            voice.PlayOneShot(randomLines[Random.Range(0, randomLines.Count-1)]);
        }
        StartCoroutine(playRandomLines());
    }
}
