using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed;                     //Store values from Unity

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, speed);        //Initialize vertical speed
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);               //Destroy upon leaving camera
    }

    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);               //Destroy upon contact
    }
}
