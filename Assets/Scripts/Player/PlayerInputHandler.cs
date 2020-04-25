using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using btnNames = Dictionary.InputButtonNames;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerAnimatorHandler animator;

    private void Start()
    {
        animator = GetComponent<PlayerAnimatorHandler>();
    }

    void handleMeleeAttack()
    {
        if(CrossPlatformInputManager.GetButtonDown(btnNames.ATTACK))
        {
            GetComponent<MeleeAttackHandler>().attack();
        }    
    }
    void Update()
    {
        handleMeleeAttack();
    }
}
