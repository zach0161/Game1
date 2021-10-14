using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform playerPosition;
    public Player player;
    public GameObject key;

    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerPosition.position) <= distance) {
        //outline key
            if (Input.GetKeyDown("e")) {
                player.inventory.Add(key.name);
                key.SetActive(false);
            }
        }
        
    }

}
