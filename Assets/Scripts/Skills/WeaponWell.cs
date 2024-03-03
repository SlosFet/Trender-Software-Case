using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWell : PassiveSkill
{
    [SerializeField] private GameObject _throwObject;
    [SerializeField] private Transform _throwPos;

    [SerializeField] private float _maxAngle;
    [SerializeField] private float _maxForce;
    [SerializeField] private float _minForce;

    [SerializeField] private int _throwObjectCount;
    private List<ThrowableObject> instantiatedObjects = new List<ThrowableObject>();


    public override void ActivateSkill()
    {
        instantiatedObjects.Clear();
        for (int i = 0; i < _throwObjectCount; i++)
        {
            instantiatedObjects.Add(Instantiate(_throwObject, _throwPos.position, Quaternion.identity).GetComponent<ThrowableObject>());
        }

        foreach (var item in instantiatedObjects)
        {
            item.OnShoot(GetRandomDirection(), GetRandomForce());
        }
        base.ActivateSkill();
    }

    private Vector3 GetRandomDirection()
    {
        float dir1 = Random.Range(-_maxAngle / 2f, -_maxAngle / 4f);
        float dir2 = Random.Range(_maxAngle / 2f, _maxAngle / 4f);
        int randomLeftOrRight = Random.Range(0, 2);

        float dir = dir1;
        if (randomLeftOrRight == 1)
            dir = dir2;

        Vector3 direction = Quaternion.Euler(0, 0, dir) * _throwPos.up;
        return direction.normalized;
    }

    private float GetRandomForce()
    {
        return Random.Range(_minForce, _maxForce);
    }
}
