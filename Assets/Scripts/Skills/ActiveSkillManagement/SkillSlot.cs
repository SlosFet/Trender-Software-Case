using UnityEngine;

[System.Serializable]
public class SkillSlot : MonoBehaviour
{
    //Created for if there will be more skills , it can manage them as Diablo slot system
    public KeyCode keyCode;
    public ActiveSkill skill;

    public void ActivateSkill() => skill.ActivateSkill();
}
