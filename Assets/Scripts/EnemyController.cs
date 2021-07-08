using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Shooting
    public Transform startPosition;
    public GameObject arrowEnemyPrefab;

    private float timer = 0.0f;
    private float waitTime = 2.0f;
    

    // Movement
    Transform playerTransform;
    Vector3 dirOfPlayer;
    float movementSpeed = 3f;
    bool playerInVision; // TODO

    void Start()
    {
        playerInVision = true;
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            GameObject arrow = Instantiate(arrowEnemyPrefab, startPosition);
            timer = timer - waitTime;
        }

        if (playerInVision)
        {
            dirOfPlayer = playerTransform.transform.position - transform.position;
            dirOfPlayer = dirOfPlayer.normalized;
            //Debug.Log("dirOfPlayer.x:" + dirOfPlayer.x.ToString());
            if (dirOfPlayer.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                //Debug.Log(transform.localScale.x);
            }
            else if (dirOfPlayer.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                //Debug.Log(transform.localScale.x);

            }

            transform.Translate(movementSpeed * Time.deltaTime * dirOfPlayer, Camera.main.transform);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
