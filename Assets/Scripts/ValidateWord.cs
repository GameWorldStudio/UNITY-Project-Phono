using UnityEngine;
using UnityEngine.UI;

public class ValidateWord : MonoBehaviour
{
    [HideInInspector] public ChestInterraction chestInterraction;

    public InputField editText;

    public void SetChest(ChestInterraction _chestInterraction)
    {
        chestInterraction = _chestInterraction;
    }

    public void PlaySound()
    {
        chestInterraction.PlaySound();
    }

    public void Validate()
    {
        chestInterraction.Validate(editText.text);
        
    }

    public void Cancel()
    {
        chestInterraction.Cancel();
    }
}
