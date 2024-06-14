using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class vhatscript : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    public float DialogueSpeed;
    public AudioClip revealSound;

    private int index = 0;
    private AudioSource audioSource;
    private bool soundPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("StartDialogue", 13f);
        Invoke("ClearTextAndSound", 20f); // Clear text and sound after 20 seconds
    }

    void StartDialogue()
    {
        StartCoroutine(WriteSentence());
    }

    void ClearTextAndSound()
    {
        DialogueText.text = "";
        audioSource.Stop(); // Stop the audio when clearing text
        soundPlayed = false; // Reset the flag
    }

    IEnumerator WriteSentence()
    {
        DialogueText.text = "";

        if (revealSound != null && !soundPlayed)
        {
            audioSource.PlayOneShot(revealSound);
            soundPlayed = true; // Set the flag to true after playing the sound
        }

        foreach (char character in Sentences[index].ToCharArray())
        {
            DialogueText.text += character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        index++;

        if (index < Sentences.Length)
        {
            Invoke("StartDialogue", 1f); // Start the next sentence after a delay
        }
        else
        {
            // Handle the end of the dialogue here
            Debug.Log("End of dialogue");
        }
    }
}
