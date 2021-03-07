using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTouchControl : MonoBehaviour
{
    public float playerSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            transform.position = Vector3.Lerp(transform.position, touchPosition, playerSpeed*Time.deltaTime);
        }
    }
}
