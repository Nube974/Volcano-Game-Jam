using UnityEngine;

public class S_PlayRun : MonoBehaviour
{
    public void PlaySound()
    {
        S_SoundManager.PlaySound(SoundType.RUN, 0.5f);
    }
}
