using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class Midterm : MonoBehaviour
{

    [DllImport("MidtermDLL")]
    private static extern float GetCol1();

    [DllImport("MidtermDLL")]
    private static extern float GetCol2();

    [DllImport("MidtermDLL")]
    private static extern float GetCol3();

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(GetCol1(), GetCol2(), GetCol3());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
