using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _startMoney;
    public int StartMoney => _startMoney;
}
