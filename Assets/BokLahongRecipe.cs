using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

//script from hell

public class BokLahongRecipe : MonoBehaviour
{
    public GameObject crushedGarlic;
    public int woohoo;

    private void Awake()
    {
        woohoo = 0;
        print(woohoo);
    }
    void Update()
    {
        
    }

    

    public void increaseCounter()
    {
        woohoo++;
        print(woohoo);
    }

    
}
