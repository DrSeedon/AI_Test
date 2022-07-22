using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleStateManager : MonoBehaviour
{
    private AppleBaseState currentState;
    
    public AppleGrowingState GrowingState = new AppleGrowingState();
    public AppleRottenState RottenState = new AppleRottenState();
    public AppleWholeState WholeState = new AppleWholeState();
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = GrowingState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AppleBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
