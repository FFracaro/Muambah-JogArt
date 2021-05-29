using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDialogAtEndOfAnimation : MonoBehaviour
{
    public void CallDialog()
    {
        FindObjectOfType<EscolhaCidadeController>().NextDialog();
    }
}
