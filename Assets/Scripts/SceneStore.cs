using UnityEngine;

public class SceneStore : MonoBehaviour
{
    private static bool isGameSessionStarted = false;
    private int totalPotionEffect;

    void Start()
    {
        if (!isGameSessionStarted)
        {
            ResetTotalPotionEffect();
            isGameSessionStarted = true;
        }

        totalPotionEffect = PlayerPrefs.GetInt("TotalPotionEffect", 0);
        Debug.Log($"Current Total Potion Effect: {totalPotionEffect}");

        if (PlayerPrefs.HasKey("PotionValue"))
        {
            int lastPotionValue = PlayerPrefs.GetInt("PotionValue", 0);
            Debug.Log($"Last Potion Value Retrieved: {lastPotionValue}");

            totalPotionEffect += lastPotionValue;
            PlayerPrefs.SetInt("TotalPotionEffect", totalPotionEffect);
            PlayerPrefs.Save();

            Debug.Log($"Updated Total Potion Effect: {totalPotionEffect}");
        }
        else
        {
            Debug.LogWarning("No PotionValue found in PlayerPrefs!");
        }

        ResetPotionValue();
    }

    private void ResetPotionValue()
    {
        PlayerPrefs.DeleteKey("PotionValue");
        Debug.Log("Potion Value Reset");
    }

    private void ResetTotalPotionEffect()
    {
        PlayerPrefs.SetInt("TotalPotionEffect", 0);
        PlayerPrefs.Save();
        Debug.Log("Total Potion Effect Reset to 0");
    }
}
