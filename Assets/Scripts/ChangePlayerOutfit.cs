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
            playerCostume.gameObject.SetActive(false);
            playerCostume.sprite = null; // Remove the costume sprite
        }
        else
        {
            playerCostume.gameObject.SetActive(true); // Show the costume sprite
            playerCostume.sprite = newCostume.sprite;
            Debug.Log("Costume changed to: " + isEquippedCostume);
        } // Change the costume sprite
    }

    public void ChangeHat(Image newHat)
    {
        if (newHat == null)
        {
            playerHat.GameObject().SetActive(false);
            playerHat.sprite = null; // Remove the hat sprite
        }
        else
        {
            playerHat.GameObject().SetActive(true); // Show the hat sprite
            playerHat.sprite = newHat.sprite;
            Debug.Log("Hat changed to: " + isEquippedHat);
        }
    }

    public void ChangeModel(Image newModel)
    {
        playerModel.sprite = newModel.sprite; // Change the model sprite
    }

    public void ChangeFace(Image newFace)
    {
        playerFace.sprite = newFace.sprite; // Change the face sprite
    }

}