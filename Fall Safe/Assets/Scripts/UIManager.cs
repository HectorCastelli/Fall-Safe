using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    Camera cam;
    Animator settingsAnim;
    bool expand = false;
    GameObject settings;
    GameObject win;
    GameObject loss;
    Animator wAnim;
    Animator lAnim;

    void Start()
    {
        cam = Camera.main;
        settings = GameObject.Find("Setting");
        settingsAnim = settings.GetComponent<Animator>();
        win = GameObject.Find("Win");
        loss = GameObject.Find("Loss");
        wAnim = win.GetComponent<Animator>();
        lAnim = loss.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Win();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Loss();
        }
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
    public void Win()
    {
        wAnim.SetBool("Win", true);
        StartCoroutine(Reset());
    }
    public void Loss()
    {
        lAnim.SetBool("Loss", true);
        StartCoroutine(Reset());
    }
    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        wAnim.SetBool("Win", false);
        lAnim.SetBool("Loss", false);
        yield return null;
    }
}
