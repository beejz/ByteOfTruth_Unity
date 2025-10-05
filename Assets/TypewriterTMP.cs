using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // For scene loading

public class TypewriterTMP : MonoBehaviour
{
    public TMP_Text targetText;
    public float charsPerSecond = 45f;
    public float punctuationPause = 0.2f;

    [Header("Continue Button")]
    public GameObject continueButton;   // Assign in Inspector
    public string nextSceneName = "Levels"; // Name of your main game scene

    void Awake()
    {
        if (!targetText) targetText = GetComponent<TMP_Text>();
        if (continueButton) continueButton.SetActive(false); // hide at start
    }

    void Start()
    {
        if (targetText != null && !string.IsNullOrEmpty(targetText.text))
        {
            string fullText = targetText.text;
            StartCoroutine(TypeRoutine(fullText));
        }
    }

    IEnumerator TypeRoutine(string fullText)
    {
        targetText.text = fullText;
        targetText.ForceMeshUpdate();

        int total = targetText.textInfo.characterCount;
        targetText.maxVisibleCharacters = 0;

        for (int i = 0; i < total; i++)
        {
            targetText.maxVisibleCharacters = i + 1;

            float delay = 1f / charsPerSecond;
            char c = GetRenderedChar(targetText, i);
            if (".,!?;:".IndexOf(c) >= 0) delay += punctuationPause;

            yield return new WaitForSeconds(delay);
        }

        // ✅ Typing finished, show Continue button
        if (continueButton) continueButton.SetActive(true);
    }

    char GetRenderedChar(TMP_Text tmp, int renderedIndex)
    {
        if (renderedIndex < 0 || renderedIndex >= tmp.textInfo.characterCount) return '\0';
        var ci = tmp.textInfo.characterInfo[renderedIndex];
        return (ci.index >= 0 && ci.index < tmp.text.Length) ? tmp.text[ci.index] : '\0';
    }

    // ✅ Called by the Continue button OnClick event
    public void GoToNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
