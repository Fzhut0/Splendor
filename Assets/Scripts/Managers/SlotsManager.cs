using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlotsManager : NetworkBehaviour
{
   [SerializeField] private List<SlotHandler> BottomDeckContainer;
   [SerializeField] private List<SlotHandler>  MiddleDeckContainer;
   [SerializeField] private List<SlotHandler>  TopDeckContainer;

   [SerializeField] private List<NetworkObject> VisibleCards;
   
   public List<SlotHandler>  GetBottomDeckContainer() => BottomDeckContainer;
   public List<SlotHandler>  GetMiddlemDeckContainer() => MiddleDeckContainer;
   public List<SlotHandler>  GetTopDeckContainer() => TopDeckContainer;


   public void PopulateCardSlots(List<CardInstance> cardInstances, List<SlotHandler> slotHandlers)
   {
      if (IsOwner)
      {
         var tempNetList = new List<NetworkObject>();

         foreach (var slot in slotHandlers)
         {
            if (slot.cardInstance)
            {
               continue;
            }
            
            var cardIndex = Random.Range(0, cardInstances.Count);
            var slotCard = Instantiate(cardInstances[cardIndex], slot.transform, true);
            slot.cardInstance = slotCard;
            slotCard.NetworkObject.Spawn();
            slotCard.NetworkObject.TrySetParent(slot.transform);
            tempNetList.Add(slotCard.NetworkObject);
            cardInstances.Remove(cardInstances[cardIndex]);
         }
         VisibleCards.AddRange(tempNetList);
      }
   }
}
