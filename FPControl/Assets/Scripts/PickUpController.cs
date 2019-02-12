using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public float speed;
    private int direction;
    private float moveTime;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        moveTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveTime += Time.deltaTime;
        int seconds = Mathf.RoundToInt(moveTime % 60f);
        if (seconds < 7) {
            transform.Translate(direction * Vector3.forward * speed * Time.deltaTime);
        }
        else {
            moveTime = 0f;
            direction = direction * -1;
        }
        
    }
}
