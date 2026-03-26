using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWaterManager : MonoBehaviour
{
    public float currentWater;
    public float maxWater;
    public float waterLoseRate=5f;
    public Slider waterSlider;
    public float passiveLossRate = 2f;
    public int starCount = 0;
    public CupData currentCup;
    public ParticleSystem waterSplashEffect;
    public ParticleSystem passiveDripEffect;
    public CupData[] allCups;
    public Transform waterObject;
    public float waterStartScaleY;

    void Start()
    {
        string equipedName = PlayerPrefs.GetString("EquipedCup", "cup_normal");
        for (int i = 0; i < allCups.Length; i++)
        {
            if (allCups[i].cupName == equipedName)
            {
                currentCup = allCups[i];
                break;
            }
        }
        if (currentCup != null)
        {
            maxWater = currentCup.waterCapacity;
            currentWater = maxWater;
            passiveLossRate = passiveLossRate * currentCup.passiveLossMultiplier;
            waterSlider.maxValue = maxWater;
            waterSlider.value = currentWater;
        }

        if (waterObject != null)
        {
            waterStartScaleY = waterObject.localScale.y;
        }
    }

    void Update(){
        if (GameManager.instance.currentState != GameManager.GameState.Playing)
        {
            return;
        }
        waterSlider.value = currentWater;
        currentWater -= passiveLossRate * Time.deltaTime;

        if (currentWater <= 0f)
        {
            GameManager.instance.ChangeState(GameManager.GameState.GameOver);
            UIManager.instance.ShowFailPanel();
            currentWater = 0f;
        }

        if (GameManager.instance.currentState == GameManager.GameState.Playing && currentWater > 0)
        {
            if (passiveDripEffect.isPlaying == false)
            {
                passiveDripEffect.Play();
            }
        }
        else { passiveDripEffect.Stop(); }

        if (waterObject != null)
        {
            float fillAmount = currentWater / maxWater;
            waterObject.localScale = new Vector3(waterObject.localScale.x, waterStartScaleY * fillAmount, waterObject.localScale.z);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (waterSplashEffect != null)
            {
                waterSplashEffect.Play();
                AudioManager.instance.PlaySFX(AudioManager.instance.sfxHit);
                AudioManager.instance.PlaySFX(AudioManager.instance.sfxSplash);
                Debug.Log("Water is splashing.");
            }
        }
    }

    public void OnCollisionStay(Collision collision){
        if(collision.gameObject.CompareTag("Obstacle")){
            ObstacleStats obstacleStats=collision.gameObject.GetComponent<ObstacleStats>();

            if(obstacleStats!=null){
                currentWater-=obstacleStats.damageRate*Time.deltaTime;
                PlayerMovement.instance.forwardSpeed=0f;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerMovement.instance.forwardSpeed = 5f;
            waterSplashEffect.Stop();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish Line");
            GameManager.instance.ChangeState(GameManager.GameState.LevelComplete);
            GameManager.instance.CalculateStars(maxWater, currentWater);
            UIManager.instance.ShowCompletePanel(GameManager.instance.earnedStar);
            PlayerMovement.instance.forwardSpeed = 0f;
            TreeManager.instance.GrowTree(currentWater);
        }
    }
}
