using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{

    [SerializeField] TextMeshProUGUI countdown;
    TextMeshProUGUI reload;
    [SerializeField] TextMeshProUGUI enemiesLeft;
    [SerializeField] TextMeshProUGUI wavesLeft;
    [SerializeField] int timeLeft = 10;

    [SerializeField] Sprite[] HeartSprites;

    bool winCase;

    [SerializeField] Image HeartUI;
	private PlayerManager myPlayer;
    ProjectileManager mManager;
    EnemyManager mEnemyManager;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine("LoseTime");
		myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        mManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        mEnemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        Time.timeScale = 1;
        winCase = false;
	}
	
	// Update is called once per frame
	private void Update () 
    {
		HeartUI.sprite = HeartSprites[(int)myPlayer.GetHealth() / 10];
        countdown.text = ("" + timeLeft);
        enemiesLeft.text = ("" + mEnemyManager.GetEnemyCount());
        //getFinal wave + 1 - get current wave gives the waves left
        if(mEnemyManager.GetWaves() <= mEnemyManager.getFinalWaveCount())
        {
            wavesLeft.text = ("" + mEnemyManager.GetWaves());

        }
        ChangeTimeColor();
        ResetTime();
    }
    
    private void ChangeTimeColor()
    {
        switch (timeLeft)
        {
            case 10:
                countdown.color = Color.green;
                break;
            case 6:
                countdown.color = Color.yellow;
                break;
            case 3:
                countdown.color = Color.red;
                break;
            default:
                break;

        }
    }

    private void ResetTime()
    {
        if (timeLeft < 0)
        {
            mManager.SetDone(true);
            timeLeft = 10;
        }
    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;

        }
    }



    public int GetTimeLeft()
    {
        return timeLeft;
    }

    public void setWinCase(bool other)
    {
        winCase = other;
    }
}
