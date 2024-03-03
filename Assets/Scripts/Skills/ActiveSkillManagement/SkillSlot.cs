using UnityEngine;

[System.Serializable]
public class SkillSlot : MonoBehaviour
{
    public KeyCode keyCode;
    public ActiveSkill skill;

    public void ActivateSkill() => skill.ActivateSkill();
}
