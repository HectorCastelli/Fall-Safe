using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    Camera cam;
    Animator settingsAnim;
    bool expand = false;
    GameObject settings;

    void Start()
    {
        cam = Camera.main;
        settings = GameObject.Find("Setting");
        settingsAnim = settings.GetComponent<Animator>();
    }

    void Update()
    {
    }

   
    public void Expand()
    {
        if (expand == true)
        {
            expand = false;
            settingsAnim.SetBool("Expand", false);
        }
        else
        {
            expand = true;
            settingsAnim.SetBool("Expand", true);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
