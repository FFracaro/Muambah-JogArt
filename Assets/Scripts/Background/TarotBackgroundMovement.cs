using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotBackgroundMovement : MonoBehaviour
{
    public GameObject BackgroundTarot;
    public float SpeedMovement;

    // Update is called once per frame
    void Update()
    {
        if (BackgroundTarot.transform.localPosition.x < -700)
            SpeedMovement *= -1;
        
        if(BackgroundTarot.transform.localPosition.x > 800)
            SpeedMovement *= -1;

        BackgroundTarot.transform.localPosition += Vector3.right * SpeedMovement * Time.deltaTime;
    }
}
