using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    public Animator drawer;
    public Player player;
    public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerPosition.position) <= 12) {
        //outline key
            if (Input.GetKeyDown("e")) {
                    drawer.SetBool("Open", true);
                    gameObject.GetComponent<AudioSource>().Play();                
            }
        }
        
    }
}
