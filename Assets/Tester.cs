using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        //print(other.name);
    }

    private void Update()
    {
        print(transform.eulerAngles.x);
    }
}
