using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRendering : MonoBehaviour
{
    private GameObject selectedFarmPatch;

    public GameObject farmMenuPopup;
    public GameObject inventoryMenuPopup;

    public GameObject harvestButton;

    

    public bool menuIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFarmMenu(GameObject clickedFarmPatch)
    {
        selectedFarmPatch = clickedFarmPatch;
        farmMenuPopup.gameObject.SetActive(true);
        menuIsOpen = true;
        harvestButton.gameObject.SetActive(false);
        if (selectedFarmPatch.GetComponent<FarmPatchBehaviour>().isDoneGrowing == true)
        {
            harvestButton.gameObject.SetActive(true);
        }

    }

    public void CloseFarmMenu()
    {
        farmMenuPopup.gameObject.SetActive(false);
        menuIsOpen = false;
    }

    public void PlantTree()
    {
        if(selectedFarmPatch.GetComponent<FarmPatchBehaviour>().isEmpty == true)
        {
            selectedFarmPatch.GetComponent<FarmPatchBehaviour>().Plant(Plants.Tree);
            selectedFarmPatch.GetComponent<FarmPatchBehaviour>().isEmpty = false;
            selectedFarmPatch.GetComponent<FarmPatchBehaviour>().isDoneGrowing = true;
            CloseFarmMenu();
        }
    }

    public void OpenInventory()
    {
        inventoryMenuPopup.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        inventoryMenuPopup.gameObject.SetActive(false);
    }

    public void HarvestFarm()
    {
        if(selectedFarmPatch != null)
        {
            selectedFarmPatch.GetComponent<FarmPatchBehaviour>().Harvest();
           
        }

        CloseFarmMenu();
    }


}
