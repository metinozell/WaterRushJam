using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI totalStarsText;

    void Start()
    {
        int wallet = PlayerPrefs.GetInt("TotalStars", 0);
        totalStarsText.text = wallet.ToString();
    }
    public void StartGame()
    {
        int nextLevelIndex = PlayerPrefs.GetInt("CurrentLevel", 1);
        SceneManager.LoadScene(nextLevelIndex);
    }
    public void BuyOrEquipCup(CupData currentCup)
    {
        int lockState = 0;
        if (currentCup.isUnlocked == true) { lockState = 1; }
        else { lockState = PlayerPrefs.GetInt(currentCup.cupName, 0); }

        if (lockState == 1)
        {
            PlayerPrefs.SetString("EquipedCup", currentCup.cupName);
            Debug.Log(currentCup.cupName + " kuşanildi.");
        }
        else
        {
            int wallet = PlayerPrefs.GetInt("TotalStars", 0);
            if (wallet >= currentCup.unlockCost)
            {
                wallet = wallet - currentCup.unlockCost;
                PlayerPrefs.SetInt("TotalStars", wallet);
                totalStarsText.text = wallet.ToString();
                PlayerPrefs.SetInt(currentCup.cupName, 1);
                PlayerPrefs.SetString("EquipedCup", currentCup.cupName);
                PlayerPrefs.Save();
                Debug.Log("Satin alindi ve kusanildi.");
            }
            else
            {
                Debug.Log("Yetersiz yildiz. Gereken: " + currentCup.unlockCost);
            }
        }
    }
}
