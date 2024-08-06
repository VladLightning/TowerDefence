using UnityEngine;

public class HeroPath : MonoBehaviour
{
    [SerializeField] private HeroMovement _heroMovement;

    private void OnMouseDown()
    {
        _heroMovement.StartMovement();
    }
}
