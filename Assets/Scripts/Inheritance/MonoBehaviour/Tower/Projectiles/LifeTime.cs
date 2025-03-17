
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
