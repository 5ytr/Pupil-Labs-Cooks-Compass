using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] ParticleSystem saltSpawner = null;

    // TODO: delete after finished testing
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Collect();
        }
    }

    public void Collect()
    {
        // play the collect graphics
        saltSpawner.Play();
        // play the collect sound effects
    }
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
