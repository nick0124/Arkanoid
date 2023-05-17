using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    public int blocks;

    // Start is called before the first frame update
    void Start()
    {
        blocks = gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateBlocksCount()
    {
        blocks--;
        if (blocks == 0)
        {
            Debug.Log("Win level");
        }
    }
}
