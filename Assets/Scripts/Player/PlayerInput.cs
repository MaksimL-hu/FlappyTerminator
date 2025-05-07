using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action SpaceGottenDown;
    public event Action RightMouseButtonGottenDown;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceGottenDown?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RightMouseButtonGottenDown?.Invoke();
        }
    }
}