using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class CrushObjects : MonoBehaviour
{
    public GameObject destroyedVersion;
    public GameObject mortar;
    private bool inMortar = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Mortar"))
        {
            inMortar = true;
        }


        if (collision.gameObject.tag.Equals("Pestle") && inMortar)
        {
            Instantiate(destroyedVersion, mortar.transform.position + new Vector3(0, 0.05f, 0), mortar.transform.rotation);
            Destroy(gameObject);
        }

        if(!(collision.gameObject.tag.Equals("Mortar") || collision.gameObject.tag.Equals("Pestle") || collision.gameObject.layer == 10))
        {
            inMortar = false;
        }
    }
}
