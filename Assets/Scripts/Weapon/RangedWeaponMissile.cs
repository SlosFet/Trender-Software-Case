using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponMissile : MonoBehaviour
{
    public float missileDamage;
    private Rigidbody2D rb;
    private float totalDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnShoot(Vector3 direction, float force, float weaponDamage)
    {
        rb.AddForce(direction.normalized * force);
        totalDamage = missileDamage + weaponDamage;
        HandleRotation(direction);
        Destroy(gameObject, 5);
    }

    private void HandleRotation(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody)
        {
            if (collision.attachedRigidbody.TryGetComponent(out Damageable damageable))
            {
                damageable.GetDamage(totalDamage);
            }
        }

        Destroy(gameObject);
    }
}
