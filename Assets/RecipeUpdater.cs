using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeUpdater : MonoBehaviour
{

    public LoadScene other;
    public int forStep;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Mortar") && forStep == other.getCurrentStep())
        {
            other.increaseCurrent();
            Destroy(GetComponent<RecipeUpdater>());
        }
    }
}
