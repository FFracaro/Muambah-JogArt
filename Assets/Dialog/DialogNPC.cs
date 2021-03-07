using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    public bool NPC_img_left = false;
    public bool NPC_img_right = false;
    
    public Dialogo dialogo;
    public float delayStartDialog;
    
    void Start()
    {
        StartCoroutine(iniciarDialogo());
    }

    public void startDialogo(int posicaoIMG)
    {
        FindObjectOfType<DialogManager>().startDialogo(dialogo);
    }

    IEnumerator iniciarDialogo()
    {
        yield return new WaitForSeconds(delayStartDialog);

        startDialogo(0);
    }
}
