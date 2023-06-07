using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtnArtifact : MonoBehaviour
{
    Button artifactBtn;
    MenuSelectArtifact menuSelectArtifact;
    ArtifactSO artifactSO;
    Image imageArtifact;
    TextMeshProUGUI textName;
    TextMeshProUGUI textDetail;
    Player player;
    private void Awake()
    {
        artifactBtn = transform.GetComponent<Button>();
        menuSelectArtifact = transform.parent.GetComponent<MenuSelectArtifact>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        textName = transform.Find("NameArtifact").GetComponent<TextMeshProUGUI>();
        textDetail = transform.Find("DetailArtifact").GetComponent<TextMeshProUGUI>();
        imageArtifact= transform.Find("ImageArtifact").GetComponent<Image>();
    }
    private void Start()
    {
        artifactBtn.onClick.AddListener(OnClick);
    }
    private void OnEnable()
    {
        artifactSO = menuSelectArtifact.GetArtifactRandom();
        imageArtifact.sprite = artifactSO.sprite;
        textName.text = artifactSO.name;
        textDetail.text = artifactSO.detail;
    }
    void OnClick()
    {
        if (menuSelectArtifact.listArtifact.Contains(artifactSO))
        {
            player.GetArtifact(artifactSO);
            menuSelectArtifact.listArtifact.Remove(artifactSO);
        }

        menuSelectArtifact.ResetArtifactI();
        Time.timeScale = 1;
        menuSelectArtifact.gameObject.SetActive(false);
    }
}
