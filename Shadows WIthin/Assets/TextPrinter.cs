using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextPrinter : MonoBehaviour
{
    string textToType = "This is the line to print";

    TMP_Text subtitleTextMesh;

    private void Awake()
    {
        subtitleTextMesh = GetComponent<TMP_Text>();
    }
    void Start()
    {
        StartCoroutine(TypeTextCoroutine());

    }

    IEnumerator TypeTextCoroutine()
    {
        subtitleTextMesh.text = string.Empty;

        for (int i = 0; i < textToType.Length; i++)
        {
            subtitleTextMesh.text += textToType[i];

            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }

    
}
