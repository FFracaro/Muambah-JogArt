using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject btnTerceira;
    public GameObject[] lojas;

    /*
    void OnTriggerEnter2D(Collider2D objeto)
    {
        Debug.Log("COLISÃO");
        if(objeto.gameObject.tag == "segundaLoja")
        {
            Debug.Log("segundaLoja");
            if (!lojas[0].activeSelf)
            {
                lojas[0].SetActive(true);
            }
        }

        if(objeto.gameObject.tag == "terceiraLoja")
        {
            Debug.Log("terceiraLoja");
            if (!lojas[1].activeSelf)
            {
                lojas[1].SetActive(true);
                btnTerceira.SetActive(false);
            }
        }
    }
    */
}
