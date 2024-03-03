using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillManager : MonoBehaviour
{
    //Created for if there will be more skills , it can manage them as Diablo slot system
    [SerializeField] private List<SkillSlot> _skillSlots;

    private void OnEnable()
    {
        InputManager.OnFearSkillUse.AddListener(ActivateSkill);
        InputManager.SetSkillSlotsKeyCodes.AddListener(SetSlotsKeyCodes);
    }

    private void OnDisable()
    {
        InputManager.OnFearSkillUse.RemoveListener(ActivateSkill);
        InputManager.SetSkillSlotsKeyCodes.RemoveListener(SetSlotsKeyCodes);
    }

    private void SetSlotsKeyCodes(List<KeyCode> keycodes)
    {
        for (int i = 0; i < _skillSlots.Count; i++)
        {
            _skillSlots[i].keyCode = keycodes[i];
        }
    }

    private void ActivateSkill(KeyCode keycode)
    {
        foreach (var slot in _skillSlots)
        {
            if (slot.keyCode == keycode)
                slot.ActivateSkill();
        }
    }
}
