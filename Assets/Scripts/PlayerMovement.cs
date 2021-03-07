using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isGamePaused = false;

    public float velocityWalk = 4f;
    public float velocityRun = 10.0f;
    public float scaleUpDown = 0.4f;

    private Camera mainCamera;
    private Rigidbody2D playerRigidbody;
    private Vector2 movementVector;
    //private Vector3 localSize;

    private bool upMovement = true;
    private bool downMovement = true;

    void Start()
    {
        //localSize = transform.localScale;
        movementVector.x = 0;
        movementVector.y = 0;
        mainCamera = Camera.main;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isGamePaused)
        {
            getInput();
            moveCharacter();
        }
    }

    public void setPauseGame(bool pauseStatus)
    {
        isGamePaused = pauseStatus;
    }

    void getInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementVector.x = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementVector.x = -1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (upMovement)
            {
                movementVector.y = 1f;
                //transform.localScale -= transform.localScale * Time.deltaTime * scaleUpDown;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (downMovement)
            {
                movementVector.y = -1f;
                //transform.localScale += transform.localScale * Time.deltaTime * scaleUpDown;
            }
        }
    }

    void moveCharacter()
    {
        movementVector.Normalize();
        playerRigidbody.velocity = movementVector * velocityWalk;
        movementVector.x = 0;
        movementVector.y = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "RestrictionTop")
        {
            upMovement = false;
            //transform.localScale = localSize;
        }
        else if(collision.gameObject.tag == "RestrictionBot")
        {
            downMovement = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit " + collision.gameObject.tag);
        if (collision.gameObject.tag == "RestrictionTop")
        {
            upMovement = true;
        }
        else if(collision.gameObject.tag == "RestrictionBot")
        {
            downMovement = true;
        }
    }
}
