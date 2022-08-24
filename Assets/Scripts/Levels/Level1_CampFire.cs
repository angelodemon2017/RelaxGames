using System.Collections;
using UnityEngine;

public class Level1_CampFire : MonoBehaviour
{
    public ParticleSystem particleSystemFire;
    private ParticleSystem.EmissionModule emissionModule;
    public GameObject LabelHelp;

    public int PowerFire = 0;
    public readonly int limit = 30;

    void Start()
    {
        if (DataController.data != null)
        {
            PowerFire = DataController.data.datas[0].CurrentCounter;
            PanelButtonLevel.changeLevel += EndScene;
        }
        emissionModule = particleSystemFire.emission;
        UpdateParticles();
        StartCoroutine(Timer());
    }

    private void OnMouseUp()
    {
        if (PowerFire < limit)
        {
            PowerFire++;
            Currencies.AddCoins(1);
            UpdateParticles();
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        if (PowerFire > 0) 
        {
            PowerFire--;
            UpdateParticles();
        }
        StartCoroutine(Timer());
    }

    public void EndScene()
    {
        if (DataController.data != null)
        {
            DataController.data.datas[0].CurrentCounter = PowerFire;
        }
        PanelButtonLevel.changeLevel -= EndScene;
    }

    private void UpdateParticles() 
    {
        LabelHelp.SetActive(PowerFire < 10);
        emissionModule.rateOverTime = PowerFire < 30 ? PowerFire : limit;
        particleSystemFire.startLifetime = PowerFire < limit ? ((float)PowerFire) / 10f : 3f;
    }
}