using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RecipeUpdater : MonoBehaviour
{

    public LoadScene other;
    public int forStep;
    private bool inMortar;
    private bool winMortar;
    private bool crushed;

    private void Awake()
    {
        //print(forStep);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check if Crushed
        if (collision.gameObject.name == "Pestle" && !crushed && forStep == 1)
        {
            crushed = true;
            if(other.getCurrentStep() == 1)
            {
                forStep = 2;
                other.increaseCurrent();
            }
        }

        //Check if in Mortar
        if(collision.gameObject.name == "Mortar")
        {
            inMortar = true;
            print(other.getCurrentStep());
            print(forStep);
            if(other.getCurrentStep() == 2 && forStep == 2 && !winMortar)
            {
                winMortar = true;
                other.increaseCurrent();
            }
        }
        else
        {
            try
            {
                if (collision.gameObject.GetComponent<RecipeUpdater>().getInMortar())
                {
                    if (other.getCurrentStep() == 2 && forStep == 2)
                    {
                        winMortar = true;
                        other.increaseCurrent();
                    }
                }
            }
            catch(NullReferenceException)
            {
                if (other.getCurrentStep() == 2 && winMortar)
                {
                    other.decreaseCurrent();
                }
                winMortar = false;
                inMortar = false;
            }
        }
    }

    public int getForStep()
    {
        return forStep;
    }
    public bool getCrushed()
    {
        return crushed;
    }

    public int getTeto()
    {
        return forStep;
    }
    public bool getInMortar()
    {
        return inMortar;
    }

    public void setForStep(int step)
    {
        forStep = step;
    }
    public void setCrushed(bool cry)
    {
        crushed = cry;
    }
    public void setTeto(int teto)
    {
        forStep = teto;
    }
}
