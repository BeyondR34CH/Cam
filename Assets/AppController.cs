using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public GameObject cam2, cam3;

    private bool current, switching;
    private GameObject camIns;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    private void Start()
    {
        switching = false;
        if (PlayerPrefs.HasKey("current"))
        {
            current = PlayerPrefs.GetInt("current") == 1 ? true : false;
            camIns = current ? Instantiate(cam2) : Instantiate(cam3);
        }
        else
        {
            current = true;
            camIns = Instantiate(cam2);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(camIns);
            switching = true;
        }
        else if (switching)
        {
            switching = false;
            current = !current;
            camIns = current ? Instantiate(cam2) : Instantiate(cam3);
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("current", current ? 1 : 0);
        PlayerPrefs.Save();
    }
}
