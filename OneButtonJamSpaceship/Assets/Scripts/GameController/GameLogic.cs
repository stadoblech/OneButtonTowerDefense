using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public int startAmountOfCredits;
    public int costForBuldingTower;
    public int rewardForKill;

    public int maxCoreIntegrity;
    public int coreDamageHit;


    public Text coreIntegrityText;
    public Text creditsText;

    public string retrySceneName;
    public string nextSceneName;

    public int actualAmountOfCredits
    {
        get; set;
    }

    public int actualAmountOfCore
    {
        get;set;
    }

    public static string actualSceneName;

	void Start () {
        actualSceneName = SceneManager.GetActiveScene().name;
        actualAmountOfCore = maxCoreIntegrity;
        actualAmountOfCredits = startAmountOfCredits;
    }
	
	// Update is called once per frame
	void Update () {
        creditsText.text = actualAmountOfCredits.ToString();
        coreIntegrityText.text = getCoreIntegrity().ToString();
        if(getCoreIntegrity() <= 0)
        {
            SceneManager.LoadScene(retrySceneName);
        }
    }

    public void getRewardForEnemyDestroy()
    {
        actualAmountOfCredits += rewardForKill;
    }

    public void getCoreHit()
    {
        actualAmountOfCore -= coreDamageHit;
    }

    public int getCoreIntegrity()
    {
        if(maxCoreIntegrity == 0)
        {
            return 0;
        }
        float onePercent = 100f / (float)maxCoreIntegrity;
        return (int)(onePercent * actualAmountOfCore);
    }

    public void endRound()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
