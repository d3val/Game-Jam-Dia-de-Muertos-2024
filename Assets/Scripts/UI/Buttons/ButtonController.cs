using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonFxSounds;

    [SerializeField]
    private AudioClip hoverSound;
    [SerializeField]
    private Sprite secondSource;
    private Sprite originalSource;
    bool imageSwaper;
    [SerializeField]
    private Image m_image;

    private void Awake()
    {
        buttonFxSounds = GetComponent<AudioSource>();
        buttonFxSounds.volume = 0.2f;
        originalSource = m_image.sprite;
    }

    public void mouseOverFx()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        LeanTween.scale(this.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
        buttonFxSounds.PlayOneShot(hoverSound);
    }
    public void mouseOverFx2(float interval)
    {
        LeanTween.scale(this.gameObject, new Vector3(1.2f, 1.2f, 1.2f), interval).setLoopPingPong();
        buttonFxSounds.PlayOneShot(hoverSound);
    }

    public void mouseExitFx()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, new Vector3(1f, 1f, 1f), 0.1f);
    }

    public void SwapImage()
    {
        if (!imageSwaper)
            m_image.sprite = secondSource;

        else
            m_image.sprite = originalSource;

        imageSwaper = !imageSwaper;

    }
}
