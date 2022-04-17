using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float Health { get; }

    float MaxHealth { get; }

    void TakeDamage(float _damage);
}
