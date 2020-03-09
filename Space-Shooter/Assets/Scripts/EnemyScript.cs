using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;             //Store values from Unity 
    public float Cooldown;
    public float xMin;
    public float xMax;
    private float direction = 0;
    private float nextTurnTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, -speed);          //initialize speed of enemy
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-200, 200);      //Initialize rotation speed to random value
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);            //Destroy upon leaving screen
    }

    private void FixedUpdate()
    {
        if (transform.position.x < xMin)            //Check if past left border of screen
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * speed, -speed);      //Move back onto play field
        }
        if (transform.position.x > xMax)            //Check if past right border of screen
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed, -speed);     //Move back onto play field
        }
    }

    void Update()
    {
        if (Time.time > nextTurnTime)               //Check if Cooldown (if any) has elapsed
        {
            direction = Random.Range(-1, 2);
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, -speed);
            nextTurnTime = Time.time + Cooldown;                //Disable turning until cooldown has passed
        }

    }

    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);            //Destroy upon making contact
    }
}
