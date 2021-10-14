using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{

    public Jigsaw jigsaw;
    bool videoRunning = false;
    public GameObject video;
    VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = video.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jigsaw.puzzleFinished && !videoRunning)
        {
            video.SetActive(true);
            player.Play();
            videoRunning = true;
        }

    }
}
