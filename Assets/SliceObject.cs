using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;

<<<<<<< Updated upstream
    public string layerName = "Sliceable";
=======
    public string layerName = "Ingredients";
>>>>>>> Stashed changes
    private float cutForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if(hasHit)
        {
            GameObject target = hit.transform.gameObject;
<<<<<<< Updated upstream
            if((gameObject.name != "Pestle" && target.tag != "Crushable") || (gameObject.name == "Pestle" && target.tag == "Crushable"))
            {
                Slice(target);
            }

=======
            if ((gameObject.name != "Pestle" && target.tag != "Crushable") || (gameObject.name == "Pestle" && target.tag == "Crushable"))
            {
                Slice(target);
            }
>>>>>>> Stashed changes
        } 
    }

    public void Slice(GameObject target) 
    { 
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        int layerIndex = LayerMask.NameToLayer(layerName);
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if(hull != null) {
<<<<<<< Updated upstream
            string upper = target.name + "Upper";
=======
>>>>>>> Stashed changes
            GameObject upperHull = hull.CreateUpperHull(target, target.GetComponent<MeshRenderer>().material);
            SetupSlicedComponent(upperHull);
            upperHull.layer = layerIndex;
            upperHull.tag = target.tag;
<<<<<<< Updated upstream
            upperHull.name = upper;
            string lower = target.name + "Lower";
            GameObject lowerHull = hull.CreateLowerHull(target, target.GetComponent<MeshRenderer>().material);
            lowerHull.layer = layerIndex;
            lowerHull.tag = target.tag;
            lowerHull.name = lower;
=======
            upperHull.name = target.name + "Upper";
            GameObject lowerHull = hull.CreateLowerHull(target, target.GetComponent<MeshRenderer>().material);
            lowerHull.layer = layerIndex;
            lowerHull.tag = target.tag;
            lowerHull.name = target.name + "Lower";
>>>>>>> Stashed changes
            SetupSlicedComponent(lowerHull);

            Destroy(target);
        }
    }

    public void SetupSlicedComponent(GameObject slicedObject) 
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        XRGrabInteractable grabber = slicedObject.AddComponent<XRGrabInteractable>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);

    }
}
