using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlShenanigans : MonoBehaviour
{

    private int amtFilled;
    private int maxFill;
    private FillBowl fijo;
    private bool dead;
    void Start()
    {
        dead = false;
    }

    private void Awake()
    {
        fijo = transform.GetComponent<FillBowl>();
    }

    // Update is called once per frame
    void Update()
    {
        maxFill = fijo.getMaxFill();
        amtFilled = fijo.getAmtFilled();
    }
    
    private void OnCollisionStay(Collision collision)
    {
        print(collision.gameObject.layer);
        //If hits table and is full:
        if (collision.gameObject.layer == 9 && amtFilled >= maxFill && maxFill != 0)
        {
            Destroy(transform.GetComponent<XRGrabInteractable>());
            Destroy(transform.GetComponent<Rigidbody>());
            Destroy(transform.GetComponent<BoxCollider>());
            dead = true;
            transform.rotation = Quaternion.identity;
            this.transform.GetChild(0).gameObject.AddComponent<MeshCollider>();
        }
    }

    public bool getDead()
    {
        return dead;
    }
}
