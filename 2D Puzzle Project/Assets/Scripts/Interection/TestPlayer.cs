using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float itemPicradius = 5f;
    [SerializeField] private PlayerItemIcon iconManager;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Item heldItem = null;

    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        iconManager.UpdateIcon(ItemType.None);
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            TryInteract();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity= moveInput * moveSpeed;
    }
    private void TryInteract()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, itemPicradius);

        foreach(var col in collider)
        {
            // 아이템 줍기
            Item item = col.GetComponent<Item>();
            if(item != null && heldItem == null)
            {
                heldItem = item;
                item.OnPick();
                iconManager.UpdateIcon(item.GetItemType());
                Debug.Log($"{item.GetItemType()} 아이템을 주었당");
                return;
            }
            // 아이템 놓기
            ItemPlaceSpot spot = col.GetComponent<ItemPlaceSpot>();
            if (spot != null && heldItem != null)
            {
                spot.PlaceItem(heldItem);
                heldItem = null;
                iconManager.UpdateIcon(ItemType.None);
                Debug.Log("아이콘 초기화");
                return;
            }
            
        }
    }

}
