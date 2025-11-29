using UnityEngine;

public class PlayRun : MonoBehaviour
{
    public void PlaySound()
    {
        SoundManager.PlaySound(SoundType.RUN, 0.5f);
    }
}
