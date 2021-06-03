using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TarotAnimation : MonoBehaviour
{
    public GameObject BlackBackgroundPanel;
    public Animator TarotAnimator;

    public void CallDialog()
    {
        FindObjectOfType<EscolhaCidadeController>().NextDialog();
    }

    public void DisableBlackBackgroundPanel()
    {
        StartCoroutine(FadeOutBlackPanel());
    }

    private IEnumerator FadeOutBlackPanel()
    {
        BlackBackgroundPanel.GetComponent<Image>().CrossFadeAlpha(0, 3, true);

        yield return new WaitForSeconds(3.0f);

        BlackBackgroundPanel.SetActive(false);
    }

    public void CallAnimation()
    {
        FindObjectOfType<EscolhaCidadeController>().PlayAnimation(PostDialogAction.CHOOSECARD);
    }
}
