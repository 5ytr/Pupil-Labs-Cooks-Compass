using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePhysics : MonoBehaviour
{
    private Vector3 whoknows;
    private bool plateGrabbed;
    // Start is called before the first frame update
    void Start()
    {
        whoknows = Vector3.zero;
        //when i figure this out "grabbed" should start false
        plateGrabbed = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            whoknows = transform.position - collision.transform.position;
            print(whoknows);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(whoknows != Vector3.zero && collision.gameObject.tag == "Plate" && plateGrabbed)
        {
            //check if plate is tilted down so it slides off
            if(collision.transform.eulerAngles.x > 250 && collision.transform.eulerAngles.x < 300)
            transform.position = whoknows + collision.transform.position;
            if(whoknows.y > 0.05)
            {
                transform.position += new Vector3(0, 0.05f, 0);
            }
        }
    }
}
