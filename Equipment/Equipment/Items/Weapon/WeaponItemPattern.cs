using UnityEngine;

namespace Core.Equipment
{
    public enum WeaponType { OneHanded, TwoHanded, Ranged, Shield }

    [CreateAssetMenu(menuName = "RPG Libraries/Equipment/Items/WeaponItem", fileName = "Create WeaponItem Item", order = 1)]
    public class WeaponItemPattern : EquipmentItemPattern
    {
        [Header("Weapon Item")]
        [field: SerializeField] public WeaponType WeaponType { get; private set; }

        public override IInventoryItem CreateInstance() => new WeaponItem(this);
    }
}