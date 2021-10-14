using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseAlphabet : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public Transform playerPosition;
    public AudioSource source;
    public ControlsText controls;
    public Animator drawer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && Vector3.Distance(gameObject.transform.position, playerPosition.position) < 10)
        {
            source.Play();
            drawer.SetBool("Empty", true);
            controls.showMorseText();
            player.inventory.Add("Alphabet");
        }
    }

}
