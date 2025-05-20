using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SliderText : MonoBehaviour
{
    public Slider sliderBoii;
    public TextMeshProUGUI sliderText;
    // Start is called before the first frame update
    void Start()
    {
        sliderBoii.onValueChanged.AddListener((v) =>
        {
            sliderText.text = "Height: " + v.ToString("0.00");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
