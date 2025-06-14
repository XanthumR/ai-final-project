using System;
using UnityEngine;

public class Pipe_Manager : MonoBehaviour
{
    float startPosX;
    float startPosY;
    public Transform bottom_pipe;
    public Transform top_pipe;
    public Transform reset_location;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosX = transform.position.x; ;
        startPosY = transform.position.y;
        transform.position = new Vector2(startPosX, startPosY+UnityEngine.Random.Range(-0.5f, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x-3*Time.deltaTime, transform.position.y);

        if (transform.position.x < reset_location.position.x - 26f)
        {
            transform.position = new Vector2(reset_location.position.x, startPosY + UnityEngine.Random.Range(-0.5f, 2f));
        }
    }

    public void ResetPipe()
    {
        transform.position = new Vector2(startPosX, startPosY + UnityEngine.Random.Range(-0.5f, 2f));
    }


}
