
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerOutfit : MonoBehaviour
{
    public Image playerCostume;
    public Image playerHat; // Image component to show the product
    public Image playerModel;
    public Image playerFace;
    public bool isEquippedHat = false;
    public bool isEquippedCostume = false;

    public void ChangeCostume(Image newCostume)
    {
        if (newCostume == null)
        {
            playerCostume.GameObject().SetActive(false);
            //playerCostume = null; // Remove the costume sprite
        }
        else
        {
             // Show the costume sprite
            playerCostume.GetComponent<Image>().sprite = newCostume.sprite;
            playerCostume.GameObject().SetActive(true);
            Debug.Log("Costume changed to: " + isEquippedCostume);
        } // Change the costume sprite
    }

    public void ChangeHat(Image newHat)
    {
        if (newHat == null)
        {
            playerHat.GameObject().SetActive(false);
            //playerHat = null; // Remove the hat sprite
        }
        else
        {
            playerHat.GetComponent<Image>().sprite = newHat.sprite;
            playerHat.GameObject().SetActive(true);
            Debug.Log("Hat changed to: " + isEquippedHat);
        }
    }

    public void ChangeModel(Image newModel)
    {
        playerModel.GetComponent<Image>().sprite = newModel.sprite; // Change the model sprite
    }

    public void ChangeFace(Image newFace)
    {
        playerFace.GetComponent<Image>().sprite = newFace.sprite; // Change the face sprite
    }

}