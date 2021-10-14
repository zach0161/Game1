using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePosition : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 correctPosition;
    AudioSource source;
    bool placed = false;

    void Start()
    {

        source = gameObject.GetComponentInParent<AudioSource>();
        correctPosition = transform.position;
        Canvas canvas = FindObjectOfType<Canvas>();
        GameObject playArea = GameObject.Find("PlayArea");

        // calculating the range of where the puzzle pieces can be

        // getting the dimensions of the canvas
        float maxWidth = canvas.GetComponent<RectTransform>().rect.width;
        float maxHeight = canvas.GetComponent<RectTransform>().rect.height;

        // getting the width of the playArea - the area in which the completed jigsaw is located
        float minWidth = playArea.GetComponent<RectTransform>().rect.width;

        // getting the dimensions of the piece
        float objectWidth = gameObject.GetComponent<RectTransform>().rect.width;
        float objectHeight = gameObject.GetComponent<RectTransform>().rect.height;

        // the scale of the canvas needs to be taken in to account
        float xScale = canvas.GetComponent<RectTransform>().transform.localScale.x;
        float yScale = canvas.GetComponent<RectTransform>().transform.localScale.y;

        transform.position = new Vector3(Random.Range((minWidth + objectWidth) * xScale, (maxWidth - objectWidth) * xScale), 
        Random.Range(objectHeight * yScale, (maxHeight - objectHeight) * yScale), 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, correctPosition) < 50)
        {
            transform.position = correctPosition;
        }

        if (Vector3.Distance(transform.position, correctPosition) < 0.1f)
        {

            transform.gameObject.tag = "Locked";
            
        }
        else
        {
            transform.gameObject.tag = "Piece";

        }

        if (transform.gameObject.tag == "Locked" && Input.GetMouseButtonUp(0) && !placed) {
            placed = true;
            source.Play();
        }
    }
}
