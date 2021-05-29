using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    public GameObject RootDialog;
    public Animator DialogBackground;
    public TextMeshProUGUI NameField;
    public TextMeshProUGUI TextField;

    public Dialogo dialogo;
    public float delayStartDialog;

    [SerializeField]
    PostDialogAction DialogAction;
    
    public void IniciarDialogo()
    {
        StartCoroutine(iniciarDialogo());
    }

    public void startDialogo()
    {
        FindObjectOfType<DialogManager>().startDialogo(dialogo, NameField, TextField);
    }

    IEnumerator iniciarDialogo()
    {
        yield return new WaitForSeconds(delayStartDialog);

        startDialogo();
    }

    public void EndDialog()
    {
        EscolhaCidadeController EscolhaController = FindObjectOfType<EscolhaCidadeController>();

        if (DialogAction == PostDialogAction.NEXTDIALOG)
            EscolhaController.NextDialog();

        if (DialogAction == PostDialogAction.ANIMATION)
            EscolhaController.PlayAnimation();

        RootDialog.SetActive(false);
    }
}

public enum PostDialogAction
{
    NEXTDIALOG, ANIMATION, NOTHING
}
