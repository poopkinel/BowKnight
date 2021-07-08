using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float speed;
    float jumpThrust;
    Rigidbody2D rb;
    bool isGrounded;

    
    // Shooting
    public Transform bowPosition;
    public GameObject arrowPrefab;

    Vector3 arrowRotation;

    void Start()
    {
        speed = 0.02f;
        jumpThrust = 380f;

        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;

        arrowRotation = transform.rotation.eulerAngles;
        arrowRotation.z += 90;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.UpArrow) & isGrounded)
        {
            rb.AddForce(transform.up * jumpThrust);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space key down");
            Instantiate(arrowPrefab, bowPosition.position, Quaternion.Euler(arrowRotation));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("inside collision enter");
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Inside collision enemy tag");
            //Debug.Log("name: " + collision.gameObject.name);
            if (collision.gameObject.name == "Head")
            {
                //Debug.Log("inside collision head");
                isGrounded = true;
                Destroy(collision.gameObject.transform.parent.gameObject);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }
    }
}
