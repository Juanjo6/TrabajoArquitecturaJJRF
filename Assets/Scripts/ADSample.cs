using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class ADSample : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    string _gameId;
    [SerializeField] bool _testMode = true; // Si son los de verdad o para las pruebas
    public Text myText; // Para textos de ayuda. Se puede quitar

    private void Awake()
    {
        myText.text = "el anuncio no se ha cargado";
        if (Advertisement.isInitialized)
        {

            Debug.Log("Advertisement is Initialized");
            //LoadRewardedAd();
        }
        else
        {
            InitializeAds();
        }
    }
    public void InitializeAds()
    {   // Carga el id de la plataforma dependiendo si el id es ios o android y el playmode correspondiente
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);

    }

    public void OnInitializationComplete()
    {  // Se llama cuando el anuncio se ha cargado completamente (con conexión a internet)
        myText.text = "el anuncio se ha cargado";
        Debug.Log("Unity Ads initialization complete.");
        // LoadInerstitialAd();
        // LoadBannerAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {  // Para mostrar qué pasa si lo se ha inicializado correctamente
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void LoadInerstitialAd()
    {
        //Esta funcion carga un Inertitial(una pantalla de anuncio) (no es video, no hay recompensa)
        Advertisement.Load("Interstitial_Android", this);
    }

    public void LoadRewardedAd()
    {
        //Esta funcion carga un video con recompensa
        Advertisement.Load("Rewarded_Android", this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("OnUnityAdsAdLoaded");
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowStart");
        Time.timeScale = 0;
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        // Si se ha visto en anuncio entero
        Debug.Log("OnUnityAdsShowComplete " + showCompletionState);
        if (placementId.Equals("Rewarded_Android") && UnityAdsShowCompletionState.COMPLETED.Equals(showCompletionState))
        {
            //Esta condicion sirve para que cuando el anuncio se ha visto al completo recompensemos al jugador;
            Debug.Log("Recompensamos al jugador");
        }
        Time.timeScale = 1;

    }



    public void LoadBannerAd()
    {

        //Esta funcion carga un Banner
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);//podemos determinar la posicion del banner cambiando.Botton_center
        // Poniendo un punto después de BOTTOM_CENTER
        Advertisement.Banner.Load("Banner_Android",
            new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            }
            );
    }

    void OnBannerLoaded()
    {
        Advertisement.Banner.Show("Banner_Android");
    }

    void OnBannerError(string message)
    {

    }

}