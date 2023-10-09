using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHandler : MonoBehaviour
{

    [SerializeField]
    private CardInstance CardInstance;

    public CardInstance cardInstance
    {
        get => CardInstance;
        set => CardInstance = value;
    }

}
