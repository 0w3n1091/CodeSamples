using System;
using System.Collections.Generic;
using System.Linq;
using Core.Equipment.Providers;
using Core.Equipment.Slots;
using UniRx;

namespace Core.Equipment.Backpack
{
    internal class Backpack : IBackpack
    {
        public IReadOnlyReactiveProperty<IInventoryItem> OnItemCreated => onItemCreated;
        public IReadOnlyReactiveProperty<IInventoryItem> OnItemRemoved => onItemRemoved;
        public IReadOnlyReactiveProperty<(IInventoryItem item, int amount)> OnItemUpdated => onItemUpdated;
    
        private readonly ReactiveProperty<IInventoryItem> onItemCreated = new ReactiveProperty<IInventoryItem>();
        private readonly ReactiveProperty<IInventoryItem> onItemRemoved = new ReactiveProperty<IInventoryItem>();
        private readonly ReactiveProperty<(IInventoryItem item, int amount)> onItemUpdated = new ReactiveProperty<(IInventoryItem, int)>();
    
        private readonly InventorySlotProvider slotProvider;
        private readonly Dictionary<InventorySlot, List<IInventoryItem>> items = new Dictionary<InventorySlot, List<IInventoryItem>>();
    
        public Backpack(InventorySlotProvider slotProvider)
        {
            this.slotProvider = slotProvider;
            foreach (var slot in slotProvider.Get())
                items.Add(slot, new List<IInventoryItem>());
        }
    
        public void Insert(IInventoryItem item)
        {
            var slot = slotProvider.Get(item.BackpackSlotType);

            items[slot].Add(item);
            onItemCreated.SetValueAndForceNotify(item);
        }

        public void Remove(IInventoryItem item)
        {
            var slot = slotProvider.Get(item.BackpackSlotType);
        
            if (!items[slot].Contains(item))
                return;

            items[slot].Remove(item);
            onItemRemoved.SetValueAndForceNotify(item);
        }

        public int Add(IInventoryItem item, int amount = 1)
        {
            if (amount < 1)
                return 0;
            
            int availableSpace = item.StackSize - item.Stack;
            int amountAdded = Math.Min(amount, availableSpace);
        
            item.Stack += amountAdded;
            onItemUpdated.SetValueAndForceNotify((item, item.Stack));
        
            return amount - amountAdded;
        }

        public int Subtract(IInventoryItem item, int amount = 1)
        {
            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            int amountRemoved = Math.Min(amount, item.Stack);
        
            item.Stack -= amountRemoved;
            onItemUpdated.SetValueAndForceNotify((item, item.Stack));
        
            return amount - amountRemoved;
        }

        public bool Exists(string patternId, out IInventoryItem instance)
        {
            foreach (InventorySlot slot in slotProvider.Get())
            {
                for (var i = items[slot].Count - 1; i >= 0; i--)
                {
                    var item = items[slot][i];
                    if (item.PatternId == patternId)
                    {
                        instance = item;
                        return true;
                    }
                }
            }

            instance = null;
            return false;
        }
        
        public bool Exists(IInventoryItem item)
        {
            return items.Values.SelectMany(category => category).Any(inventoryItem => !item.Equals(inventoryItem));
        }
    }
}