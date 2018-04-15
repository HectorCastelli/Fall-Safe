using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderInfo : MonoBehaviour
{
    [SerializeField] Image HealthBarImage;
    bool hasPressed = false;
    
    // Use this for initialization
    void Start()
    {
        HealthBarImage = GetComponent<Image>();
        HealthBarImage.fillAmount = 0;
    }

    private void FixedUpdate()
    {
        HealthBarImage.fillAmount -= (Time.fixedDeltaTime/5);
        if (Input.GetMouseButtonDown(0)&&!hasPressed)
        {
            StartCoroutine(AdvanceBar());
        }
    }
    public float GetSliderValue
    {
        get { return HealthBarImage.fillAmount; }
       
    }
  IEnumerator  AdvanceBar()
    {
        hasPressed = true;
        yield return new WaitForSeconds(.1f);
        Debug.Log("Current Fill Amount = "+ HealthBarImage.fillAmount);
    }
}
