using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseCode : MonoBehaviour
{

    public Light lamp;
    public Tablet tablet;
    // 0 = space, 1 = short, 2 = long, 3 = end, code = books
    List<int> morse = new List<int>() { 2, 1, 1, 1, 0, 2, 2, 2, 0, 2, 2, 2, 0, 2, 1, 2, 0, 1, 1, 1, 3 };
    float defaultIntensity;
    bool morseRunning = false;
    IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {

        float defaultIntensity = lamp.intensity;

        coroutine = runMorse(morse, defaultIntensity);
        StartCoroutine(coroutine);
        morseRunning = true;
    }

    void Update()
    {
        if (!tablet.puzzleDone)
        {
            if (!morseRunning)
            {
                StartCoroutine(runMorse(morse, defaultIntensity));
                morseRunning = true;
            }
        }
        else
        {
            StopCoroutine(coroutine);
            lamp.intensity = 1f;
            lamp.color = Color.white;
        }
    }

    IEnumerator runMorse(List<int> morse, float defaultIntensity)
    {

        foreach (int item in morse)
        {
            float seconds = 0f;
            switch (item)
            {
                case 0:
                    lamp.intensity = 0f;
                    seconds = 2f;
                    break;
                case 1:
                    lamp.intensity = 1f;
                    seconds = 0.5f;
                    break;
                case 2:
                    lamp.intensity = 1f;
                    seconds = 1.5f;
                    break;
                case 3:
                    lamp.intensity = 1f;
                    seconds = 5f;
                    lamp.color = Color.red;
                    break;
            }
            yield return new WaitForSeconds(seconds);
            lamp.intensity = 0f;
            lamp.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }

        morseRunning = false;


    }
}
