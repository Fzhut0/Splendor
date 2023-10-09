using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardInstance : NetworkBehaviour
{
    [SerializeField] private RawImage Image;
    
    public NetworkVariable<Color> NetCardColor;
    public NetworkVariable<int> AmountOfPointsRewarded;

    private CardColor CardColor;
    private CardDeckType DeckType;


    public void InitializeCard(CardAsset cardAsset, CardDeckType cardDeckType)
    {
        SetCardColor(cardAsset);
        SetCardDeckType(cardDeckType);
        CalculateAwardedPointsAmount(cardDeckType);
    }
    
    public override void OnNetworkSpawn()
    {
        Image.color = NetCardColor.Value;
    }
    
    private void SetCardColor(CardAsset cardAsset)
    {
        switch (cardAsset.cardColor)
        {
            case CardColor.Red:
                CardColor = CardColor.Red;
                Image.color = Color.red;
                break;
            case CardColor.White:
                CardColor = CardColor.White;
                Image.color = Color.white;
                break;
            case CardColor.Black:
                CardColor = CardColor.Black;
                Image.color = Color.black;
                break;
            case CardColor.Blue:
                CardColor = CardColor.Blue;
                Image.color = Color.blue;
                break;
            case CardColor.Green:
                CardColor = CardColor.Green;
                Image.color = Color.green;
                break;
            default:
                Image.color = Image.color;
                break;
        }

        NetCardColor.Value = Image.color;
    }

    private void CalculateAwardedPointsAmount(CardDeckType type)
    {
        AmountOfPointsRewarded.Value = type switch
        {
            CardDeckType.Bottom => Random.Range(0, 2),
            CardDeckType.Middle => Random.Range(1, 4),
            CardDeckType.Top => Random.Range(3, 6),
            _ => AmountOfPointsRewarded.Value
        };
    }

    private void SetCardDeckType(CardDeckType type)
    {
        DeckType = type;
    }
}
