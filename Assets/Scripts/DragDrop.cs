using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject particles; // Reference to the particle system GameObject

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 mousePos;
    private ParticleSystem myParticleSystem;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
        // Get the ParticleSystem component attached to the particles GameObject
        myParticleSystem = particles.GetComponent<ParticleSystem>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        // Start the particle system when the drag begins
        if (myParticleSystem != null && !myParticleSystem.isPlaying)
        {
            myParticleSystem.Play();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        // Update mouse position during drag
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector2(mousePos.x, mousePos.y); // Ensure it's 2D

        // Keep the particles following the mouse position
        particles.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
        
        // Move the dragged item (potion) with the mouse
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Stop the particle system when the drag ends
        if (myParticleSystem != null && myParticleSystem.isPlaying)
        {
            myParticleSystem.Stop();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
