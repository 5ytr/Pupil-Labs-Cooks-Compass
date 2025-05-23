using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public LoadScene theone;
    public GameObject thisStep;
    public GameObject nextStep;
    private int current;
    private int goal;
    private string tempstring;
    private bool runOnce;

    private void Awake()
    {
        //this is a very temporary solution, PLEASE change this when it's a something else
        txt = GetComponent<TextMeshProUGUI>();
        goal = (int)char.GetNumericValue(txt.text[txt.text.Length - 2]);
        tempstring = txt.text;
        theone.setStepText(this);
    }

    private void Update()
    {
        txt.SetText((txt.text.Substring(0, tempstring.Length - 4)) + (current) + "/" + (goal) + "]");
        theone.setCurrent(current);
        theone.setGoal(goal);
    }

    public void currentIncrease()
    {
        current++;
    }
    public IEnumerator EndSequence()
    {
        txt.color = Color.green;
        yield return new WaitForSeconds(5);
        nextStep.SetActive(true);
        Destroy(transform.parent.parent.parent.gameObject);
    }
    public int getGoal()
    {
        return goal;
    }
    public int getCurrent()
    {
        return 0;
    }
    public void setCurrent(int newCurrent)
    {
        current = newCurrent;
    }
}
