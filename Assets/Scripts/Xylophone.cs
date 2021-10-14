using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Xylophone : MonoBehaviour
{

    List<int> playedKeys = new List<int>();
    List<int> code = new List<int>() { 2, 6, 7, 4, 2 };
    public bool puzzleCompleted = false;
    public GameObject canvas;
    public GameObject menuCamera;
    public GameObject video;
    public VideoPlayer videoPlayer;
    public Radio radio;

    void OnEnable()
    {
        if (video.activeSelf) videoPlayer.Pause();
    }

    void OnDisable()
    {
        if (video.activeSelf) videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            exitMenu();
        }
    }

    public void keyPlayed(int key)
    {
        playedKeys.Add(key);
        if (playedKeys.Count == code.Count)
        {

            if (checkCorrectKeys(playedKeys, code))
            {
                if (video.activeSelf) video.SetActive(false);
                puzzleCompleted = true;
                radio.playXylophone();
                exitMenu();
            }
            else
            {
                playedKeys.RemoveRange(0, playedKeys.Count);
                //tell player that it is incorrect
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    void exitMenu()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        menuCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    bool checkCorrectKeys(List<int> playedKeys, List<int> rightKeys)
    {
        for (int i = 0; i < playedKeys.Count; i++)
        {
            if (playedKeys[i] != rightKeys[i]) return false;
        }
        return true;

    }

}
