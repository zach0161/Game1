using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsText : MonoBehaviour
{

    public GameObject bookText;
    public GameObject morseText;
    public GameObject interactText;

    // Start is called before the first frame update

    void Start() {
        showInteractText();
    }


    public void showBookText()
    {
        StartCoroutine(showControls(bookText));
    }

    public void showMorseText()
    {
        StartCoroutine(showControls(morseText));
    }

    public void showInteractText() {
        StartCoroutine(showControls(interactText));
    }

    IEnumerator showControls(GameObject text)
    {
        // show text in 3 seconds
        text.SetActive(true);
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
