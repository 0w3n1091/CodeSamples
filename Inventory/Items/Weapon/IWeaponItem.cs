namespace Core.Equipment
{
    public interface IWeaponItem : IEquipmentItem
    {
        public WeaponType WeaponType { get; }
    }
}