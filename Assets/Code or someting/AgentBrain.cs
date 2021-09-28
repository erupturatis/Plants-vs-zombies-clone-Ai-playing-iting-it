using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AgentBrain : Agent
{
    public ScriptCentralizer Sc;
    int x = 0;
    public override void OnActionReceived(ActionBuffers actions)
    {
        //5 continous actions for planting on each lane + 1 for doing nothing

        int chosen = actions.DiscreteActions[0];
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
        float[] Closest = Sc.GetClosestZombies();
        int[] Plants = Sc.GetPlantsOnLane();
        float distance = 0;
        int plt = 0;
        for(int i = 0; i <= 4; i++)
        {
            if (Closest[i] > distance)
            {
                distance = Closest[i];
                plt = i;
            }
        }

        sensor.AddObservation(plt);
        Sc.closestZombieLane = plt;

        sensor.AddObservation(Plants[0]);
        sensor.AddObservation(Plants[1]);
        sensor.AddObservation(Plants[2]);
        sensor.AddObservation(Plants[3]);
        sensor.AddObservation(Plants[4]);

        sensor.AddObservation(Lanes[0]);
        sensor.AddObservation(Lanes[1]);
        sensor.AddObservation(Lanes[2]);
        sensor.AddObservation(Lanes[3]);
        sensor.AddObservation(Lanes[4]);

        sensor.AddObservation(Closest[0]);
        sensor.AddObservation(Closest[1]);
        sensor.AddObservation(Closest[2]);
        sensor.AddObservation(Closest[3]);
        sensor.AddObservation(Closest[4]);
        //print(Plants[0] + " " + Plants[1] + " " + Plants[2] + " " + Plants[3] + " " + Plants[4] + "PLANTS");
        //print(Lanes[0] + " " + Lanes[1] + " " + Lanes[2] + " " + Lanes[3] + " " + Lanes[4] + "LANES");
        //print(Closest[0] + " " + Closest[1] + " " + Closest[2] + " " + Closest[3] + " " + Closest[4] + "Close");
        sensor.AddObservation(Sc.Suns);


    }

    public override void OnEpisodeBegin()
    {
        //plants cleared
        //zombies cleared
        if (x != 0)
        {
            Sc.Hakai();
        }
        //print(x);
        x++;
        Sc.Wm.DestroyAll = 0;
        Sc.ST.SpawnTiless();
        Time.timeScale = 2;
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //no need right now for this


    }
}
