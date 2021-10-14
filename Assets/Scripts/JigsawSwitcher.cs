using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawSwitcher : MonoBehaviour
{

    public GameObject finishedJigsaw;
    public Jigsaw jigsaw;
    public Animator animator;

    void Update() {
        if (jigsaw.puzzleFinished) {
            animator.SetBool("JigsawFinnished", true);
        }
    }


    void OnDisable() {
        finishedJigsaw.SetActive(true);
    }
}
