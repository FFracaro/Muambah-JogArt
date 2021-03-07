using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LojasBehaviourSegundo : MonoBehaviour
{
    public Button lojaUm;
    public Button lojaTres;
    public Button lojaQuatro;
    public Text horasTimer;
    public Text minutosTimer;

    public GameObject[] conteudoLojas;
    private bool[] lojaAbertaPeloJogador = { false, false, false };

    public float velocidadeTempo;
    public int qtdTempoPerLoja;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(horasCidadeUpdater());
    }

    public void showConteudoPrimeiraLoja()
    {
        if (!conteudoLojas[0].activeSelf)
        {
            lojaAbertaPeloJogador[0] = true;
            lojaUm.gameObject.SetActive(false);
            conteudoLojas[0].SetActive(true);           
        }
    }

    public void showConteudoTerceiraLoja()
    {
        if (!conteudoLojas[1].activeSelf)
        {
            lojaAbertaPeloJogador[1] = true;
            lojaTres.gameObject.SetActive(false);
            conteudoLojas[1].SetActive(true);
        }
    }

    public void showConteudoQuartaLoja()
    {
        if (!conteudoLojas[2].activeSelf)
        {
            lojaAbertaPeloJogador[2] = true;
            lojaQuatro.gameObject.SetActive(false);
            conteudoLojas[2].SetActive(true);          
        }
    }

    IEnumerator horasCidadeUpdater()
    {
        int minutos = 0;
        int horas = 8;

        while(true)
        {
            minutos = verifyLojasSelecionadas(minutos);

            yield return new WaitForSeconds(velocidadeTempo);

            minutos++;

            if(minutos > 59)
            {
                horas += minutos / 60;
                minutos = minutos % 60;

                if (horas < 10)
                    horasTimer.text = "0" + horas.ToString();
                else
                    horasTimer.text = horas.ToString();          
            }

            if (minutos < 10)
                minutosTimer.text = "0" + minutos.ToString();
            else
                minutosTimer.text = minutos.ToString();
        }
    }

    public int verifyLojasSelecionadas(int minutos)
    {
        if (lojaAbertaPeloJogador[0])
        {
            minutos += qtdTempoPerLoja;
            lojaAbertaPeloJogador[0] = false;
        }           

        if (lojaAbertaPeloJogador[1])
        {
            minutos += qtdTempoPerLoja;
            lojaAbertaPeloJogador[1] = false;
        }    

        if (lojaAbertaPeloJogador[2])
        {
            minutos += qtdTempoPerLoja;
            lojaAbertaPeloJogador[2] = false;
        }
        return minutos;
    }
}
