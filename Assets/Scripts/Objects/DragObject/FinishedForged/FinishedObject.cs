using UnityEngine;


//Class handling objects on desk.
public class FinishedObject : DragObject
{
    public class WeaponData
    {
        public string name;
        public int quality;
        public ENUM_WEAPONTYPES weaponType;
        public Sprite sprite;
    }

    public WeaponData weaponData;

}
