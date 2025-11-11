using Core.Equipment.Providers;
using UnityEngine;
using Zenject;

namespace Core.Equipment
{
    public class InventoryInstaller : MonoInstaller
    {
        [Header("Providers")]
        [SerializeField] private InventorySlotProvider inventorySlotProvider;
        [SerializeField] private EquipmentSlotProvider equipmentSlotProvider;
        [SerializeField] private ItemPatternProvider itemPatternProvider;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InventorySlotProvider>().FromInstance(inventorySlotProvider).AsSingle();
            Container.BindInterfacesAndSelfTo<EquipmentSlotProvider>().FromInstance(equipmentSlotProvider).AsSingle();
            Container.BindInterfacesAndSelfTo<ItemPatternProvider>().FromInstance(itemPatternProvider).AsSingle();

            Container.BindInterfacesAndSelfTo<Backpack.Backpack>().AsSingle();
            Container.BindInterfacesAndSelfTo<Equipment.Equipment>().AsSingle();
            Container.BindInterfacesAndSelfTo<Inventory.Inventory>().AsSingle();
        }
    }
}
   