using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    Transform playerTransform;
    float arrowThrust;
    float dir;
    Rigidbody2D arrowRB;


    void Awake()
    {
        arrowThrust = 1000f;

        playerTransform = GameObject.Find("Player").transform;
        arrowRB = gameObject.GetComponent<Rigidbody2D>();

        if (playerTransform.localScale.x > 0)
        {
            dir = 1f;
        }
        else if (playerTransform.localScale.x < 0)
        {
            dir = -1f;
        }
        arrowRB.AddForce(new Vector2(dir * arrowThrust, 0f));
        Debug.Log("after AddForce");
    }

    void Start()
    {
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
