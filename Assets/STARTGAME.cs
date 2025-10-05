using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene loading

public class StartGameButton : MonoBehaviour
{
    // Name of the scene to load (set it in the Inspector OR hardcode below)
    [SerializeField] private string sceneToLoad = "MAP";  

    // This method will show up in the Button OnClick list
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("⚠️ No scene assigned in StartGameButton script!");
        }
    }

    // (Optional) You can also use this for an Exit button
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is closing... (works only in a built game)");
    }
}
