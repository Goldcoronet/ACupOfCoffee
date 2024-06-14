using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;
    private Animator ani;
    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        pickUpText.gameObject.SetActive(false);
        ani.SetBool("IsDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("henry"))
        {
            pickUpText.gameObject.SetActive(true);
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("henry"))
        {
            pickUpText.gameObject.SetActive(false);
           ;
        }
    }
    public void changeboss(bool die)
    {
        if (ani != null)
        {

            if (die == true)
            {

                ani.SetBool("IsDead", true);
            }
            else
            {

                ani.SetBool("IsDead", false);
            }
        }
        else
        {
            Debug.LogError("Animator component not found on the 'henry' GameObject.");
        }
    }
}
