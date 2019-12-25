using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    public VirtualButtonBehaviour[] vbs;
    public GameObject cube;
    public GameObject but;
    public Color[] colors;
    public int index;

    void Start()
    {
        vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; i++)
        {
            vbs[i].RegisterEventHandler(this);
        }
        index = 0;
        colors = new Color[5];
        colors[0] = Color.white;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.red;
        colors[4] = Color.black;
        cube = GameObject.Find("ImageTarget/Cube");
        but = GameObject.Find("ImageTarget/VirtualButton/Plane");
    }

    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        but.GetComponent<Renderer>().material.color = Color.white;
        if (index == 5)
            index = 0;
        cube.GetComponent<Renderer>().material.color = colors[index++];
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        but.GetComponent<Renderer>().material.color = Color.white;
    }
}

