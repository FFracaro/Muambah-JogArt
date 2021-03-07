using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public Button menuButton;

    // Enviar msg para o gameController despausar o jogo
    // Fecha o painel do menu principal
    public void despausarJogo()
    {
        if(menuPanel != null)
        {
            if (menuPanel.activeSelf)
            {
                menuPanel.SetActive(false);
                menuButton.gameObject.SetActive(true);
            }
        }
    }

    // Reinicia as variáveis do jogo e a fase atual
    public void reiniciarJogo()
    {

    }

    // Reinicia as variáveis do jogo, fecha a fase atual e abre a cena do menu inicial
    public void menuInicial()
    {

    }

    // Abre o menu de opções
    public void openMenu()
    {
        if(menuPanel != null)
        {
            if(!menuPanel.activeSelf)
            {
                menuButton.gameObject.SetActive(false);
                menuPanel.SetActive(true);
            }
        }
    }


    /* Métodos responsáveis pelos botões do menu inicial */

    // inicia um novo jogo
    public void playJogo(string _loadingScreenSceneToLoad)
    {
        var _asyncLoad = SceneManager.LoadSceneAsync(_loadingScreenSceneToLoad);
       /* _asyncLoad.allowSceneActivation = false;

        while (!_asyncLoad.isDone)
        {
            if (_asyncLoad.progress >= 0.9f)
            {
                _asyncLoad.allowSceneActivation = true;
            }
        }*/
    }

    // abre a janela de configuração do jogo
    public void configJogo()
    {
     
    }

    // abre a janela com o registro dos rankings dos jogadores
    public void rankJogo()
    {
        //dsadadad
    }

    // abre a animação com os créditos do jogo
    public void creditosJogo()
    {

    }

    public void fecharJogo()
    {
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                         Application.Quit();
        #endif
    }

}
