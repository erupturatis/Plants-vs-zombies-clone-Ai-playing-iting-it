using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NeuralNetwork
{
    public float[,,] weights;
    public float[] Biases;
    public int HiddenLayers;
    public int HiddenLayerSize;
    public int NetworkNum;

    public NeuralNetwork(int HiddenLayersI, int HiddenLayerSizeI, int Num)
    {
        NetworkNum = Num;
        weights = new float[7, 46, 46];

        HiddenLayerSize = HiddenLayerSizeI;
        HiddenLayers = HiddenLayersI;
        Biases = new float[11];


    }
    public void SetW(float[,,] WeightsI)
    {
        for (int i = 0; i <= 6; i++)
        {
            for (int j = 0; j <= 45; j++)
            {
                for (int t = 0; t <= 45; t++)
                {
                    weights[i, j, t] = WeightsI[i, j, t];
                }
            }
        }
    }
    public void SetB(float[] BiasesI)
    {
        for (int i = 0; i <= 6; i++)
        {
            Biases[i] = BiasesI[i];
        }
    }
    public int Run(float[] TileZ)
    {
        float[,] WeightsNow = new float[46, 46];

        float[] SumsPrevious = new float[50];
        float[] SumsCalculated = new float[50]; //The neural network shouldn't have layers bigger than 50 in height
        float Sum = 0;
        int Input = 0;
        int Output = 0;
        //Input -> Output
        for (int p = 0; p <= HiddenLayers; p++)
        {
            for (int i = 0; i <= 45; i++)
            {
                for (int j = 0; j <= 45; j++)
                {
                    WeightsNow[i, j] = weights[p, i, j];
                }
            }
            //Input is the input of the layer we are currently calculating
            //Output is the output of the layer we are calculating 
            if (p == 0)
            {
                Input = 45;
            }
            else
            {
                Input = HiddenLayerSize;
            }
            if (p == HiddenLayers)
            {
                Output = 45;
                //the first 45 output layers wwill represend the tiles
                //while the last neuron will mean do nothing
            }
            else
            {
                Output = HiddenLayerSize;
            }
            if (p == 0)
            {
                for (int i = 0; i < HiddenLayerSize; i++)
                {
                    //initial Calculation 
                    Sum = 0;
                    for (int j = 0; j <= Input; j++)
                    {
                        Sum += WeightsNow[j, i] * TileZ[j];
                    }
                    Sum += Biases[p];
                    Sum = Relu(Sum);
                    SumsCalculated[i] = Sum;
                }
                //Debug.Log(WeightsNow[0, 0] + "  SUM     " + NetworkNum);
            }
            else if (p == HiddenLayers)
            {


                for (int i = 0; i < Output; i++)
                {
                    //Final Calculation Calculation for the hidden Layers
                    Sum = 0;
                    for (int j = 0; j <= Input; j++)
                    {
                        Sum += WeightsNow[j, i] * SumsPrevious[j];
                    }
                    Sum += Biases[p];
                    Sum = Sigmoid(Sum);
                    SumsCalculated[i] = Sum;
                }

            }
            else
            {
                for (int i = 0; i < HiddenLayerSize; i++)
                {
                    //General Calculation for the hidden Layers
                    Sum = 0;
                    for (int j = 0; j <= Input; j++)
                    {
                        Sum += WeightsNow[j, i] * SumsPrevious[j];
                    }
                    Sum += Biases[p];
                    Sum = Relu(Sum);
                    SumsCalculated[i] = Sum;
                }
            }
            SumsPrevious = SumsCalculated;
            if (p == HiddenLayers)
            {
                float mx = 0;
                int chosen = 0;
                //Debug.Log("CALCULATED" + SumsCalculated[0] + " " + SumsCalculated[10] + " " + SumsCalculated[20]);
                for(int i = 0; i < Output; i++)
                {
                    //take the best tile to plant on
                    if (SumsCalculated[i] > mx)
                    {
                        mx = SumsCalculated[i];
                        chosen = i;
                    }
                }
                //Debug.Log(chosen);
                //currently if it should plant or not
                return chosen;
            }

        }
        return 1;
    }

    public float Relu(float x)
    {
        if (x > 0)
        {
            return x;
        }
        else
        {
            return 0;
        }
    }

    public static float Sigmoid(double value)
    {
        return 1.0f / (1.0f + (float)Math.Exp(-value));
    }


}
