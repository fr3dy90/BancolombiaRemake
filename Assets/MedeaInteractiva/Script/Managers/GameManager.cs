using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private FadeController _fadeController;
    [SerializeField] private ScenesNames _currentScene;
    public bool isDebug = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        _fadeController.HardController(FadeController._one, () => LoaderScenes(_currentScene));
    }
    
    private void LoaderScenes(ScenesNames _sceneName)
    {
        if (OnCheckScene(_sceneName))
        {
            return;
        }
        SceneManager.LoadSceneAsync(_sceneName.ToString(), LoadSceneMode.Additive);
    }
    
    private void OnSceneLoaded(Scene _scene, LoadSceneMode _mode)
    {
        switch (_scene.name)
        {
            case "GameManager":
                break;
            case "LogicScene":
                LoaderScenes(ScenesNames.GraphicScene);
                SceneManager.SetActiveScene(_scene);
                break;
            case "GraphicScene":
                _fadeController.FadeIn(OnLaunchExperience);
                break;
        }
    }
    
    private bool OnCheckScene(ScenesNames _sceneName)
    {
        return SceneManager.GetSceneByName(_sceneName.ToString()).isLoaded;
    }

    private void OnLaunchExperience()
    {
        //Lanzar la experiencia
    }
}

public enum ScenesNames
{
    GameManager,
    LogicScene,
    GraphicScene
}

