using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PilgrimUI : MonoBehaviour
{
    public Slider physicalStatBar, mentalStatBar, spiritualStatBar, socialStatBar;
    public TextMeshProUGUI physicalStatValue, mentalStatValue, spiritualStatValue, socialStatValue;

    public PilgrimAI selectedPilgrim;

    public SpawnPilgrim spawn;

    public EndOfTrailTrigger end;

    public TextMeshProUGUI pilgrimName, pilgrimResolution, pilgrimEffectOnScoreText;

    float pilgrimScoreEffectOnTotal, pilgrimResolutionStat, totalScore;


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
        UpdateEffectOnScore();

    }

    public void UpdateName()
    {
        pilgrimName.text = selectedPilgrim.firstName + " " + selectedPilgrim.lastName;
        pilgrimResolution.text = "Resolution: " + selectedPilgrim.statToEnrich;
    }

    public void UpdatePhysicalStatBar()
    {
        physicalStatBar.value = Mathf.Clamp(selectedPilgrim.physicalStat / selectedPilgrim.maxPhysicalStat, 0f, 1f);
        //physicalStatValue.text = physicalStatBar.value.ToString("P");
        float valueStringFormat = physicalStatBar.value * 100;
        physicalStatValue.text = valueStringFormat.ToString("00");
    }
    public void UpdateMentalStatBar()
    {
        mentalStatBar.value = Mathf.Clamp(selectedPilgrim.mentalStat / selectedPilgrim.maxMentalStat, 0f, 1f);
        //mentalStatValue.text = mentalStatBar.value.ToString("P");
        float valueStringFormat = mentalStatBar.value * 100;
        mentalStatValue.text = valueStringFormat.ToString("00");


    }
    public void UpdateSpiritualStatBar()
    {
        spiritualStatBar.value = Mathf.Clamp(selectedPilgrim.spiritualStat / selectedPilgrim.maxSpiritualStat, 0f, 1f);
        //spiritualStatValue.text = spiritualStatBar.value.ToString("P");
        float valueStringFormat = spiritualStatBar.value * 100;
        spiritualStatValue.text = valueStringFormat.ToString("00");


    }
    public void UpdateSocialStatBar()
    {
        socialStatBar.value = Mathf.Clamp(selectedPilgrim.socialStat / selectedPilgrim.maxSocialStat, 0f, 1f);
        float valueStringFormat = socialStatBar.value * 100;
        socialStatValue.text = valueStringFormat.ToString("00");


    }

    public void UpdateEffectOnScore()
    {
        

        if (end.numOfPilgrimsFinished <= 0)
        {
            pilgrimScoreEffectOnTotal = GetResolutionStat(pilgrimResolutionStat);
        }
        else pilgrimScoreEffectOnTotal = (end.totalScore + GetResolutionStat(pilgrimResolutionStat)) / (end.numOfPilgrimsFinished + 1) - (totalScore / end.numOfPilgrimsFinished);
        

        //Debug.Log("total score = " + totalScore);
        //Debug.Log("pilgrims finished = " + numOfPilgrims);

        Debug.Log("pilgrim effect on score = " + pilgrimScoreEffectOnTotal);

        pilgrimEffectOnScoreText.text = pilgrimScoreEffectOnTotal.ToString("00");

        
    }

    public float GetResolutionStat(float pilgrimMainStat)
    {
        switch (selectedPilgrim.statToEnrich)
        {
            case "Physical":
                {
                    pilgrimMainStat = selectedPilgrim.physicalStat;
                    break;
                }
            case "Mental":
                {
                    pilgrimMainStat = selectedPilgrim.mentalStat;
                    break;
                }
            case "Social":
                {
                    pilgrimMainStat = selectedPilgrim.socialStat;
                    break;
                }
            case "Spiritual":
                {
                    pilgrimMainStat = selectedPilgrim.spiritualStat;
                    break;
                }
        }

        Debug.Log(pilgrimMainStat);

        return pilgrimMainStat;
    }


}
