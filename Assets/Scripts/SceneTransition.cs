using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaders : MonoBehaviour
{
    // Public method to load the "Hex" scene
    public void LoadHexScene()
    {
        SceneManager.LoadScene("NewMain");
    }
}
