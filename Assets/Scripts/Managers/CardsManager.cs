using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CardsManager : NetworkBehaviour
{
    [SerializeField] private SlotsManager SlotsManager;
    
    [SerializeField] private List<CardInstance> BottomDeck;
    [SerializeField] private List<CardInstance> MiddleDeck;
    [SerializeField] private List<CardInstance> TopDeck;
    
    [SerializeField] private List<CardAsset> CardAssets;
    
    [SerializeField] private CardInstance SlotCard;

    [SerializeField] private GameObject DeckHolder;

    public override void OnNetworkSpawn()
    {
       
    }

    public void Start()
    {
        if(IsOwner)
        {
            PopulateDecks();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void RequestDecksToClient_ServerRPC(ServerRpcParams serverRpcParams = default)
    {
        var clientId = serverRpcParams.Receive.SenderClientId;
        if (NetworkManager.ConnectedClients.ContainsKey(clientId))
        {
            var client = NetworkManager.ConnectedClients[clientId];
            PlayerConnectionHandler playerLogicHandler = client.PlayerObject.GetComponent<PlayerConnectionHandler>();
        }
    }

    
    private void PopulateDecks()
    {
        if (IsOwner)
        {
            foreach (var card in CardAssets)
            {
                for (int i = 0; i < card.CardsAmountInBottomDeck; i++)
                {
                    var newCardInstance = Instantiate(SlotCard, DeckHolder.transform, true);
                    newCardInstance.InitializeCard(card, CardDeckType.Bottom);
                    BottomDeck.Add(newCardInstance);
                }
                for (int i = 0; i < card.CardsAmountInMiddleDeck; i++)
                {
                    var newCardInstance =  Instantiate(SlotCard, DeckHolder.transform, true);
                    newCardInstance.InitializeCard(card, CardDeckType.Middle);
                    MiddleDeck.Add(newCardInstance);
                }
                for (int i = 0; i < card.CardsAmountInHighDeck; i++)
                {
                    var newCardInstance = Instantiate(SlotCard, DeckHolder.transform, true);
                    newCardInstance.InitializeCard(card, CardDeckType.Top);
                    TopDeck.Add(newCardInstance);
                }
            }
            SlotsManager.PopulateCardSlots(BottomDeck, SlotsManager.GetBottomDeckContainer());
            SlotsManager.PopulateCardSlots(MiddleDeck, SlotsManager.GetMiddlemDeckContainer());
            SlotsManager.PopulateCardSlots(TopDeck, SlotsManager.GetTopDeckContainer());
        }
    }
}
