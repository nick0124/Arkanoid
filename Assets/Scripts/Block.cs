using UnityEngine;

public class Block : MonoBehaviour
{
    enum Bonus
    {
        None,
        Life,
        RacketSize,
        ExtraBall,
        Slowmonion,
        Speedup,
        CatchBall,
        BigBall,
        Smallball
    }
    [SerializeField]private Bonus bonus;

    [SerializeField]private BlocksController blocksController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    private void OnDestroy() {
        blocksController.UpdateBlocksCount();
    }
}
