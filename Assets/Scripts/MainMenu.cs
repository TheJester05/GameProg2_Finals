using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt("TotalPotionEffect", 0);
        PlayerPrefs.DeleteKey("PotionValue");
        PlayerPrefs.Save();
        
        Debug.Log("Game Reset. Starting a new session.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
