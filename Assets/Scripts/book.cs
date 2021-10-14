using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{

    public Player player;
    public Transform playerObject;
    public ControlsText controls;
    public Radio radio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, playerObject.position) <= 10)
        {
            //highlight tablet
            if (Input.GetKeyDown("e"))
            {
                controls.showBookText();
                radio.playBook();
                player.inventory.Add("symptomBook");
                gameObject.SetActive(false);
            }

        }

    }

}
