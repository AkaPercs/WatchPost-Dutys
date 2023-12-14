using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoaders : MonoBehaviour
{
    // Public method to load the "Hex" scene
    public void LoadMainScenes()
    {
        SceneManager.LoadScene("NewMain");
    }
}