using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkSystem : MonoBehaviour
{
    private GameObject handle;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.rotation);
    }
}
