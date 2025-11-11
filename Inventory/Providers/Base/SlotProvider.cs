using System;
using Core.Equipment.Slots;
using Core.Providers;

namespace Core.Equipment.Providers
{
    public class SlotProvider<TType, TSlot> : ScriptableProvider<TType, TSlot>  where TSlot : Slot<TType> where TType : Enum
    {
    
    }
}