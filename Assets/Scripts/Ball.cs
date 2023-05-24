using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager{set; private get;}
    private bool isStarted;


    [SerializeField]private float speed;
    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && this.isStarted == false){
            this.isStarted = true;
            StartImpulse();
        }
    }

    private void FixedUpdate()
    {

    }

    private void StartImpulse()
    {
        Vector2 force = new Vector2(Random.Range(-1f,1f),-1);
        rb.AddForce(force.normalized * speed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Floor"){
            Destroy(gameObject);
            this.gameManager.UpdateBallsCount();
            //проверяем количество мячей на экране, если меньше 0 отнимаем жизнь
            //отнимаем жизнь
            //проверяем количество жизней, если меньше нуля проигрыш
        }

        if(other.transform.tag == "Block"){
            this.gameManager.UpdateBlocksCount();
            //прибавляем множитель очков
            //прибавляем очки
            //проверяем прошли ли игру
        }

        if(other.transform.tag == "Racket"){
            //обнуляем
        }
    }
}
