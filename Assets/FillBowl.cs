using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBowl : MonoBehaviour
{
    public GameObject[] stages;
    private int amtFilled;
    private int maxFill;
    public ParticleSystem water;
    void Start()
    {
        amtFilled = 0;
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].SetActive(false);
        }
        maxFill = stages.Length * 5;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.name == "Water")
        {
            amtFilled++;
        }
    }

    private void Update()
    {
        //needs a specific format for the naming of the stages of being filled
        for (int i = 0; i < stages.Length; i++)
        {
            if (amtFilled >= Convert.ToInt32(stages[i].name.Substring(stages[i].name.Length - 3)) * 5)
            {
                stages[i].SetActive(true);
            }
            else
            {
                stages[i].SetActive(false);
            }
        }

        if (amtFilled > maxFill)
        {
            amtFilled = maxFill;
        }
    }

    public int getAmtFilled()
    {
        return amtFilled;
    }

    public int getMaxFill()
    {
        return maxFill;
    }
}
