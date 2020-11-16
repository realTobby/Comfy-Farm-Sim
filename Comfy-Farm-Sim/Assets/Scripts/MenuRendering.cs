using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRendering : MonoBehaviour
{
    private GameObject selectedFarmPatch;

    public GameObject farmMenuPopup;
    public GameObject inventoryMenuPopup;
    public GameObject inventoryOpenButton;

    public GameObject harvestButton;

    IMenues currentMenu;

    public bool menuIsOpen = false;

    public bool isEditModeEnabled = false;


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
        if (selectedFarmPatch.GetComponent<FarmPatch>().isDoneGrowing == true)
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
        if(selectedFarmPatch.GetComponent<FarmPatch>().isEmpty == true)
        {
            selectedFarmPatch.GetComponent<FarmPatch>().Plant(Plantables.Tree);
            selectedFarmPatch.GetComponent<FarmPatch>().isEmpty = false;
            selectedFarmPatch.GetComponent<FarmPatch>().isDoneGrowing = true;
            CloseFarmMenu();
        }
    }

    public void OpenInventory()
    {
        inventoryMenuPopup.gameObject.SetActive(true);
        inventoryOpenButton.gameObject.SetActive(false);
    }

    public void CloseInventory()
    {
        inventoryMenuPopup.gameObject.SetActive(false);
        inventoryOpenButton.gameObject.SetActive(true);
    }

    public void HarvestFarm()
    {
        if(selectedFarmPatch != null)
        {
            selectedFarmPatch.GetComponent<FarmPatch>().Harvest();
        }
        CloseFarmMenu();
    }

    public void ConstructionMenuButtonClick()
    {
        if(isEditModeEnabled)
        {
            DisableEditMode();
        }
        else
        {
            EnableEditMode();
        }
    }

    public void EnableEditMode()
    {
        isEditModeEnabled = true;
        GameObject.FindGameObjectWithTag("WORLD").GetComponent<World>().EnableEditMode();
    }

    public void DisableEditMode()
    {
        isEditModeEnabled = false;
        GameObject.FindGameObjectWithTag("WORLD").GetComponent<World>().DisableEditMode();
    }

}
