using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    MenuRendering menurenderer;

    GameObject selectedFarmPatch;

    GameObject selectedConstructionPatch;


    // Start is called before the first frame update
    void Start()
    {
        menurenderer = GameObject.FindGameObjectWithTag("MENU_RENDERER").GetComponent<MenuRendering>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();

    }

    private void CheckInputs()
    {
        if (selectedFarmPatch != null)
        {
            selectedFarmPatch.GetComponent<FarmPatch>().MouseLeave();
            selectedFarmPatch = null;
        }

        if(selectedConstructionPatch != null)
        {
            selectedConstructionPatch.GetComponent<ConstructionPatch>().MouseLeave();
            selectedConstructionPatch = null;
        }

        // Normal Farming Actions
        if (menurenderer.menuIsOpen == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.tag)
                {
                    case "FARM_PATCH":
                        selectedFarmPatch = hit.transform.gameObject;
                        selectedFarmPatch.GetComponent<FarmPatch>().MouseEnter();
                        break;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (selectedFarmPatch != null && menurenderer.menuIsOpen == false)
                {
                    // open the farm menu
                    menurenderer.OpenFarmMenu(selectedFarmPatch);
                }
            }
        }

        // Construction Actions
        if (menurenderer.menuIsOpen == false && menurenderer.isEditModeEnabled == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.tag)
                {
                    case "CONSTRUCTION_PATCH":
                        selectedConstructionPatch = hit.transform.gameObject;
                        selectedConstructionPatch.GetComponent<ConstructionPatch>().MouseEnter();
                        break;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (selectedConstructionPatch != null && menurenderer.menuIsOpen == false)
                {
                    int posX = Convert.ToInt32(selectedConstructionPatch.transform.position.x);
                    int posY = Convert.ToInt32(selectedConstructionPatch.transform.position.z);


                    // create nomrla farm patch here
                    GameObject.FindGameObjectWithTag("WORLD").GetComponent<World>().CreateNewFarmPatchAt(posX, posY);
                    //Debug.Log("create new farm patch");

                    menurenderer.DisableEditMode();

                }
            }
        }






    }
}
