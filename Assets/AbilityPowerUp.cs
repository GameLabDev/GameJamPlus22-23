using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AbilityPowerUp : MonoBehaviour
{
    public int abilityIdx;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<InputManager>(out InputManager inpM))
        {
            switch (abilityIdx)
            {
                case 1:
                    inpM.fireballAbility.ResetTimeUsing();
                    DOVirtual.DelayedCall(0.1f, () =>
                    {
                        inpM.dashAbility.SetTimeUsing();
                    });
                    
                    break;
                case 2:
                    inpM.dashAbility.ResetTimeUsing();
                    DOVirtual.DelayedCall(0.1f, () =>
                    {
                        inpM.fireballAbility.SetTimeUsing();
                    });
                    
                    break;
            }
            Destroy(this.gameObject);
        }
        
    }
}
