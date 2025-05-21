using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RecipeUpdater : MonoBehaviour
{
    //Remember to add new variables in SliceObject.cs
    //All bools are default false
    public LoadScene other;
    public int forStep;
    private bool inMortar;
    private bool winMortar;
    private bool crushed;
    private bool soaked;
    private float soakTimer;

    private void Awake()
    {
        //print(forStep);
        soaked = false;
        soakTimer = 0;
    }
    void Update()
    {
        //Check if peeled
        if(transform.childCount <= 5 && gameObject.name.Contains("Green Papaya"))
        {
            StartCoroutine(makeCuttable());
        }

        //Check if papaya soaked
        if (soaked && other.getCurrentStep() == forStep && forStep == 1)
        {
            other.increaseCurrent();
            print("yay!");
            forStep = 2;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //Check if Soaked in Water
        if (gameObject.name.Contains("Green Papaya"))
        {
            print(collision.gameObject.tag);
        }
        if (collision.gameObject.tag == "Bowl")
        {
            try
            {
                bool dead = collision.gameObject.GetComponentInParent<BowlShenanigans>().getDead();
                if (dead && !soaked)
                {
                    //no idea why this isnt working
                    soakTimer += Time.fixedDeltaTime;
                    print(Time.fixedDeltaTime);
                }
            }
            catch (System.Exception e)
            {
                //print("idk");
            }
        }
        if(soakTimer > 5)
        {
            soaked = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check if Crushed
        if (collision.gameObject.name == "Pestle" && !crushed && forStep == 2)
        {
            crushed = true;
            if(other.getCurrentStep() == 2)
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
            if(other.getCurrentStep() == 3 && forStep == 3 && !winMortar)
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
                    if (other.getCurrentStep() == 2 && forStep == 2 && !winMortar)
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
    IEnumerator makeCuttable()
    {
        yield return new WaitForSeconds(2);
        transform.GetChild(0).tag = "Untagged";
    }
}
