using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public bool IsLevelLoading { get; private set; }
    public int CurrentLevel;
    
    public static GameManager Instance;
    [FormerlySerializedAs("_playerDataManager")] [SerializeField] private PlayerDataFetcher playerDataFetcher;
    
    
    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        Instance = this;
        Application.targetFrameRate = 60;
        //GameStateController = new GameFSM(this);
        //DOTween.Init();
        //DataLevel = PlayerDataManager.GetDataLevel();
    }

    
    private void Start()
    {
        //LoadLevel();

        //UiController.Init();
        //MainCamera.Init();
    }
    
    // public void LoadLevel()
    // {
    //     IsLevelLoading = true;
    //     if (CurrentLevel != 0 && SceneManager.sceneCount != 1)
    //         SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
    //     CurrentLevelManager = null;
    //
    //     int buildIndex = getCurrentLevelIndex(DataLevel);
    //     Debug.Log("datalevel is" + DataLevel );
    //     Debug.Log(buildIndex);
    //     if (buildIndex <= 0 || buildIndex >= SceneManager.sceneCountInBuildSettings)
    //     {
    //         //Debug.LogError("No valid scenes found!");
    //         //GameStateController.ChangeState(GameState.LOBBY);
    //         //return;
    //         reverseToFirstLevel(DataLevel);
    //     }
    //
    //     SoundManager.Instance.StopSoundBoxDrag();
    //     SoundManager.Instance.StopSoundEnemyMove();
    //     SoundManager.Instance.StopFootStep();
    //     buildIndex = getCurrentLevelIndex(DataLevel);
    //     SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
    //     uiController.OpenLoading(true);
    // }
}
