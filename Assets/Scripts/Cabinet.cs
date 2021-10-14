using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public Animator cabinet;
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
                if (player.inventory.Contains("CabinetKey")) {
                    player.inventory.Remove("CabinetKey");
                    cabinet.SetBool("Open", true);
                }
                
            }
        }
        
    }
}
