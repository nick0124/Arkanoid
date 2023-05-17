using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]private BlocksController blocksController;

    private bool isStarted;
    public Transform ballSpawnPos;

    [SerializeField]private float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //StartImpulse();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && isStarted == false){
            isStarted = true;
            StartImpulse();
        }
    }

    private void FixedUpdate()
    {
        if (isStarted == false)
            transform.position = ballSpawnPos.position;
    }

    private void StartImpulse()
    {
        Vector2 force = new Vector2(Random.Range(-1f,1f),-1);
        rb.AddForce(force.normalized * speed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Floor"){
            Destroy(gameObject);
            Debug.Log("failure");
            //отнимаем жизнь
            //проверяем количество жизней, если меньше нуля проигрыш
        }

        if(other.transform.tag == "Block"){
            //прибавляем множитель очков
            //прибавляем очки
            //проверяем прошли ли игру
        }

        if(other.transform.tag == "Racket"){
            //обнуляем
        }
    }
}
