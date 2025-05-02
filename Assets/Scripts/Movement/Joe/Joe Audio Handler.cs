using UnityEngine;
using System.Collections;
public class JoeAudioHandler : MonoBehaviour
{
    public AudioClip[] joeSounds; // Array of audio clips
    private AudioSource audioSource;
    public float timeBetweenSounds = 5f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundWithDelay());
    }

    void PlayRandomSound()
    {
        if (joeSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, joeSounds.Length); // Pick a random clip
            audioSource.Stop(); // Stop the previous clip (optional, but can help prevent overlap)
            audioSource.clip = joeSounds[randomIndex]; // Assign new clip
            audioSource.Play(); // Play the new clip
        }
    }
    IEnumerator PlaySoundWithDelay()
    {
        while (true) // Loop indefinitely
        {
            yield return new WaitForSeconds(timeBetweenSounds); // Wait specified time

            PlayRandomSound(); // Play a new sound
        }
    }
}

