using UnityEngine;
using UnityEngine.Events;

public class PasswordLock : MonoBehaviour
{
    [SerializeField]
    private string m_ExpectedPassword;
    [SerializeField]
    private UnityEvent m_OnPasswordCorrect;
    [SerializeField]
    private UnityEvent<string> m_OnCurrentPasswordChange;

    private string m_CurrentPassword = "";

    public void EnterPasswordText(string text)
    {
        if (m_CurrentPassword.Length < m_ExpectedPassword.Length)
        {
            m_CurrentPassword += text;
            m_OnCurrentPasswordChange?.Invoke(m_CurrentPassword);
            CheckPassword();
        }
    }

    public void ResetPassword()
    {
        m_CurrentPassword = "";
        m_OnCurrentPasswordChange?.Invoke(m_CurrentPassword);
    }

    private void CheckPassword()
    {
        if (m_CurrentPassword == m_ExpectedPassword)
        {
            m_OnPasswordCorrect?.Invoke();
        }
        else if(m_CurrentPassword.Length == m_ExpectedPassword.Length)
        {
            ResetPassword();
        }
    }
}
