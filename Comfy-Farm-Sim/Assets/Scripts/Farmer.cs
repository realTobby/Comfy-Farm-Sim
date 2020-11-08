using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    MenuRendering menurenderer;

    GameObject highlightedFarmpatch;


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
        if (highlightedFarmpatch != null)
        {
            highlightedFarmpatch.GetComponent<FarmPatchBehaviour>().MouseLeave();
            highlightedFarmpatch = null;
        }

        

        if(menurenderer.menuIsOpen == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.tag)
                {
                    case "FARM_PATCH":
                        highlightedFarmpatch = hit.transform.gameObject;
                        highlightedFarmpatch.GetComponent<FarmPatchBehaviour>().MouseEnter();
                        break;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (highlightedFarmpatch != null && menurenderer.menuIsOpen == false)
                {
                    // open the farm menu
                    menurenderer.OpenFarmMenu(highlightedFarmpatch);
                }
            }
        }
        
    }
}
