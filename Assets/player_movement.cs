using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;
    private AudioSource footstepAudio;
    public Transform LaunchOffset;
    public AudioClip walkingSound; // Expose a serialized field for the walking sound
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private GameObject ProjectilePrefab; // Reference to the projectile prefab

    private bool isInBossCollider = false; // Flag to track if player is inside the boss's collider

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        // Add AudioSource component and set it up
        footstepAudio = gameObject.AddComponent<AudioSource>();
        footstepAudio.clip = walkingSound; // Assign the audio clip from the Inspector
        footstepAudio.loop = true; // If your walking sound is short and should loop, set this to true
        footstepAudio.playOnAwake = false;

        anim.SetBool("Hassm", false);
        anim.SetBool("t", false);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Invert the horizontal input
        horizontalInput = -horizontalInput;

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // Update player position
        transform.Translate(movement);

        // Check if any movement keys are pressed
        bool isMoving = Mathf.Abs(horizontalInput) > 0f || Mathf.Abs(verticalInput) > 0f;

        // Set walking animation based on key input
        anim.SetBool("IsWalking", isMoving);

        // Play walking sound if moving
        if (isMoving)
        {
            PlayFootstepSound();
            // Flip the sprite based on the direction of movement
            spriteRenderer.flipX = horizontalInput < 0f; // Flip if moving left
        }
        else
        {
            // Stop the walking sound if not moving
            footstepAudio.Stop();
        }

        if (Input.GetKeyDown(KeyCode.F) && isInBossCollider)
        {
            float delay = 0.3f;
            Invoke("ThrowProjectile", delay);
            anim.SetBool("t", true);
        }
    }

    void PlayFootstepSound()
    {
        if (!footstepAudio.isPlaying)
        {
            footstepAudio.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossCollider"))
        {
            isInBossCollider = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossCollider"))
        {
            isInBossCollider = false;
        }
    }

    public void ChangeAnimations(bool hascup)
    {
        if (anim != null)
        {
           
            if (hascup == true)
            {
               
                anim.SetBool("Hassm", true);
            }
            else
            {
               
                anim.SetBool("Hassm", false);
            }
        }
        else
        {
            Debug.LogError("Animator component not found on the 'henry' GameObject.");
        }
    }
    void ThrowProjectile()
    {
        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
    }
}
