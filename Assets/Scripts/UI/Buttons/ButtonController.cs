using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonFxSounds;

    [SerializeField]
    private AudioClip hoverSound;

    private void Awake()
    {
        buttonFxSounds = GetComponent<AudioSource>();
        buttonFxSounds.volume = 0.2f;
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
}
