using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

//IM ASSUMING THE TITLE SCREEN IS A DIFFERENT SCENE
public class LoadScene : MonoBehaviour
{
    public GameObject newObject;
    public GameObject recipe1;
    public static UpdateText recipetext;
    private static int recipeNumber;
    private static int currentStep;
    private static int totalSteps;
    private static int current;
    private static int goal;
    private static bool runOnce;

    // Start is called before the first frame update
    void Start()
    {
        recipeNumber = 0;
        currentStep = 1;
        runOnce = false;
        //replace true with variable from title screen scene
        if (true)
        {
            recipeNumber = 1;
            newObject = Instantiate(recipe1, transform.position, Quaternion.identity);
            recipetext = newObject.GetComponentInChildren<UpdateText>();
            current = recipetext.getCurrent();
            goal = recipetext.getGoal();
            //please change this
            totalSteps = 5;
        }
        //test
        //StartCoroutine(troll());
    }
    public void setGoal(int newGoal)
    {
        goal = newGoal;
    }

    public int getCurrentStep()
    {
        return currentStep;
    }
    public void setCurrent(int newCurrent)
    {
        current = newCurrent;
    }
    public void increaseCurrent()
    {
        current++;
    }
    public void decreaseCurrent()
    {
        current--;
    }
    // Update is called once per frame
    void Update()
    {
        recipetext.setCurrent(current);
        if (current >= goal && !runOnce)
        {
            runOnce = true;
            StartCoroutine(recipetext.EndSequence());
            StartCoroutine(EndSequence());
        }

        if(currentStep == totalSteps)
        {

        }
    }

    public void setStepText(UpdateText thetext)
    {
        recipetext = thetext;
    }
    IEnumerator EndSequence()
    {
        print("yeah");
        yield return new WaitForSeconds(5);
        current = 0;
        currentStep++;
        runOnce = false;
        print(recipetext.txt.text);
    }

    IEnumerator troll()
    {
        yield return new WaitForSeconds(5);
        current++;
    }
}
