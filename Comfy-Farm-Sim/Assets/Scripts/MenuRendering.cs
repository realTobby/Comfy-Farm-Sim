using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRendering : MonoBehaviour
{
    private GameObject selectedFarmPatch;

    public GameObject farmMenuPopup;

    private PrefabCollection prefabList;

    // Start is called before the first frame update
    void Start()
    {
        prefabList = GameObject.FindGameObjectWithTag("PREFAB_LIST").GetComponent<PrefabCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFarmMenu(GameObject clickedFarmPatch)
    {
        selectedFarmPatch = clickedFarmPatch;
        farmMenuPopup.SetActive(true);
    }

    public void CloseFarmMenu()
    {
        farmMenuPopup.SetActive(false);
    }

    public void PlantTree()
    {
        GameObject newPlant = Instantiate(prefabList.treePrefab, selectedFarmPatch.transform.position, Quaternion.identity);
        CloseFarmMenu();
    }

}
