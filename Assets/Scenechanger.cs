using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scenechanger : MonoBehaviour
{
    public float changetime;
    public string scenename;
   

    // Update is called once per frame
    private void Update()
    {
        changetime -= Time.deltaTime;
        if( changetime <= 0)
        {
            SceneManager.LoadScene(scenename);
        }
    }
}
