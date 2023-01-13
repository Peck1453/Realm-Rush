using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 500;
    [SerializeField] int currentBalance;
    public int CurrentBalance{get{return currentBalance;}}
    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake()
        {
            currentBalance = startingBalance;
            UpdateDisplay();
        }
    // Start is called before the first frame update
    public void Deposit(int amount)
        {
            currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
        }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currentBalance <0)
        {
            //lose game
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = $"Gold: {currentBalance}";
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
