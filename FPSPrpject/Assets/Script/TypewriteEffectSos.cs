using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriteEffectSos : MonoBehaviour
{
    public TMP_Text panelText;
    public string[] texts;
    private int currentIndex = 0;
    public float delay = 0.1f;
    private Coroutine typingCoroutine;

    private void Start()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        string fullText = texts[currentIndex];


        for(int i = 0; i <= fullText.Length; i++)
        {
            string currentText = fullText.Substring(0, i);
            panelText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    public void ChangeText()
    {
        currentIndex = (currentIndex + 1) % texts.Length;
        StartTyping();
    }


}
