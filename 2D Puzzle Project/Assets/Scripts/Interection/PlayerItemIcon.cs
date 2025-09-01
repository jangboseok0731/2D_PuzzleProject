using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemIcon : MonoBehaviour
{
    [SerializeField] private GameObject duckIcon;
    [SerializeField] private GameObject bookIcon;
    [SerializeField] private GameObject redBallIcon;

    public void UpdateIcon(ItemType type)
    {
        //해당 아이콘 키기잇
        switch (type)
        {
            case ItemType.Duck:
                duckIcon.SetActive(true);
                break;
            case ItemType.Book:
                bookIcon.SetActive(true);
                break;
            case ItemType.RedBall:
                redBallIcon.SetActive(true);
                break;

        }
    }
}
