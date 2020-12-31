﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toolbar : MonoBehaviour
{
    private World world;
    public Player player;

    public RectTransform highlight;
    public ItemSlot[] ItemSlots;

    private int slotIndex = 0;

    private void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        foreach (ItemSlot slot in ItemSlots)
        {
            slot.icon.sprite = world.blocktypes[slot.itemID].icon;
            slot.icon.enabled = true;
        }
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            if (scroll > 0)
                slotIndex--;
            else
                slotIndex++;

            if (slotIndex > ItemSlots.Length - 1)
                slotIndex = 0;
            if (slotIndex < 0)
                slotIndex = ItemSlots.Length - 1;

            highlight.position = ItemSlots[slotIndex].icon.transform.position;
            player.selectedBlockIndex = ItemSlots[slotIndex].itemID;
        }
    }
}

[System.Serializable]
public class ItemSlot
{
    public byte itemID;
    public Image icon;
}
