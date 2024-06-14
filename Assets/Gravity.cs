using UnityEngine;

public class Gravity : MonoBehaviour
{
    // List of game objects affected by gravity
    public GameObject[] objectsToAffect;

    private void Start()
    {
        Debug.Log("Gravity script started.");

        // Disable gravity for all objects in the array initially
        foreach (var obj in objectsToAffect)
        {
            DisableGravity(obj);
        }
    }


    public void EnableGravity(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Trying to enable gravity on a null object.");
            return;
        }

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1f;
            Debug.Log("Gravity enabled for: " + obj.name);
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the object: " + obj.name);
        }
    }

    public void DisableGravity(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Trying to disable gravity on a null object.");
            return;
        }

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            Debug.Log("Gravity disabled for: " + obj.name);
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on the object: " + obj.name);
        }
    }
}