using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    private bool capOff;
    private int pourThreshold;
    private int actualAngle;
    // Start is called before the first frame update
    void Awake()
    {
        //testing
        capOff = true;
    }

    // Update is called once per frame
    void Update()
    {
        actualAngle = (int)transform.eulerAngles.z;
        gameObject.GetComponentInChildren<ParticleSystem>().transform.eulerAngles = new Vector3(90, 0, 0);
        if(actualAngle > 30 && actualAngle < 330 && capOff)
        {
            transform.GetComponentInChildren<ParticleSystem>().Play();
        }
        else
        {
            transform.GetComponentInChildren<ParticleSystem>().Pause();
            transform.GetComponentInChildren<ParticleSystem>().Clear();
        }
    }
}
