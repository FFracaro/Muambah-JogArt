using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionPedestres : MonoBehaviour
{

    public GameObject respawnPosition;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Pedreste")
        {
            collision.gameObject.SetActive(false);
            PedresteAI pAI = collision.gameObject.GetComponent<PedresteAI>();
            collision.gameObject.transform.position = new Vector2(respawnPosition.transform.position.x, 
                pAI.getInitialPositionY());
            pAI.changeTarget();
            collision.gameObject.SetActive(true);
        }
    }

}
