using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class QuestSystem : MonoBehaviour
{
    [Header("Quest Settings")]
    [SerializeField] private string questTitle = "Kumpulkan Senjata";
    [SerializeField] private string questDescription = "Kumpulkan 5 buah Senjata dari tentara Jepang";
    [SerializeField] private int totalItemsRequired = 5;
    [SerializeField] private float questHideDelay = 2f;

    [Header("UI References")]
    [SerializeField] private GameObject questPanel;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private GameObject completionPanel;
    [SerializeField] private TMP_Text completionText;
    [SerializeField] private Button closeButton;

    private int currentItemsCollected = 0;
    private bool questCompleted = false;

    void Start()
    {
        InitializeUI();
    }

    void InitializeUI()
    {
        titleText.text = questTitle;
        descriptionText.text = questDescription;
        progressText.text = $"0/{totalItemsRequired}";
        progressSlider.maxValue = totalItemsRequired;
        progressSlider.value = 0;

        questPanel.SetActive(true);
        completionPanel.SetActive(false);

        closeButton.onClick.AddListener(CloseQuestPanel);
    }

    // Hanya satu versi CollectItem yang diperlukan
    public void CollectItem(int amount = 1)
    {
        if (questCompleted) return;

        currentItemsCollected += amount;
        UpdateProgressUI();

        if (currentItemsCollected >= totalItemsRequired)
        {
            CompleteQuest();
        }
    }

    private void UpdateProgressUI()
    {
        progressText.text = $"{currentItemsCollected}/{totalItemsRequired}";
        progressSlider.value = currentItemsCollected;
    }

    private void CompleteQuest()
    {
        questCompleted = true;
        completionText.text = "QUEST SELESAI!";
        completionPanel.SetActive(true);

    }

    public void CloseQuestPanel()
    {
        questPanel.SetActive(false);
        completionPanel.SetActive(false);
    }


}
