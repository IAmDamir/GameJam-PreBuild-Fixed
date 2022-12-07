using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    private static PlayerControls controls;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one DIalogue Manager instance in scene!");
        }
        instance = this;
        controls = new PlayerControls();
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public static PlayerControls getControls()
    {
        return controls;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}