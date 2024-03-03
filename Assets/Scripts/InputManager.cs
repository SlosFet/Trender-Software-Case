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

    //I tried to make it like Diablo skill system but much more simple. This events send to ActiveSkillManager and it order to
    //which slots keycode matches then skill activates
    [SerializeField] private List<KeyCode> _skillKeyCodes;
    public static UnityEvent<KeyCode> OnFearSkillUse = new UnityEvent<KeyCode>();
    public static UnityEvent<List<KeyCode>> SetSkillSlotsKeyCodes = new UnityEvent<List<KeyCode>>();

    private void Start()
    {
        SetSkillSlotsKeyCodes.Invoke(_skillKeyCodes);
    }

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

            foreach (KeyCode kc in _skillKeyCodes)
            {
                if (Input.GetKeyDown(kc))
                {
                    OnFearSkillUse.Invoke(kc);
                    break;
                }
            }
        }
    }
}
