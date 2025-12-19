using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip gameStartClip;

    public int Lives { get; private set; }
    public bool IsGameOver => Lives <= 0;

    private void Start()
    {
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.PlayOneShot(gameStartClip);
        }
    }
    private void Awake()
    {
        Lives = maxLives;
        Debug.Log($"Lives: {Lives}");

        
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void LoseLife(int amount = 1)
    {
        if (IsGameOver) return;

        Lives = Mathf.Max(Lives - amount, 0);
        Debug.Log($"Lives: {Lives}");

        if (Lives == 0)
        {
            if (audioSource != null && gameOverClip != null)
            {
                audioSource.PlayOneShot(gameOverClip);
            }

            Debug.Log("GAME OVER");
            // Minimal “game over”: stop time
            Time.timeScale = 0f;
        }
    }
}
