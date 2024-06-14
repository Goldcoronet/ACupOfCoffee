using UnityEngine;
using UnityEngine.SceneManagement;
public class Projectile : MonoBehaviour
{
    public float speed = 4.5f;
    [SerializeField]
    private GameObject bossGameObject;
    [SerializeField]
    private GameObject sceneGameObject;
    [SerializeField]
    private AudioClip hitSound;  // Assign the hit sound in the Unity editor
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();
        // Ensure the AudioClip is assigned in the Unity editor
        if (audioSource != null && hitSound != null)
        {
            // Set the AudioClip for the AudioSource
            audioSource.clip = hitSound;
        }
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Hitbox"))
        {
            // Handle hit logic here
            EnableGravity();
            // Play the hit sound and then destroy the projectile
            PlayHitSoundAndDestroy();
            NotifyBoss();
            NotifyScene();
            StartCoroutine(DelayedSceneChange(2f));
        }
    }

    private void PlayHitSoundAndDestroy()
    {
        // Check if AudioSource and AudioClip are assigned
        if (audioSource != null && hitSound != null)
        {
            // Play the hit sound
            audioSource.Play();
            // Wait for the duration of the sound before destroying the projectile
            Destroy(gameObject, hitSound.length);
        }
        else
        {
            // If audioSource or hitSound is not assigned, destroy the projectile with a default delay
            Destroy(gameObject, 0.3f);
        }
    }


    private System.Collections.IEnumerator DestroyAfterSound(float delay)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delay);
        // Destroy the projectile
        Destroy(gameObject);
    }

    private void NotifyBoss()
    {
        // Your existing code for notifying the boss
        if (bossGameObject != null)
        {
            boss henryController = bossGameObject.GetComponent<boss>();

            if (henryController != null)
            {
                henryController.changeboss(true);
            }
            else
            {
                Debug.LogWarning("Boss script not found on bossGameObject.");
            }
        }
        else
        {
            Debug.LogWarning("bossGameObject is not assigned.");
        }
    }
    private void EnableGravity()
    {
        // Find the GravityManager in the scene
        Gravity gravityManager = FindObjectOfType<Gravity>();

        // If the GravityManager is found, enable gravity for this object
        if (gravityManager != null)
        {
            gravityManager.EnableGravity(gameObject);
        }
    }
    private void ChangeScene()
    {
        Debug.Log("Changing scene to 'Ending'");
        // Load your new scene here
        SceneManager.LoadScene("Ending");
    }
    private System.Collections.IEnumerator DelayedSceneChange(float delay)
    {
        // Wait for the specified duration before changing the scene
        yield return new WaitForSeconds(delay);
        ChangeScene();
    }
    private void NotifyScene()
    {
        // Your existing code for notifying the boss
        if (sceneGameObject != null)
        {
            scene SController = sceneGameObject.GetComponent<scene>();

            if (SController != null)
            {
                SController.wee(true);
            }
            else
            {
                Debug.LogWarning("Boss script not found on bossGameObject.");
            }
        }
        else
        {
            Debug.LogWarning("bossGameObject is not assigned.");
        }
    }
}
