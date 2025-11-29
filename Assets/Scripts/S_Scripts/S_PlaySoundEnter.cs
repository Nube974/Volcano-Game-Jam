using UnityEngine;

public class S_PlaySoundEnter: StateMachineBehaviour
{
    [SerializeField] private SoundType sound;
    [SerializeField, Range(0, 1)] private float volume = 1;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        S_SoundManager.PlaySound(sound, volume);
    }
}
