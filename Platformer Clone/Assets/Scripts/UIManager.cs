using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Kelly, Aidan
//10/25/23
//Controls UI

public class UIManager : MonoBehaviour
{
    public TMP_Text healthText;
    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerController.health;
    }
}
