using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkSystem : MonoBehaviour
{
    private float rotation;
    public ParticleSystem water;
    void Awake()
    {
        water = transform.parent.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.localEulerAngles.x;
        if(rotation >= 270 && rotation < 320)
        {
            water.Pause();
            water.Clear();
        }
        else
        {
            water.Play();
        }
    }
}
