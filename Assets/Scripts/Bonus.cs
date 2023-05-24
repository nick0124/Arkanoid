using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Type
{
    AdiitionalBall,
    IncreasePaddle,
    FlipScreen,
    DescreasePaddle,
    IncreaseLives,
    DescreaseLives,
    SpikesBall
}

public class Bonus : MonoBehaviour
{
    [SerializeField] private Type type;
    [SerializeField] private float speed;
    [SerializeField] private GameManager gameManager;
    private Rigidbody2D rb;

    //----бонусы-----

    //добавочный мяч

    //увеличение ракетки
    //уменьшение ракетки

    //Мяч с шипами

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(0, -1) * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position -= Vector3.up / 50;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Racket")
        {
            Destroy(gameObject);
            Debug.Log("Give bonus");
            switch (this.type)
            {
                case Type.AdiitionalBall:
                    Debug.Log("spawn ball");
                    break;
                case Type.SpikesBall:
                    Debug.Log("spawn ball");
                    break;
                case Type.FlipScreen:
                    Debug.Log("flip screen");
                    break;
                case Type.IncreasePaddle:
                    Debug.Log("increase paddle size for n sec");
                    break;
                case Type.DescreasePaddle:
                    Debug.Log("decrease paddle size for n sec");
                    break;
                case Type.IncreaseLives:
                    Debug.Log("decrease lives count");
                    break;
                case Type.DescreaseLives:
                    Debug.Log("decrease lives count");
                    break;
                default:
                    Debug.Log("error");
                    break;
            }
        }
    }
}
