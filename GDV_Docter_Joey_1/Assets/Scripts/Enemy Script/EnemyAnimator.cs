using UnityEngine;

//made by Joey Docter
//animation for enemy
public class EnemyAnimator : MonoBehaviour
{
    //animations
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void RunAnimation(bool run)
    {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    public void AttackAnimation()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }
}
