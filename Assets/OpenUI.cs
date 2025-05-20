using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System;
public class OpenUI : MonoBehaviour
{
    public GameObject panel;
    public InputActionReference openOpenMenuAction;
    private void Awake()
    {
        openOpenMenuAction.action.Enable();
        openOpenMenuAction.action.performed += ToggleMenu;
        InputSystem.onDeviceChange += OnDeviceChange;
    }
    private void OnDestroy()
    {
        openOpenMenuAction.action.Disable();
        openOpenMenuAction.action.performed -= ToggleMenu;
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        panel.SetActive(!panel.activeSelf);
    }
    private void OnDeviceChange(UnityEngine.InputSystem.InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                openOpenMenuAction.action.Disable();
                openOpenMenuAction.action.performed -= ToggleMenu;
                break;
            case InputDeviceChange.Reconnected:
                openOpenMenuAction.action.Enable();
                openOpenMenuAction.action.performed += ToggleMenu;
                break;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
