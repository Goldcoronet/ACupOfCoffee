using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void wee(bool hee)
    {

        if (hee == true)
        {
            Invoke("ChangeScene", 2.3f);
        }
    }
    private void ChangeScene()
    {
        // Log to console to check if the method is called
        Debug.Log("Changing scene to 'Ending'");

        // Load your new scene here
        SceneManager.LoadScene("Ending");
    }
}
