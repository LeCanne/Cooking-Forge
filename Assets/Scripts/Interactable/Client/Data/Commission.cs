using UnityEngine;

[CreateAssetMenu(fileName = "Commission", menuName = "Scriptable Objects/Commission")]
public class Commission : ScriptableObject
{
   [SerializeField]public CommissionData data;
}
