using Assets.Scripts.UI;
using Packages.SceneLoading.Runtime.Loaders;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MainSceneScripts
{
    public class MainMenuScript : MonoBehaviour
    {
        public Button startButton;
        public GameObject labels;
        public SmoothProgressBar progressBar;

        public MainSceneLoader loader;

        void Start()
        {
            labels.gameObject.SetActive(true);
            startButton.gameObject.SetActive(true);
            progressBar.gameObject.SetActive(false);

            startButton.onClick.AddListener(OnStartButtonClick);
            progressBar.onComplete.AddListener(OnLoadingBarFilled);
        }
        
        private void OnStartButtonClick()
        {
            startButton.gameObject.SetActive(false);
            labels.gameObject.SetActive(false);
            progressBar.gameObject.SetActive(true);

            loader.Preload();
        }

        private void OnLoadingBarFilled()
        {
            loader.Activate();
        }

        void OnDestroy()
        {
            startButton.onClick.RemoveListener(OnStartButtonClick);
            progressBar.onComplete.RemoveListener(OnLoadingBarFilled);
        }
    }
}