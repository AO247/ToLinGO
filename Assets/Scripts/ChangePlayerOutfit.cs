using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerOutfit : MonoBehaviour
{
    public GameObject playerCostume;
    public GameObject playerHat; // Image component to show the product
    public GameObject playerModel;
    public GameObject playerFace;
    public bool isEquippedHat = false;
    public bool isEquippedCostume = false;

    public void ChangeCostume(Sprite newCostume)
    {
        if (newCostume == null)
        {
            playerCostume.GameObject().SetActive(false);
            //playerCostume = null; // Remove the costume sprite
        }
        else
        {
             // Show the costume sprite
            playerCostume.GetComponent<SpriteRenderer>().sprite = newCostume;
            playerCostume.GameObject().SetActive(true);
            Debug.Log("Costume changed to: " + isEquippedCostume);
        } // Change the costume sprite
    }

    public void ChangeHat(Sprite newHat)
    {
        if (newHat == null)
        {
            playerHat.GameObject().SetActive(false);
            //playerHat = null; // Remove the hat sprite
        }
        else
        {
            playerHat.GetComponent<SpriteRenderer>().sprite = newHat;
            playerHat.GameObject().SetActive(true);
            Debug.Log("Hat changed to: " + isEquippedHat);
        }
    }

    public void ChangeModel(Sprite newModel)
    {
        playerModel.GetComponent<SpriteRenderer>().sprite = newModel; // Change the model sprite
    }

    public void ChangeFace(Sprite newFace)
    {
        playerFace.GetComponent<SpriteRenderer>().sprite = newFace; // Change the face sprite
    }

}