using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LVL1 : MonoBehaviour
{
    [Header("Exact scene names as in Build Settings")]
    public string narrationSceneName = "Story Narration"; // narration scene
    public string levelSceneName = "Levels";              // gameplay scene

    // Main Menu button → goes to Narration first
    public void OnLevel1Click()
    {
        LoadIfInBuild(narrationSceneName);
    }

    // Narration Continue button → goes to actual gameplay
    public void OnContinueClick()
    {
        LoadIfInBuild(levelSceneName);
    }

    // Helper: check Build Settings
    private void LoadIfInBuild(string sceneName)
    {
        int count = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < count; i++)
        {
            string name = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            if (name == sceneName)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                return;
            }
        }
        Debug.LogError($"[LVL1] Scene '{sceneName}' is not listed in File > Build Settings > Scenes In Build.");
    }
}
