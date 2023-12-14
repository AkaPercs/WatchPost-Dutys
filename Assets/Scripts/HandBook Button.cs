using UnityEngine;
using UnityEngine.SceneManagement;

public class HandBookButton : MonoBehaviour
{
    // Public method to load the "Hex" scene
    public void LoadHexScene()
    {
        SceneManager.LoadScene("HandBook");
    }
}
