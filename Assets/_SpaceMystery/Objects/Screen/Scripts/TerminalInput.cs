using TMPro;
using UnityEngine;

public class TerminalInput : MonoBehaviour
{
    private TMP_InputField _inputField;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        _inputField = GetComponent<TMP_InputField>();
        
        _inputField.ActivateInputField();
    }

    public void SendCommand()
    {
        Debug.Log(_inputField.text);

        _inputField.text = "";
        
        _inputField.ActivateInputField();
    }
}
