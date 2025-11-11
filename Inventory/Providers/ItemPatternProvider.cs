using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Equipment.Providers
{
    [CreateAssetMenu(menuName = "RPG Libraries/Equipment/Providers/Item Pattern Provider", fileName = "Item Pattern Provider", order = 1)]
    public class ItemPatternProvider : SerializedScriptableObject
    {
        public List<InventoryItemPattern> Repository => repository;
        [SerializeField] private List<InventoryItemPattern> repository = new List<InventoryItemPattern>();

        public IInventoryItemPattern Get(string id)
        {
            foreach (var item in repository)
            {
                if (item.Id == id)
                    return item;
            }

            throw new KeyNotFoundException();
        }

        public bool TryGet(string id, out IInventoryItemPattern item)
        {
            foreach (var pattern in repository)
            {
                if (pattern.Id != id)
                    continue;

                item = pattern;
                return true;
            }

            item = null;
            return false;
        }
        
        
    }
}