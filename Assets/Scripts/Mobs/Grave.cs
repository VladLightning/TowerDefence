using UnityEngine;

public class Grave : MonoBehaviour
{
    public void Initiate(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }
}
