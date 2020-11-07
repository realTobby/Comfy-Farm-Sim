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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            highlightedFarmpatch = hit.transform.gameObject;
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(highlightedFarmpatch != null)
            {
                // open the farm menu
                menurenderer.OpenFarmMenu(highlightedFarmpatch);
            }
        }

        if (highlightedFarmpatch != null)
        {
            highlightedFarmpatch = null;
        }

    }
}
