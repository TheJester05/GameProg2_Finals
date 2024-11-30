using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    private GameObject particles; 
    private ParticleSystem myParticleSystem; 
    private Vector2 mousePos;

    [SerializeField]
    private float particlesPerSecond = 10f; 

    private void Start()
    {
        
        myParticleSystem = particles.GetComponent<ParticleSystem>();

        if (myParticleSystem != null)
        {
            myParticleSystem.Stop(); 
        }
        else
        {
            particles.SetActive(false); 
        }

        
        var main = myParticleSystem.main;
        main.gravityModifier = 1f; 
        main.simulationSpace = ParticleSystemSimulationSpace.World; 

       
        var emissionModule = myParticleSystem.emission;
        emissionModule.rateOverTime = particlesPerSecond; 
    }

    private void Update()
    {
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector2(mousePos.x, mousePos.y); 

       
        if (Input.GetMouseButtonDown(0))
        {
            particles.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);

            
            if (!myParticleSystem.isPlaying)
            {
                myParticleSystem.Play();
            }
        }

        
        if (Input.GetMouseButton(0))
        {
            particles.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);

            
            if (!myParticleSystem.isPlaying)
            {
                myParticleSystem.Play();
            }
        }

        
        if (Input.GetMouseButtonUp(0))
        {
            
            if (myParticleSystem.isPlaying)
            {
                myParticleSystem.Stop();
            }
        }
    }
}
