
using UnityEngine;

public class FlameProjectile : Projectile
{
    protected override void TriggerEffect(Collider2D collision)
    {
        Debug.Log("Incinerate");
    }
}
