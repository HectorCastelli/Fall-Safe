using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderInfo : MonoBehaviour
{
    [SerializeField] Image HealthBarImage;


    // Use this for initialization
    void Start()
    {
        HealthBarImage = GetComponent<Image>();
        HealthBarImage.fillAmount = 0;
    }

    private void Update()
    {
        HealthBarImage.fillAmount -= (Time.fixedDeltaTime / 5f);
        if (Input.GetMouseButtonDown(0))
        {
            HealthBarImage.fillAmount += .15f;
        }
    }


    public float GetSliderValue
    {
        get { return HealthBarImage.fillAmount; }

    }
}
