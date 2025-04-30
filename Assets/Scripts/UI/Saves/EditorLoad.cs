#if UNITY_EDITOR
using UnityEngine;

public class EditorLoad : MonoBehaviour
{
    private void Awake()
    {
        Save.LoadGame();
    }
}
#endif