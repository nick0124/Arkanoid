using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    [SerializeField]
    private Transform leftBorder;
    [SerializeField]
    private Transform rightBorder;

    private float minPos;
    private float maxPos;


    // Start is called before the first frame update
    void Start()
    {
        minPos = leftBorder.position.x + transform.lossyScale.x/2 + leftBorder.lossyScale.x/2;
        maxPos = rightBorder.position.x - transform.lossyScale.x/2 - leftBorder.lossyScale.x/2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float mouseWorldPosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if (mouseWorldPosX < minPos) mouseWorldPosX = minPos;
        if (mouseWorldPosX > maxPos) mouseWorldPosX = maxPos;
        transform.position = new Vector3(mouseWorldPosX, transform.position.y, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Rigidbody2D ballRB = other.gameObject.GetComponent<Rigidbody2D>();

        float racketWith = transform.lossyScale.x / 2;
        
        float racketPosX = transform.position.x;
        float ballPosX = other.transform.position.x;
        if (ballPosX < racketPosX)
        {
            float diff = racketPosX - ballPosX;
            ballRB.velocity = new Vector2(-10 * diff/racketWith,ballRB.velocity.y);
        }
        else if (ballPosX > racketPosX)
        {
            float diff = ballPosX - racketPosX;
            ballRB.velocity = new Vector2(10 * diff/racketWith,ballRB.velocity.y);
        }
    }
}
