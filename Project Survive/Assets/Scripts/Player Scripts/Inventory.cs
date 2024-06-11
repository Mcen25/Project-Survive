using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using UnityEngine.UI;

public class Inventory : NetworkBehaviour
{

    private Transform highlight;
    private Ray ray;
    private RaycastHit hit;
    private int objectPosition;

    [Header("Sprites")]
    [SerializeField] private Sprite selectedFrame;
    [SerializeField] private Sprite deselectedFrame;

    [Header("Inventory game objects")]
    [SerializeField] private Image[] InventoryImages;
    [SerializeField] private Image[] InventoryImagesChildren;

    private Dictionary<int, GameObject> inventory;
    private Dictionary<int, GameObject> inventoryItems;
    private Dictionary<int, GameObject> currentInventory;

    void Start() 
    {
        // Initialize the inventory here
        inventory = new Dictionary<int, GameObject>
        {
            { 0, InventoryImages[0].gameObject},
            { 1, InventoryImages[1].gameObject},
            { 2, InventoryImages[2].gameObject},
            { 3, InventoryImages[3].gameObject}
        };


        inventoryItems = new Dictionary<int, GameObject>
        {
            { 0, InventoryImagesChildren[0].gameObject},
            { 1, InventoryImagesChildren[1].gameObject},
            { 2, InventoryImagesChildren[2].gameObject},
            { 3, InventoryImagesChildren[3].gameObject}
        };

        currentInventory = new Dictionary<int, GameObject>
        {
            { 0, null},
            { 1, null},
            { 2, null},
            { 3, null}
        };
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!base.IsOwner) {
            enabled = false;
            return;
        }

        objectPosition = 0;
    }

    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit))
        {
            highlight = hit.transform;

            if (highlight.CompareTag("Selectable") && highlight.gameObject.GetComponent<Item>())
            {
                GameObject highlightedObject = highlight.gameObject;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PickUpItem(highlightedObject);
                    Destroy(highlightedObject);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G) && currentInventory[objectPosition] != null)
        {
            GameObject item = currentInventory[objectPosition];
            if (item != null)
            {
                //TODO: Drop the item
                item.SetActive(true);
                currentInventory[objectPosition] = null;
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdatePosition(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpdatePosition(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UpdatePosition(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UpdatePosition(3);
        }
       
    }

    private void UpdatePosition(int position) {
        objectPosition = position;

        if (inventory.TryGetValue(objectPosition, out GameObject inventoryItem))
        {
            Image inventoryItemImage = inventoryItem.GetComponent<Image>();
            if (inventoryItemImage != null)
            {
                inventoryItemImage.sprite = selectedFrame;
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (i != objectPosition)
                    {
                        inventory.TryGetValue(i, out GameObject otherInventoryItem);
                        Image otherInventoryItemImage = otherInventoryItem.GetComponent<Image>();
                        otherInventoryItemImage.sprite = deselectedFrame;
                    }
                }
            }
            else
            {
                Debug.LogError("Inventory item does not have an Image component.");
            }
        }
        else
        {
            Debug.LogError($"Inventory item with key {objectPosition} not found.");
        }
    }

    private void PickUpItem(GameObject item) {
    
        if (currentInventory[objectPosition] == null)
        {
            currentInventory[objectPosition] = item;
        } else {
            Debug.LogError("Inventory slot is already occupied.");
        } 

        if (inventoryItems.TryGetValue(objectPosition, out GameObject inventoryItemChild))
        {
            Image inventoryItemImageChild = inventoryItemChild.GetComponent<Image>();
            inventoryItemImageChild.gameObject.SetActive(true);
            if (inventoryItemImageChild != null)
            {
                inventoryItemImageChild.sprite = item.GetComponent<Image>().sprite;
            }
            else
            {
                Debug.LogError("Inventory item does not have an Image component.");
            }
        }
        else
        {
            Debug.LogError($"Inventory item with key {objectPosition} not found.");

        }
    }
}
