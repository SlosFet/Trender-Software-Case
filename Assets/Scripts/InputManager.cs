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

    //I tried to make it like Diablo skill system but much more simple. This events send to ActiveSkillManager and it order to
    //which slots keycode matches then skill activates
    [SerializeField] private List<KeyCode> _skillKeyCodes;
    public static UnityEvent<KeyCode> OnSkillUse = new UnityEvent<KeyCode>();
    public static UnityEvent<List<KeyCode>> SetSkillSlotsKeyCodes = new UnityEvent<List<KeyCode>>();

    [SerializeField] private FixedJoystick _movementJoystick;
    [SerializeField] private FixedJoystick _fireJoystick;
    [SerializeField] private float _androidJumpLimitTime;

    private void Start()
    {
        SetSkillSlotsKeyCodes.Invoke(_skillKeyCodes);
        if(GameManager.Instance.currentOS == CurrentOS.Windows)
        {
            _movementJoystick.gameObject.SetActive(false);
            _fireJoystick.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(GameManager.Instance.currentOS == CurrentOS.Windows)
        {
            xAxis = Input.GetAxisRaw("Horizontal");
            OnXAxisChange.Invoke(xAxis);

            if (Input.GetKeyDown(KeyCode.Space))
                OnJumpButtonPressed.Invoke();

            if (Input.GetMouseButton(0))
                OnAttack.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            foreach (KeyCode kc in _skillKeyCodes)
            {
                if (Input.GetKeyDown(kc))
                {
                    OnSkillUse?.Invoke(kc);
                    break;
                }
            }
        }
        else if(GameManager.Instance.currentOS == CurrentOS.Android)
        {
            OnXAxisChange.Invoke(_movementJoystick.Direction.x);
            if(_movementJoystick.Direction.y > 0.5f)
                OnJumpButtonPressed.Invoke();

            if (_fireJoystick.Direction.magnitude != 0)
                OnAttack.Invoke(_fireJoystick.Direction);
        }
    }
}
