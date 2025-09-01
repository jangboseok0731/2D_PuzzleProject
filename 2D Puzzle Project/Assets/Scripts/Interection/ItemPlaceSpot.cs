using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlaceSpot : MonoBehaviour
{
    [SerializeField] private Transform placePoint;

    public void PlaceItem(Item item)
    {
        item.OnPlace(placePoint.position);
    }

}
