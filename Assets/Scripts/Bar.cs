using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bar : MonoBehaviour
{
    [SerializeField] private GameObject[] potionBars; 
    [SerializeField] private GameObject youWonImage; 
    [SerializeField] private GameObject youLoseImage; 

    void Start()
    {
        
        HideAllBars();
        HideOutcomeImages();

        
        int totalPotionEffect = PlayerPrefs.GetInt("TotalPotionEffect", 0);
        Debug.Log($"Total Potion Effect Retrieved: {totalPotionEffect}");

        
        int barsToShow = GetBarsToShow(totalPotionEffect);
        Debug.Log($"Bars to Show: {barsToShow}");
        ShowBars(barsToShow);

        
        StartCoroutine(ShowOutcomeAfterDelay(totalPotionEffect, 1f));
    }

    
    private void HideAllBars()
    {
        foreach (GameObject bar in potionBars)
        {
            bar.SetActive(false);
        }
    }

    
    private void HideOutcomeImages()
    {
        if (youWonImage != null) youWonImage.SetActive(false);
        if (youLoseImage != null) youLoseImage.SetActive(false);
    }

    
    private int GetBarsToShow(int value)
    {
        if (value < 20) return 0;
        else if (value < 40) return 1;
        else if (value < 60) return 2;
        else if (value < 80) return 3;
        else if (value < 100) return 4;
        else return 5;
    }

    
    private void ShowBars(int barsToShow)
    {
        for (int i = 0; i < barsToShow && i < potionBars.Length; i++)
        {
            potionBars[i].SetActive(true); 
        }
    }

        private IEnumerator ShowOutcomeAfterDelay(int totalPotionEffect, float delay)
    {
        yield return new WaitForSeconds(delay); 
        if (totalPotionEffect >= 100)
        {
            Debug.Log("You Won!");
            if (youWonImage != null) youWonImage.SetActive(true);
        }
        else
        {
            Debug.Log("You Lose!");
            if (youLoseImage != null) youLoseImage.SetActive(true);
        }
    }
}
