using System;
using System.Net;
using System.Net.Mail;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logon.Registration
{
    public class Registration : MonoBehaviour
    {
        private int _emailConfirmCode  = 0;
        private Canvas _parentCanvas;
        
        [SerializeField]
        private TMP_InputField tmpEmail;
        
        [SerializeField]
        private TMP_InputField tmpLogin;
        
        [SerializeField]
        private TMP_InputField tmpPass;
        
        [SerializeField]
        private TMP_InputField tmpPassSecond;
        
        [SerializeField]
        private TMP_InputField tmpCode;
        
        [SerializeField]
        private TMP_Text tmpLabel;

        [SerializeField]
        private GameObject emailConfirmPanel;

        private const string BUSY_EMAIL_OR_LOGIN = "Ошибка регистрации! Проверьте почту или логин...";
        private const string PASSES_DONT_MATCH = "Ошибка регистрации! Проверьте пароли...";
        private const string INVALIDE_CODE = "Неправильный код!";
        private const string SUCSESS_REG = "Регистрация прошла успешно...";

        public void TryRegistration() 
        {
            tmpLabel.text = string.Empty;
            if (EmailAndLoginValidate(tmpEmail.text, tmpLogin.text))
            {
                if (IsPasswordMatchSecondPassword(tmpPass.text, tmpPassSecond.text))
                {
                    _emailConfirmCode = SendEmailCode();
                    emailConfirmPanel.SetActive(true);
                }
                else
                {
                    RegistrationStatusChanged(PASSES_DONT_MATCH);
                }
            }
            else
            {
                RegistrationStatusChanged(BUSY_EMAIL_OR_LOGIN);
            }
        }

        public void CloseWindow()
        {
            ClearEverything();
            _parentCanvas.enabled = true;
        }

        private void CreateAccount(string email, string login, string pass) //TODO: Создать аккаунт в БД
        {
            RegistrationStatusChanged(SUCSESS_REG);
        }

        #region Методы валидации почты
        public void TryEmailConfirm() //TODO: Проверка кода на почте (по кнопке)
        {
            if (_emailConfirmCode == int.Parse(tmpCode.text))
            {
                emailConfirmPanel.SetActive(false);
                CreateAccount(tmpEmail.text, tmpLogin.text, tmpPass.text);
            }
            else
            {
                RegistrationStatusChanged(INVALIDE_CODE);  
            }

        }
        
        private int SendEmailCode() //TODO: Система отправки кода
        {
            int code = 1000;
           
            return code;
        }
        #endregion

        #region Методы валидации введённых данных
        private bool EmailAndLoginValidate(string email, string login) //Проверка, не занят ли логин/емаил в БД
        {
            if (email.Length != 0 && login.Length != 0)
            {
                return true; //TODO: ПРОВЕРКА В БД ВОТ ТУТ
            }
            else
            {
                return false;
            }
        }

        private bool IsPasswordMatchSecondPassword(string firstPass, string secondPass)
        {
            if (firstPass.Length != 0 && secondPass.Length != 0)
            {
                return firstPass == secondPass;
            }
            else
            {
                return false;
            }
            
        }
        #endregion
        
        #region Вспомогательные методы
        private void RegistrationStatusChanged(string msg)
        {
            tmpPass.text = string.Empty;
            tmpPassSecond.text = string.Empty;
            tmpLabel.text = msg;
        }

        private void ClearEverything()
        {
            _emailConfirmCode = 0;
            tmpLabel.text = string.Empty;
            tmpEmail.text = string.Empty;
            tmpLogin.text = string.Empty;
            tmpPass.text = string.Empty;
            tmpPassSecond.text = string.Empty;
            tmpCode.text = string.Empty;
        }

        public void SetParentCanvas(Canvas canvas)
        {
            _parentCanvas = canvas;
        }
        #endregion

    }
}
