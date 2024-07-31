using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    [SerializeField] private TowerManager _choicePanel;

    private void OnMouseDown()
    {
        _choicePanel.SetBuildPosition(transform);
    }
}
