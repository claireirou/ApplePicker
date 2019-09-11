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
            // Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            rend = GetComponent<Renderer>();
            exp = GetComponent<ParticleSystem>();

            // Play particle system
            if (!exp.isPlaying)
            {
                // There is no particle system playing

                if (rend.enabled)
                {
                    // This is the first frame this apple is at bottomY
                    rend.enabled = false;
                } else
                {
                    // Particle system is done playing, destroy apple.
                    Destroy(this);
                }

                exp.Play();

                // Call the public AppleDestroyed method of apScript
                apScript.AppleDestroyed();
            }
              
        }   
    }
}
