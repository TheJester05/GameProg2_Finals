using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartQuit : MonoBehaviour
{
    public void RestartGame()
    {
        // Reset game-related PlayerPrefs values
        PlayerPrefs.SetInt("TotalPotionEffect", 0);
        PlayerPrefs.DeleteKey("PotionValue");
        PlayerPrefs.Save();

        // Log for debugging
        Debug.Log("Game Reset. Returning to the main menu.");

        // Load the main menu scene (assuming it's the first scene in your build)
        SceneManager.LoadScene("Menu"); // Replace "MainMenu" with the actual name of your menu scene
    }

    public void QuitGame()
    {
        // Quit the application
        Debug.Log("Game Quit.");
        Application.Quit();
    }
}
