using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexusHealthBar : MonoBehaviour
{
    private Image Healthbar;
    [SerializeField]private GameObject Nexus;
    private float maxHealth = 1000f;
    private float healthPercent;
    void Start()
    {
        Healthbar = GetComponent<Image>();
        maxHealth = 1000f;
        healthPercent = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        healthPercent = Nexus.GetComponent<Nexus>().GetNexusHP()/maxHealth;
        Healthbar.fillAmount = healthPercent;
    }
}
