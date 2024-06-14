using UnityEngine;
using UnityEngine.UI;

public class wall : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;

    [SerializeField]
    private float interactionDistance = 2f; // Adjust the distance as needed

    private GameObject player; // Reference to the player

    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
        player = GameObject.Find("henry"); // Assuming "henry" is the name of your player object

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player object has the correct name.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            Debug.Log("Distance: " + distance);

            if (distance <= interactionDistance)
            {
                pickUpText.gameObject.SetActive(true);
                // Add additional logic for interaction if needed
            }
            else
            {
                pickUpText.gameObject.SetActive(false);
                // Add additional logic for when the player is out of range
            }
        }
    }
}


