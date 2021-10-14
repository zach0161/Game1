using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 600f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.unscaledDeltaTime;
        }
        else
        {
            // gameover
            SceneManager.LoadScene(0);
            
        }
    }
}
