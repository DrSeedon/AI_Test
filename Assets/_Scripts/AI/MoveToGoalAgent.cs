using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Random = UnityEngine.Random;

public class MoveToGoalAgent : Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;
    [SerializeField] private SpawnPoint2D spawnPointAgent;
    [SerializeField] private SpawnPoint2D spawnPointGoal;
    [SerializeField] private List<Goal> goals;

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(spawnPointAgent.GetRandomSpawnPoint().x, 0, 
            spawnPointAgent.GetRandomSpawnPoint().z);
        //targetTransform.position = new Vector3(spawnPointGoal.GetRandomSpawnPoint().x, 0, spawnPointGoal.GetRandomSpawnPoint().z);
        foreach (var item in goals)
        {
            item.gameObject.SetActive(true);
        }
    }
    

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        //sensor.AddObservation(targetTransform.localPosition);
    }
    
    public override void OnActionReceived(ActionBuffers action)
    {
        float moveX = action.ContinuousActions[0];
        float moveZ = action.ContinuousActions[1];

        float moveSpeed = 5f;
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(goal.Reward);
            floorMeshRenderer.material = winMaterial;
            goal.gameObject.SetActive(false);
            if(!goal.isSubGoal)
                EndEpisode();
        }
        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
    }
}
