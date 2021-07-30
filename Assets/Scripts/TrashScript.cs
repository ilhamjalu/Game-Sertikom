using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public float speed = 3f; // object movement speed 
    public float movementMultplier = -1f; // movement multiplier 
    public Vector3 screenPoint;
    public Vector3 offset;
    public float firstY; //default Y position
    public Sprite[] Sprites;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        TrashMovement(); // object trash move by x axis
    }

    private void TrashMovement()
    {
        float move = (speed * Time.deltaTime * movementMultplier) + transform.position.x; // move on -x axis 
        transform.position = new Vector3(move, transform.position.y); // set move position 
    }

    private void OnMouseDown()
    {
        firstY = transform.position.y; // default object y position
        screenPoint = Camera.main.ScreenToWorldPoint(gameObject.transform.position); // transform position by screen view 
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)); // set gameobject offset when object clicked refer to screen view

    }

    private void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); // set the input click by x and y axis 
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset; // set click position when the gameobject get drag 
        transform.position = cursorPosition; // assign gameoject transform when get drag by the cursor 
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(transform.position.x, firstY, transform.position.z); // reset object y position 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DestroyObj")
        {
            Destroy(gameObject);
        }
    }
}
