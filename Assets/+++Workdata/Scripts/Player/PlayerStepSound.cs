using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class PlayerStepSound : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raycastDistance = 0.2f;
    [SerializeField] private Vector3 raycastPosition;

    [SerializeField] private AudioSource audioSource;

    [Header("Walk Sounds")] 
    [SerializeField] private AudioClip grassWalkStepSound;
    [SerializeField] private AudioClip mudWalkStepSound;
    [SerializeField] private AudioClip woodWalkStepSound;
    [SerializeField] private AudioClip defaultWalkStepSound;
    
    public void PlayWalkStepSound()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastPosition,
            UnityEngine.Vector2.down, raycastDistance, groundLayer);

        if (hit.collider != null)
        {
            string groundTag = hit.collider.gameObject.tag;

            switch (groundTag)
            {
                case "Grass":
                    PlayRandomSound(grassWalkStepSound);
                    break;
                
                case "Mud":
                    PlayRandomSound(mudWalkStepSound);
                    break;
                
                case "Wood":
                    PlayRandomSound(woodWalkStepSound);
                    break;
                
                default:
                    PlayRandomSound(defaultWalkStepSound);
                    break;
                
            }
        }
    }

    void PlayRandomSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
