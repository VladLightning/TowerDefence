
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
}
