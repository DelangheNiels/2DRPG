using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void OnHit(int damage, Vector3 otherObjectPosition, float knockbackForce);
}
