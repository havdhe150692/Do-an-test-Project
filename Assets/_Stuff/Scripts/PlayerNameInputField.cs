
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    private const string playerNamePrefKey = "PlayerName";

    private void Start()
    {
        var defaultName = string.Empty;
        var _inputField = GetComponent<InputField>();
        if (_inputField != null)
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }

    }

    
    public void SetPlayerName(string value)
    {
        // #Important
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }



        PlayerPrefs.SetString(playerNamePrefKey, value);
    }

}