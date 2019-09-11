using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -15f;
    private Renderer rend;
    private ParticleSystem exp;


    // Update is called once per frame
    void Update()
    {
     if(transform.position.y < bottomY)
        {
            

            rend = GetComponent<Renderer>();
            rend.enabled = false;
            Explode();


            // Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call the public AppleDestroyed method of apScript
            apScript.AppleDestroyed();
        }   
    }

    void Explode()
    {
        exp = GetComponent<ParticleSystem>();
        //  play particle system
        if (!exp.isPlaying)
        {
            exp.Play();
            
        }

        // TODO wait to return until particle system is done playing??
        
    }
}
