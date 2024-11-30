using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Cauldron : MonoBehaviour, IDropHandler
{
    [SerializeField] private AudioClip dropInCauldronSound;
    [SerializeField] private string nextSceneName;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            Debug.LogError("Dragged object is null.");
            return;
        }

        Potion potion = eventData.pointerDrag.GetComponent<Potion>();
        if (potion == null)
        {
            Debug.LogError("No Potion script attached to dragged object.");
            return;
        }

        if (!PlayerPrefs.HasKey("PotionValue"))
        {
            PlayerPrefs.SetInt("PotionValue", potion.potionValue);
            PlayerPrefs.Save();
            Debug.Log($"Potion Value Added: {potion.potionValue}");
        }

        RectTransform potionTransform = eventData.pointerDrag.GetComponent<RectTransform>();
        potionTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

        
        if (audioSource != null && dropInCauldronSound != null)
        {
            audioSource.PlayOneShot(dropInCauldronSound);
            Debug.Log("Playing cauldron sound...");
            StartCoroutine(LoadSceneAfterSound());
        }
        else
        {
            Debug.LogError("AudioSource or dropInCauldronSound is missing!");
            
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private System.Collections.IEnumerator LoadSceneAfterSound()
    {
        
        yield return new WaitForSeconds(dropInCauldronSound.length);
        SceneManager.LoadScene(nextSceneName);
    }
}
