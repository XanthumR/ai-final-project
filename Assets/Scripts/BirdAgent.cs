using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class BirdAgent : Agent
{
    public Rigidbody2D rg;
    public Pipe_Manager nextPipe;
    private Vector3 startPos;
    private float flapStrength = 6f;
    public List<Pipe_Manager> pipes;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI previousScoreUI;
    int score = 0;
    int previousScore = 0;

    public override void Initialize()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        RaycastHit2D pipe = Physics2D.Raycast(new Vector2(startPos.x -0.2f, startPos.y- 3.42f), Vector2.right);
        Debug.DrawRay(new Vector2(startPos.x -0.2f, startPos.y - 3.42f), Vector2.right, Color.green);


        if (pipe.transform.name == "pipeBody")
        {
            nextPipe = pipe.transform.parent.parent.GetComponent<Pipe_Manager>();
        }

    }

    public override void OnEpisodeBegin()
    {
        transform.position = startPos;
        rg.linearVelocity = Vector2.zero;
        previousScoreUI.SetText("Previous Score Score " + previousScore);
        Debug.Log("episode begun");

        foreach (Pipe_Manager pipe in pipes)
        {
            pipe.ResetPipe();
        }

    }


    public override void CollectObservations(VectorSensor sensor)
    {
        // Observations:
        sensor.AddObservation(transform.position.y); // Bird's height
        sensor.AddObservation(rg.linearVelocity.y);        // Bird's vertical velocity
        sensor.AddObservation(nextPipe.transform.position.x - transform.position.x); // Pipe horizontal distance
        sensor.AddObservation(nextPipe.top_pipe.position.y - transform.position.y);
        sensor.AddObservation(nextPipe.bottom_pipe.position.y - transform.position.y);
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        int flap = actions.DiscreteActions[0];
        if (flap == 1)
        {
            rg.linearVelocity = new Vector2(0f, flapStrength);
        }

        // Reward for staying alive
        AddReward(0.01f);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        
        discreteActions[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetReward(-1f);
        previousScore = score;
        score = 0;
        scoreUI.SetText("Score " + score);

        EndEpisode();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AddReward(1f); // Passed a pipe
        score++;
        scoreUI.SetText("Score "+score);
    }
}
