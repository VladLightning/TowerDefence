using UnityEngine;

public class Load : MonoBehaviour
{
    private void Awake()
    {
        Save.LoadGame();
    }
}