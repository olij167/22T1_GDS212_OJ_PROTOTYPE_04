using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PilgrimUI : MonoBehaviour
{
    public Slider physicalStatBar, mentalStatBar, spiritualStatBar, socialStatBar;
    //public Slider physicalStatFill, mentalStatFill, spiritualStatFill, socialStatFill;

    public PilgrimAI selectedPilgrim;

    public SpawnPilgrim spawn;

    public TextMeshProUGUI pilgrimName, pilgrimResolution;


    // Start is called before the first frame update
    void Awake()
    {
        //selectedPilgrim = spawn.pilgrimList[0].GetComponent<PilgrimAI>();
        //UpdatePilgrimUI();
    }

    // Update is called once per frame
    void Update()
    {
       if (selectedPilgrim == null)
        {
            physicalStatBar.gameObject.SetActive(false);
            mentalStatBar.gameObject.SetActive(false);
            spiritualStatBar.gameObject.SetActive(false);
            socialStatBar.gameObject.SetActive(false);
            pilgrimName.gameObject.SetActive(false);
            pilgrimResolution.gameObject.SetActive(false);
        }
        else
        {
            physicalStatBar.gameObject.SetActive(true);
            mentalStatBar.gameObject.SetActive(true);
            spiritualStatBar.gameObject.SetActive(true);
            socialStatBar.gameObject.SetActive(true);
            pilgrimName.gameObject.SetActive(true);
            pilgrimResolution.gameObject.SetActive(true);
        }
    }

    //public void UpdatePilgrimUI()
    //{
    //    pilgrimName.text = selectedPilgrim.firstName + " " + selectedPilgrim.lastName;
    //    pilgrimResolution.text = "Resolution: " + selectedPilgrim.resolution;

    //    physicalStatBar.fillAmount = Mathf.Clamp01(selectedPilgrim.physicalStat / selectedPilgrim.maxPhysicalStat);

    //    mentalStatBar.fillAmount = Mathf.Clamp01(selectedPilgrim.mentalStat / selectedPilgrim.maxMentalStat);

    //    spiritualStatBar.fillAmount = Mathf.Clamp01(selectedPilgrim.spiritualStat / selectedPilgrim.maxSpiritualStat);

    //    socialStatBar.fillAmount = Mathf.Clamp01(selectedPilgrim.socialStat / selectedPilgrim.maxSocialStat);
    //}

    public void UpdatePilgrimUI()
    {
        UpdateName();
        UpdatePhysicalStatBar();
        UpdateMentalStatBar();
        UpdateSpiritualStatBar();
        UpdateSocialStatBar();

    }

    public void UpdateName()
    {
        pilgrimName.text = selectedPilgrim.firstName + " " + selectedPilgrim.lastName;
        pilgrimResolution.text = "Resolution: " + selectedPilgrim.statToEnrich;
    }

    public void UpdatePhysicalStatBar()
    {
        physicalStatBar.value = Mathf.Clamp(selectedPilgrim.physicalStat / selectedPilgrim.maxPhysicalStat, 0f, 1f);
    }
    public void UpdateMentalStatBar()
    {
        mentalStatBar.value = Mathf.Clamp(selectedPilgrim.mentalStat / selectedPilgrim.maxMentalStat, 0f, 1f);

    }
    public void UpdateSpiritualStatBar()
    {
        spiritualStatBar.value = Mathf.Clamp(selectedPilgrim.spiritualStat / selectedPilgrim.maxSpiritualStat, 0f, 1f);

    }
    public void UpdateSocialStatBar()
    {
        socialStatBar.value = Mathf.Clamp(selectedPilgrim.socialStat / selectedPilgrim.maxSocialStat, 0f, 1f);

    }


}
