using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    [field : SerializeField] protected MissileData _data;
    private Rigidbody2D rb;
    private float totalDamage;
    [SerializeField] private float _torqueForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    public void OnShoot(Vector3 direction, float force, float extraDamage = 0)
    {
        rb.AddForce(direction.normalized * force);

        //float torqueDir = Vector2.Dot(-transform.right, -transform.right);
        //rb.AddTorque(_torqueForce * torqueDir);

        totalDamage = _data.damage + extraDamage;
        HandleRotation(direction);
        Destroy(gameObject, _data.destroyTime);
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
                Destroy(gameObject);
            }
        }

    }
}
