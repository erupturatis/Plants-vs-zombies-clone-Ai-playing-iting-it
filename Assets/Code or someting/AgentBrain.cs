using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AgentBrain : Agent
{
    public ScriptCentralizer Sc;
    public override void OnActionReceived(ActionBuffers actions)
    {
        //5 continous actions for planting on each lane + 1 for doing nothing
        int chosen = 0;
        float mx = -100000;
        for(int i = 0; i <= 5; i++)
        {
            //Debug.Log(actions.ContinuousActions[i] + " I:" + i);
            if (actions.ContinuousActions[i]>mx)
            {
                mx = actions.ContinuousActions[i];
                chosen = i;
            }
        }
        //print(chosen + "CHOSEEEEEEEEEEEEEEEEEEEEEEEEN");
        if (chosen != 5)
        {
            
            Sc.PlantOnlane(chosen);
        }

    }
    public override void CollectObservations(VectorSensor sensor)
    {
        //10 observations,  5 - number of zombies on each lane, and what is the closest zombie to the house on each lane
        int[] Lanes = Sc.GetNrZombie();
        sensor.AddObservation(Lanes[0]);
        sensor.AddObservation(Lanes[1]);
        sensor.AddObservation(Lanes[2]);
        sensor.AddObservation(Lanes[3]);
        sensor.AddObservation(Lanes[4]);
        //print(Lanes[0] + " " + Lanes[1] + " " + Lanes[2] + " " + Lanes[3] + " " + Lanes[4]);
        sensor.AddObservation(Sc.Suns);
    }

    public override void OnEpisodeBegin()
    {
        //plants cleared
        //zombies cleared
        Sc.Wm.DestroyAll = 0;
        Sc.ST.SpawnTiless();
        //Time.timeScale = 3;
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //no need right now for this


    }
}
