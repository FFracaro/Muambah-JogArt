using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscolhaCidadeController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Dialogs;

    [SerializeField]
    GameObject Canvas;

    [SerializeField]
    int DialogCount = 0;

    [SerializeField]
    Animator CardsAnimator;

    // Start is called before the first frame update
    void Start()
    {
        NextDialog();
    }

    public void NextDialog()
    {
        Dialogs[DialogCount].SetActive(true);
        Dialogs[DialogCount].GetComponent<DialogNPC>().IniciarDialogo();
        DialogCount++;
    }

    public void PlayAnimation(PostDialogAction value)
    {
        if (value == PostDialogAction.ENTERCARDS)
            CardsAnimator.Play("CardsEntrance");

        if(value == PostDialogAction.EXITCARDS)
            CardsAnimator.Play("CardsExit");

        if (value == PostDialogAction.CHOOSECARD)
            CardsAnimator.Play("CardsAnimation");
    }
}

public enum DialogStatus
{
    STARTED, FINISHED
}
