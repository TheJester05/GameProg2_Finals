using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
        if (clickSound == null)
    {
        Debug.LogError("No AudioClip assigned to ButtonSound script on " + gameObject.name);
        return;
    }
    audioSource.PlayOneShot(clickSound);
    }
}
