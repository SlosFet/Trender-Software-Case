using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InputManager : MonoBehaviour
{
    public static UnityEvent<float> OnXAxisChange = new UnityEvent<float>();
    public static UnityEvent OnJumpButtonPressed = new UnityEvent();
    public static UnityEvent<Vector3> OnAttack = new UnityEvent<Vector3>();

    private float xAxis;
    [SerializeField] private CurrentOS _currentOs;

    private void Update()
    {
        if(_currentOs == CurrentOS.Windows)
        {
            xAxis = Input.GetAxisRaw("Horizontal");
            OnXAxisChange.Invoke(xAxis);

            if (Input.GetKeyDown(KeyCode.Space))
                OnJumpButtonPressed.Invoke();

            if (Input.GetMouseButtonDown(0))
                OnAttack.Invoke(Input.mousePosition);
        }
    }
}
