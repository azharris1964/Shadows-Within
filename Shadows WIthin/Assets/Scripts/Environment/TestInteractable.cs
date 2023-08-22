using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestInteractable : Interactable
{
    public TextMeshProUGUI interactionText;
    [TextArea] public string[] noteSentences; // Array of sentences to display
    private string originalText = "";
    private bool isDisplayingNote = false;
    [SerializeField] private float textSpeed = 0.05f; // Adjustable text speed
    private int currentSentenceIndex = 0;

    private Coroutine textDisplayCoroutine;

    private void Start()
    {
        originalText = interactionText.text;
        HideNote();
    }

    public void ToggleInteraction()
    {
        if (isDisplayingNote) HideNote();
        else ShowNote();
    }

    private void ShowNote()
    {
        PauseGame();
        interactionText.gameObject.SetActive(true);
        isDisplayingNote = true;
        currentSentenceIndex = 0; // Reset the index to start from the beginning


        // Start the coroutine to display text letter by letter
        textDisplayCoroutine = StartCoroutine(DisplayTextSentences());
    }

    private void HideNote()
    {
        ResumeGame();
        interactionText.gameObject.SetActive(false);
        interactionText.text = "";
        isDisplayingNote = false;

        // Stop the text display coroutine if it's running
        if (textDisplayCoroutine != null)
        {
            StopCoroutine(textDisplayCoroutine);
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private IEnumerator DisplayTextSentences()
    {
        for (int i = currentSentenceIndex; i < noteSentences.Length; i++)
        {
            string sentence = noteSentences[i];
            Debug.Log("Displaying sentence: " + sentence); // Add this line
            interactionText.text = "";
            foreach (char letter in sentence)
            {
                interactionText.text += letter; // Append one letter at a time
                yield return new WaitForSecondsRealtime(textSpeed); // Wait for a specified time
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); // Wait for interact button press
            currentSentenceIndex++;

            if (i >= noteSentences.Length - 1)
            {
                currentSentenceIndex = 0; // Reset index to start from the beginning
                HideNote();
            }
        }
    }


    public override void OnInteract()
    {
        ToggleInteraction();
    }

    public override void OnFocus()
    {
        // Implement the focus behavior when the player's focus is on the note
        Debug.Log("Player focused on the interactable.");
    }

    public override void OnLoseFocus()
    {
        // Implement the behavior when the player's focus is lost from the note
        Debug.Log("Player lost focus on the interactable.");
    }
}