using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTouchControlHorinzontal : MonoBehaviour
{
    public float playerSpeed;
    private bool pauseGame = false;

    // Update is called once per frame
    void Update()
    {
        if (!pauseGame)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                touchPosition.y = 0;
                transform.position = Vector3.Lerp(transform.position, touchPosition, playerSpeed * Time.deltaTime);
            }
        }
    }

    public void pausarGame()
    {
        if(!pauseGame)
        {
            pauseGame = true;
        }
    }

    public void despausarGame()
    {
        if(pauseGame)
        {
            pauseGame = false;
        }
    }
}
