using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Terminal : Singleton<Terminal>
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _outputText;

    private CommandProcessor _commandProcessor;

    public UnityEvent OnKeyboardStroke;

    private void Start()
    {
        _commandProcessor = new CommandProcessor();
        _commandProcessor.Initialize();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _outputText.text = "";
        
        _inputField.ActivateInputField();
        _inputField.onEndEdit.AddListener(OnInputSubmit);
        
        DisplayOutput("Welcome to KarhuOS 1.1\n");
        DisplayOutput(new TimeCommand().Execute(Array.Empty<string>()));
        DisplayOutput("No updates are available.\n" +
                      "You have 1 unread message. Read it by typing 'messages'.\n");
    }

    private void Update()
    {
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
        {
            OnKeyboardStroke.Invoke();
        }
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

    public void DisplayOutput(string output)
    {
        _outputText.text += output + "\n";
    }
}
