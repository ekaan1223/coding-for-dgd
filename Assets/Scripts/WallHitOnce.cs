using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WallHitOnce : MonoBehaviour
{
    [SerializeField] private Color hitColor = Color.red;

    private bool alreadyHit;
    private Renderer rend;
    private MaterialPropertyBlock mpb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameOverClip;

    private static readonly int ColorId = Shader.PropertyToID("_Color");
    private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (alreadyHit) return;

        // Find PlayerLives on the object that hit the wall (or its parents).
        PlayerLives player = collision.gameObject.GetComponentInParent<PlayerLives>();
        if (player == null) return;

        // Consume this wall once
        alreadyHit = true;

        // Take 1 life
        player.LoseLife(1);

        // Play game over sound if applicable
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.PlayOneShot(gameOverClip);
        }

        // Change wall color (works with common shaders: _BaseColor (URP) or _Color)
        int prop = rend.sharedMaterial != null && rend.sharedMaterial.HasProperty(BaseColorId)
            ? BaseColorId
            : ColorId;

        rend.GetPropertyBlock(mpb);
        mpb.SetColor(prop, hitColor);
        rend.SetPropertyBlock(mpb);
    }
}
