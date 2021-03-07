using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LojasBehaviour : MonoBehaviour
{
    public Button lojaUm;
    public Button lojaDois;
    public Button lojaTres;
    public Button lojaQuatro;

    public GameObject[] conteudoLojas;

    public void showConteudoPrimeiraLoja()
    {
        if(!conteudoLojas[0].activeSelf)
        {
            conteudoLojas[0].SetActive(true);
            lojaUm.gameObject.SetActive(false);
        }
    }

    public void showConteudoSegundaLoja()
    {
        if (!conteudoLojas[1].activeSelf)
        {
            conteudoLojas[1].SetActive(true);
            lojaDois.gameObject.SetActive(false);
        }
    }

    public void showConteudoTerceiraLoja()
    {
        if (!conteudoLojas[2].activeSelf)
        {
            conteudoLojas[2].SetActive(true);
            lojaTres.gameObject.SetActive(false);
        }
    }

    public void showConteudoQuartaLoja()
    {
        if (!conteudoLojas[3].activeSelf)
        {
            conteudoLojas[3].SetActive(true);
            lojaQuatro.gameObject.SetActive(false);
        }
    }

    public void resetScene()
    {
        if(conteudoLojas[0].activeSelf)
        {
            conteudoLojas[0].SetActive(false);
            lojaUm.gameObject.SetActive(true);
            Debug.Log("Loja um resetada.");
        }

        if (conteudoLojas[1].activeSelf)
        {
            conteudoLojas[1].SetActive(false);
            Debug.Log("Loja dois resetada.");
        }

        if (conteudoLojas[2].activeSelf)
        {
            conteudoLojas[2].SetActive(false);
            lojaTres.gameObject.SetActive(true);
            Debug.Log("Loja três resetada.");
        }

        if (conteudoLojas[3].activeSelf)
        {
            conteudoLojas[3].SetActive(false);
            lojaQuatro.gameObject.SetActive(true);
            Debug.Log("Loja quatro resetada.");
        }
        else
        {
            Debug.Log("i'm working.");
        }
    }
}
