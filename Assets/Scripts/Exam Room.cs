using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Public method to load the "Hex" scene
    public void LoadMainScene()
    {
        SceneManager.LoadScene("NewMain");
    }
}
