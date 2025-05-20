using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleFix : MonoBehaviour
{
    //This code does not work
    public XRDirectInteractor interactor;
    private void Awake()
    {
        interactor = gameObject.GetComponent<XRDirectInteractor>();
        interactor.enabled = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        interactor.enabled = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        interactor.enabled = false;
    }
}
