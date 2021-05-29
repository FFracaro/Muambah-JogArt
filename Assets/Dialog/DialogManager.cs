using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    private TextMeshProUGUI NPC_name;
    private TextMeshProUGUI dialogoText;

    public float velocidadeDialogo;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogo(Dialogo dialogo, TextMeshProUGUI NameField, TextMeshProUGUI TextField)
    {
        NPC_name = NameField;
        dialogoText = TextField;

        Debug.Log("Iniciando conversa com " + dialogo.name);

        NPC_name.text = dialogo.name;

        sentences.Clear();

        foreach(string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);
        }

        mostrarProximoDialogo();
    }

    public void mostrarProximoDialogo()
    {       
        if (sentences.Count == 0)
        {
            finalizarDialogo();
        }
        else
        {
            string sentence = sentences.Dequeue();

            Debug.Log(sentence);

            StopAllCoroutines();

            velocidadeDialogo = 0.1f;

            if (sentence.Length > 20)
                velocidadeDialogo = velocidadeDialogo / 3;

            StartCoroutine(digitarSentence(sentence));
        }
    }

    IEnumerator digitarSentence(string sentence)
    {
        dialogoText.text = "";
        foreach(char letra in sentence.ToCharArray())
        {
            dialogoText.text += letra;
            yield return new WaitForSeconds(velocidadeDialogo);
        }
    }

    void finalizarDialogo()
    {
        Debug.Log("Final da conversa.");
        FindObjectOfType<DialogNPC>().EndDialog();
    }
}
