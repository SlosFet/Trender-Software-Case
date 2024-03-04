using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    private void Start()
    {
        _playerHealth.OnGetDamage += Vibrate;
    }

    private void Vibrate()
    {
        //If I have MoreMountains.NiceVibrations asset that would be much more better but free assets are not good enough. So I stucked at HandHeld
        Handheld.Vibrate();
    }
}
