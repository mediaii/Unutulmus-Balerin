using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçişleri için gerekli namespace

public class GameManager : MonoBehaviour
{
    [Header("Ayarlar")]
    [Tooltip("Başlatılacak oyun sahnesinin adı")]
    public string gameSceneName = "GameScene";

    [Header("UI Panelleri")]
    public GameObject optionsPanel; // Seçenekler menüsü paneli

    /// <summary>
    /// Oyunu başlatır veya belirtilen sahneye geçer.
    /// </summary>
    public void PlayGame()
    {
        // Zaman akışını normale döndürür (oyun içi duraklatılmışsa)
        Time.timeScale = 1f;

        // Sahne adı ile yükleme yapar
        SceneManager.LoadScene(gameSceneName);

        // Alternatif: Bir sonraki sahne indeksine göre yüklemek isterseniz:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Seçenekler menüsünü açar veya kapatır.
    /// </summary>
    public void ToggleOptions()
    {
        if (optionsPanel != null)
        {
            bool isActive = optionsPanel.activeSelf;
            optionsPanel.SetActive(!isActive);
        }
        else
        {
            Debug.LogWarning("Options Panel atanmadı!");
        }
    }

    /// <summary>
    /// Oyundan çıkış yapar.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Oyundan çıkıldı."); // Editor üzerinde test ederken konsolda görmek için

#if UNITY_EDITOR
            // Unity Editor içerisinde çalışırken oyunu durdurur
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // Derlenmiş (Build alınmış) oyundan çıkar
        Application.Quit();
#endif
    }
}