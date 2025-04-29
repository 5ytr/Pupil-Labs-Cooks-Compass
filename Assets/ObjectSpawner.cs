using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using Unity.VisualScripting;

public class ObjectSpawner : XRBaseInteractable
{
    [SerializeField]
    private GameObject grabbaleObject;

    [SerializeField]
    private Transform transformToInstantiate;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        GameObject newObject = Instantiate(grabbaleObject, transformToInstantiate.position, Quaternion.identity);

        XRGrabInteractable objectInteractable = newObject.GetComponent<XRGrabInteractable>();

        interactionManager.SelectEnter(args.interactorObject, objectInteractable);

        base.OnSelectEntered(args);
    }
}
