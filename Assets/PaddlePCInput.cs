using UnityEngine;

public class PaddlePCInput : MonoBehaviour
{
    [SerializeField] float maxBounceAngle = 75f;


    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;

    private bool mouseIsPressed;
    private Vector3 racketStartPos;
    private float onClickX;
    private float mouseDeltaX;

    private float minPos;
    private float maxPos;

    // Start is called before the first frame update
    void Start()
    {
        minPos = leftBorder.position.x + transform.lossyScale.x / 2 + leftBorder.lossyScale.x / 2;
        maxPos = rightBorder.position.x - transform.lossyScale.x / 2 - leftBorder.lossyScale.x / 2;
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Rigidbody2D ballRB = other.gameObject.GetComponent<Rigidbody2D>();

        // float racketWith = transform.lossyScale.x / 2;

        // float racketPosX = transform.position.x;
        // float ballPosX = other.transform.position.x;
        // if (ballPosX < racketPosX)
        // {
        //     float diff = racketPosX - ballPosX;
        //     ballRB.velocity = new Vector2(-10 * diff/racketWith,ballRB.velocity.y);
        // }
        // else if (ballPosX > racketPosX)
        // {
        //     float diff = ballPosX - racketPosX;
        //     ballRB.velocity = new Vector2(10 * diff/racketWith,ballRB.velocity.y);
        // }

        Ball ball = coll.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();

            Vector3 paddlePos = this.transform.position;
            Vector2 contactPoint = coll.GetContact(0).point;

            float offset = paddlePos.x - contactPoint.x;
            float width = coll.otherCollider.bounds.size.x / (2 * coll.transform.lossyScale.x);
            Debug.Log(width);

            float currAngle = Vector2.SignedAngle(Vector2.up, ballRb.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ballRb.velocity = rotation * Vector2.up * ballRb.velocity.magnitude;;
        }
    }


}