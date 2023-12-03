using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour


   
{
    public GameObject applePrefab;

    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeToChangeDirections = 0.1f;
    public float secondBetweenAppleDrops = 1f;

    // Start drop apple
    void Start()
    {

        Invoke("DropApple", 2);
    }

    private void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = this.transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
        
    }

    // Move AppleTree
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime; //add to time for not prossesor
                                         //Time.deltaTime for all computer eqiul
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);

        }       

    }
    private void FixedUpdate()
    {
        if (Random.value < changeToChangeDirections)
        {
            speed *= -1;
        }

    }
}
