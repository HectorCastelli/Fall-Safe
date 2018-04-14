using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    Camera cam;
    Animator settingsAnim;
    bool expand = false;
    [SerializeField]
    GameObject settings;

    void Start()
    {
        cam = Camera.main;
        settings = GameObject.Find("Setting");
        settingsAnim = settings.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if(Physics2D.Raycast(ray, out hit ,1000))
            //{
            //    Debug.Log(hit.collider.tag);
            //}
        }
    }

    public void Print()
    {
        print("adsdsadasdsadas");
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
}
