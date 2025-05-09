using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const KeyCode Space = KeyCode.Space;
    public const int RightMouseButton = 0;

    public event Action SpaceGottenDown;
    public event Action RightMouseButtonGottenDown;

    private void Update()
    {
        if (Input.GetKeyDown(Space))
        {
            SpaceGottenDown?.Invoke();
        }

        if (Input.GetMouseButtonDown(RightMouseButton))
        {
            RightMouseButtonGottenDown?.Invoke();
        }
    }
}