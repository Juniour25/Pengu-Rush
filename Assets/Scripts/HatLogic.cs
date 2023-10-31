using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatLogic : MonoBehaviour
{
    [SerializeField] private Transform hatContainer;
    private List<GameObject> hatModels = new List<GameObject>();
    private Hat[] hats;
    private string selectedHatKey="SelctedHatIndex";

    private void Start()
    {
        hats = Resources.LoadAll<Hat>("Hat");
        SpawnHats();
        int selectedHatIndex=PlayerPrefs.GetInt(selectedHatKey,1);
        
        SelectHat(selectedHatIndex);
    }

    private void SpawnHats()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hatModels.Add(Instantiate(hats[i].Model, hatContainer) as GameObject);
        }
    }

    public void DisableAllHats()
    {
        for (int i = 0; i < hatModels.Count; i++)
        {
            hatModels[i].SetActive(false);
        }
    }

    public void SelectHat(int index)
    {
        DisableAllHats();
        hatModels[index].SetActive(true);
        PlayerPrefs.SetInt(selectedHatKey,index);
        
    }
    

}
