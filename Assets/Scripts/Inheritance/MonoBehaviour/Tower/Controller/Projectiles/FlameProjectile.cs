
using UnityEngine;

public class FlameProjectile : StatusProjectile
{
    protected override void TriggerEffect(Collider2D collision)
    {
        Debug.Log("Incinerate");
    }
}
