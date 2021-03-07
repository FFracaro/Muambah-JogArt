using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI NPC_name;
    public TextMeshProUGUI dialogoText;

    public float velocidadeDialogo;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogo(Dialogo dialogo)
    {
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
    }
}
