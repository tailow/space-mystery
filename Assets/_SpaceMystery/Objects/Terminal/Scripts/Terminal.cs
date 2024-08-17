using TMPro;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _outputText;

    private CommandProcessor _commandProcessor;

    private void Start()
    {
        _commandProcessor = new CommandProcessor();
        _commandProcessor.Initialize();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _outputText.text = "";
        
        _inputField.ActivateInputField();
        _inputField.onEndEdit.AddListener(OnInputSubmit);
    }

    private void OnInputSubmit(string input)
    {
        _inputField.ActivateInputField();
        
        if (_inputField.wasCanceled) return;
        if (string.IsNullOrWhiteSpace(input)) return;

        _inputField.text = "";

        DisplayOutput("> " + input);
        
        string output = _commandProcessor.ProcessCommand(input);
        
        DisplayOutput(output);
    }

    private void DisplayOutput(string output)
    {
        _outputText.text += output + "\n";
    }
}
