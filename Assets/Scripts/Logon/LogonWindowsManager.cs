using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogonWindowsManager : MonoBehaviour
{
    [SerializeField]
    private WindowsAsset logonWindowsAsset;

    private void Start()
    {
        GameObject[] logonWindows = logonWindowsAsset.Windows;
        foreach (GameObject go in logonWindows)
        {
            Instantiate(go, transform.parent).GetComponent<Canvas>().enabled = false;
        }
    }

    public void Registration()
    {
        
    }

    public void Authorization()
    {
        
    }

    public void Exit()
    {
        Debug.Log("Exit game...");
        Application.Quit();
    }
}
