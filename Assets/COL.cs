using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;  // Drag and drop your music file here in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component if it doesn't exist
        audioSource = gameObject.AddComponent<AudioSource>();

        // Assign the audio clip
        audioSource.clip = musicClip;

        // Set loop to true so the music keeps playing
        audioSource.loop = true;

        // Play the music
        audioSource.Play();
    }
}