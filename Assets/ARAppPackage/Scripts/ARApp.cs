using System;
using UnityEngine;

[DefaultExecutionOrder(-15)]
public class ARApp : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AppSettings settings;

    [SerializeField] private GameObject introCanvas;
    [SerializeField] private GameObject appCanvas;
    
    
    public AppSettings Settings => settings;


    private void Awake()
    {
        introCanvas.SetActive(true);
        appCanvas.SetActive(false);
    }
}
