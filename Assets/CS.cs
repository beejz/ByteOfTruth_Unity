using UnityEngine;
using UnityEngine.SceneManagement;

public class CamSurButton : MonoBehaviour
{
    // Name of the scene to load when this is clicked
    [SerializeField] private string sceneToLoad = "Level";

    // This will be called when the player clicks the icon
    public void OnClick()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No scene assigned in CamSurButton script!");
        }
    }
}
