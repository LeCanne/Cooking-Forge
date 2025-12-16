using UnityEngine;

[CreateAssetMenu(fileName = "Commission", menuName = "Scriptable Objects/Commissioners/Commission")]
public class Commission : ScriptableObject
{
   [SerializeField]public CommissionData data;
}
