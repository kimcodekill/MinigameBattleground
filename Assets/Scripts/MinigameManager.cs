using TMPro;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private Minigame minigamePrefab;
    [SerializeField] private GameObject introPanel;
    [SerializeField] private GameObject gameParent;
    [SerializeField] private MeshFilter titleMeshFilter;
    [SerializeField] private TextMeshProUGUI descriptionLabel;
    
    private Camera _camera;

    public bool IsPlaying { get; private set; }

    private void Awake()
    {
        _camera = Camera.main;
        titleMeshFilter.mesh = minigamePrefab.TitleMesh;
        descriptionLabel.text = minigamePrefab.Description;
    }

    void Update()
    {
        if (!IsPlaying)
            CheckStart();
    }

    private void CheckStart()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.name.Equals("btn_play"))
                {
                    StartMinigame();
                }
            }
        }
    }

    [ContextMenu("Start Minigame")]
    private void StartMinigame()
    {
        IsPlaying = true;
        introPanel.SetActive(false);
        Instantiate(minigamePrefab, gameParent.transform.position, Quaternion.identity);
    }
}
