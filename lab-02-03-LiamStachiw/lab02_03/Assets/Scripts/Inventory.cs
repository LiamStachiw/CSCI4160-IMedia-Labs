using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Equipment armour;
    [SerializeField] private Equipment weapon;
    [SerializeField] private List<Equipment> unequipped;
    [SerializeField] private Canvas inventoryScreen;

    public List<Button> unequippedBtns;
    public Equipment temp;

    public void EquipItem(Button button) {
        int btnIndex = unequippedBtns.IndexOf(button);
        Equipment selectedItem = unequipped[btnIndex];

        if (selectedItem.type == "weapon") {
            Debug.Log("Here");
            temp = weapon;
            weapon = selectedItem;
            Button weaponButton = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Button>();
            weaponButton.image.sprite = weapon.icon;
        } 
        else if (selectedItem.type == "armour") {
            temp = armour;
            armour = selectedItem;
            Button armourButton = GameObject.FindGameObjectWithTag("Armour").GetComponent<Button>();
            armourButton.image.sprite = armour.icon;
        }

        if (selectedItem.type != "placeholder") {
            button.image.sprite = temp.icon;
            unequipped[btnIndex] = temp;
        }

    }

    private void Start() {
        GameObject[] btns = GameObject.FindGameObjectsWithTag("Unequipped");

        for(int i = 0; i < btns.Length; i++) {
            unequippedBtns.Add(btns[i].GetComponent<Button>());
        }

        UpdateUnequipped();

        inventoryScreen.gameObject.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown("i")) {
            if (inventoryScreen.isActiveAndEnabled) {
                inventoryScreen.gameObject.SetActive(false);
            } else {
                inventoryScreen.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        unequipped.Add(collision.GetComponent<Equipment>());
        collision.GetComponent<Equipment>().gameObject.SetActive(false);

        UpdateUnequipped();
    }

    public void UpdateUnequipped() {
        for(int i = 0; i < unequippedBtns.Count; i++) {
            if (unequipped.Count > i) {
                unequippedBtns[i].image.sprite = unequipped[i].icon;
            }
            
        }
    }
}
