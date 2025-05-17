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
        playerCostume.sprite = newCostume.sprite; // Change the costume sprite
    }

    public void ChangeHat(Image newHat)
    {
        playerHat.sprite = newHat.sprite; // Change the hat sprite
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