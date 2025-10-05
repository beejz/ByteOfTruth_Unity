using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerManager : MonoBehaviour
{
    [Header("Correct Answer (exact token)")]
    public string correctAnswer = "VERIFIED";     // <- matches your button's string

    [Header("Scenes")]
    public string correctSceneName = "Correct1";
    public string wrongSceneName = "Wrong1";

    [Header("Optional")]
    public float delayBeforeLoad = 0.05f;

    public void OnAnswerSelected(string choice)
    {
        // Normalize to avoid hidden mismatches
        string a = (choice ?? "").Trim().ToUpperInvariant();
        string b = (correctAnswer ?? "").Trim().ToUpperInvariant();

        bool isCorrect = a == b;
        string target = isCorrect ? correctSceneName : wrongSceneName;

        if (delayBeforeLoad <= 0f)
        {
            SceneManager.LoadScene(target);
        }
        else
        {
            StartCoroutine(LoadAfterDelay(target));
        }
    }

    private System.Collections.IEnumerator LoadAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(sceneName);
    }
}
