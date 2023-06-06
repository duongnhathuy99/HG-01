using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtnArtifact : MonoBehaviour
{
    Button artifactBtn;
    Transform menuSelectArtifact;
    ArtifactSO artifactSO;
    [SerializeField] Image imageArtifact;
    TextMeshProUGUI textName;
    TextMeshProUGUI textDetail;
    Player player;
    private void Awake()
    {
        artifactBtn = transform.GetComponent<Button>();
        menuSelectArtifact = transform.parent.GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        textName = transform.Find("NameArtifact").GetComponent<TextMeshProUGUI>();
        textDetail = transform.Find("DetailArtifact").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        artifactBtn.onClick.AddListener(OnClick);
    }
    private void OnEnable()
    {
        artifactSO = menuSelectArtifact.GetComponent<MenuSelectArtifact>().GetArtifactRandom();
        imageArtifact.sprite = artifactSO.sprite;
        textName.text = artifactSO.name;
        textDetail.text = artifactSO.detail;
    }
    void OnClick()
    {
        player.GetArtifact(artifactSO);
        menuSelectArtifact.GetComponent<MenuSelectArtifact>().artifacts.Remove(artifactSO);
        Time.timeScale = 1;
        menuSelectArtifact.gameObject.SetActive(false);
    }
}
