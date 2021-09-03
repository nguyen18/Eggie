using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject hungerstat;
    public GameObject happinessstat;
    public GameObject cleanlinessstat;
    public GameObject button;

    public GameObject pet;

    private bool cooldown = false;

    public Animator toolAnimation;

    // Update is called once per frame
    void Update()
    {
        hungerstat.GetComponent<TextMeshProUGUI>().text = "" + pet.GetComponent<PetManager>()._hunger;
        happinessstat.GetComponent<TextMeshProUGUI>().text = "" + pet.GetComponent<PetManager>()._happiness;
        cleanlinessstat.GetComponent<TextMeshProUGUI>().text = "" + pet.GetComponent<PetManager>()._cleanliness;
    }

    public void ButtonCoolDown()
    {
        if (cooldown == false)
        {
            GetComponent<Button>().interactable = false;
            //toolAnimation.SetTrigger("Inactive");
            Invoke("ResetCooldown", 10.0f);
            cooldown = true;
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
        //toolAnimation.SetTrigger("Active");
        GetComponent<Button>().interactable = true;
    }

}
