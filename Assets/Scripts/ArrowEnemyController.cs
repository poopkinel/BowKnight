using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ArrowEnemyController : MonoBehaviour
{
    float arrowThrust = 700f;
    float dir;
    public Transform parentTransform;

    void Awake()
    {
        Rigidbody2D arrowRB = gameObject.GetComponent<Rigidbody2D>();
        parentTransform = gameObject.transform.parent.parent;
        Debug.Log("SCALE:" + parentTransform.localScale.x.ToString());
        if (parentTransform.localScale.x > 0)
        {
            dir = -1f;
        }
        else if (parentTransform.localScale.x < 0)
        {
            dir = 1f;
        }
        transform.parent = null;
        arrowRB.AddForce(new Vector2(dir * arrowThrust, 0f));
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
