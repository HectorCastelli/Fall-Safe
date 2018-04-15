using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCameraChanger : MonoBehaviour {
    public List<GameObject> cameras = new List<GameObject>();

    public float minWait, maxWait;

    public bool _isEnabled = false;

    private float timer;

    private void Awake()
    {
        foreach (GameObject go in cameras.FindAll(x => x.activeSelf == true))
        {
            go.SetActive(false);
        }
        cameras[Random.Range(0, cameras.Count - 1)].SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if (!_isEnabled) return;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            timer = Random.Range(minWait, maxWait);
            foreach (GameObject go in cameras.FindAll(x => x.activeSelf == true))
            {
                go.SetActive(false);
            }
            cameras[Random.Range(0, cameras.Count - 1)].SetActive(true);
        }
	}
}
