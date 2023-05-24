using UnityEngine;

public class RacketMobileInput : MonoBehaviour
{
    [SerializeField]
    private Transform leftBorder;
    [SerializeField]
    private Transform rightBorder;

    private bool mouseIsPressed;
    private Vector3 racketStartPos;
    private float onClickX;
    private float mouseDeltaX;

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
        if(Input.GetMouseButtonDown(0)){
            onClickX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            racketStartPos = transform.position;
            mouseIsPressed = true;
        }
        if(Input.GetMouseButtonUp(0)){
            mouseIsPressed = false;
        }
    }

    void FixedUpdate()
    {
        if(mouseIsPressed){
            float mouseWorldPosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            mouseDeltaX = onClickX - mouseWorldPosX;
            transform.position = racketStartPos + new Vector3(-mouseDeltaX, 0, 0);
        }
        if (transform.position.x < minPos) transform.position = new Vector3(minPos, transform.position.y, 0);
        if (transform.position.x > maxPos) transform.position = new Vector3(maxPos, transform.position.y, 0);
    }
}