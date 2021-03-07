using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    public string _sceneToLoad;
    public Slider _loadingSlider;
    private float timeInicial;

    AsyncOperation _asyncLoad;

    void Start()
    {
        timeInicial = Time.time;
        StartCoroutine(LoadingNewSceneAsync());
    }

    IEnumerator LoadingNewSceneAsync()
    {
        yield return new WaitForSeconds(0.3f);      

        _asyncLoad = SceneManager.LoadSceneAsync(_sceneToLoad);
        _asyncLoad.allowSceneActivation = false;


        while(!_asyncLoad.isDone)
        {
            if ((Time.time - timeInicial) < 4f)
            {
                _loadingSlider.value = (Time.time - timeInicial) / 3.85f;
            }
            else
            {
                if (_asyncLoad.progress >= 0.9f)
                {
                    _loadingSlider.value = 1f;

                    yield return new WaitForSeconds(1f);

                    _asyncLoad.allowSceneActivation = true; 
                }
            }
            yield return null;
        }
    }
}
