﻿using System.IO;

namespace Domain.Util
{
    public class MailMessages
    {
        #region Style Template
        private const string StyleTemplate = @"
	            *, *::after, *::before {
                    box-sizing: border-box;
                    font-family: ""Open Sans"",sans-serif;
                }
                body, html {
					padding-top: 3%;
                    height: 100%;
                }
                .login {
                    background-color: #364150 !important;
                    height: 100%;
                }
                body {
                    padding: 0 !important;
                    margin: 0 !important;
                    font-size: 14px;
                }
                .col-md-12, .col-md-4{
                    position: relative;
                    min-height: 1px;
                    padding-left: 1.5%;
                    padding-right: 1.5%;
                }
				.col-md-offset-4 {
					margin-left: 20%;
				}
				.col-md-4 {
					width: 60%;
				}
                .text-center {
                    text-align: center;
                    padding-top: 5%;
                }
                .font-white {
                    color: #fff !important;
                }
                .bold {
                    font-weight: 700 !important;
                }
                h3 {
                    font-size: 24px;
                }
                h3 {
                    margin-top: 1%;
                }
                .h3, h3{
                    line-height: 1.1;
                }
                .border-grey-mint {
                    border-color: #525e64 !important;
                }
                hr {
                    border: 0;
                    border-bottom: 0;
                }
                hr, p {
                    margin: 1% 0;
                }
                hr {
                    margin-top: 1%;
                    margin-bottom: 1%;
                    border-top: 1px solid #eee;
                }
                hr {
                    box-sizing: content-box;
                    height: 0;
                }
                .login .logo {
                    margin: 1% auto 0;
                    padding: .1%;
                    text-align: center;
                }
                a, button, code, div, img, p {
                    border-radius: 0 !important;
                }
                img {
                    vertical-align: middle;
                }
                .login .content {
                    background-color: #fff;
                    width: 60%;
                    margin: 3% auto 3%;
                    padding: 1% 3% 3%;
                    overflow: hidden;
                    position: relative;
                }
                .login .content .form-title {
                    margin-bottom: 2%;
                }
                .login .content h3
                {
                    color: #4db3a5;
                    text-align: center;
                    font-size: 28px;
                    font-weight: 400 !important;
                }
                .form-group {
                    margin-bottom: 2%;
                }";
        #endregion

        public string _Path { get; private set; }

        public MailMessages(string path)
        {
            _Path = path;
        }

        public string RegisterMessage(string userName, string password, string host)
        {
            string title = "Registro";
            string template = GetTemplatePage(userName);
            var message = "Seu registro foi efetuado com sucesso.<br/>" +
                        "Acesse nosso <a href=\"" + host + "\">site</a> utilizado seu e-mail e a senha <b>" + password + "</b>";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        public string ForgotPasswordMessage(string userName, string host)
        {
            string title = "Redefinir Senha";
            string template = GetTemplatePage(userName);
            var message = "Foi solicitado a redefinição da sua senha.<br/>" +
                "Acesse nosso <a href=\"" + host + "\">link</a> e siga as instruções para criar nova senha. Lembre-se de definir uma senha com letras maiúsculas," +
                " minúsculas, números e dígitos especiais.";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        public string NewPqrMessage(string userName, string PQR, string revision, string host)
        {
            string title = "Novo RQPS";
            string template = GetTemplatePage(userName);
            var message = "Foi criado o RQPS " + PQR + " revisão " + revision + ".<br/>" +
                "Acesse nosso <a href=\"" + host + "\">site</a> para validá-lo.";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        public string NewWeldingStandardMessage(string weldingStandard)
        {
            string title = "Nova Norma";
            string template = GetTemplatePage();
            var message = "Foi disponibilizada a norma " + weldingStandard + " para a geração de RQPS e EPS.";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        public string NewWeldingProcessMessage(string description, string symbol)
        {
            string title = "Novo Processo de Soldagem";
            string template = GetTemplatePage();
            var message = "Foi disponibilizado o processo de soldagem " + description + " (" + symbol + ") para a geração de RQPS e EPS.";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        public string NewUnitMessage(string description, string symbol)
        {
            string title = "Nova Unidade de Medida";
            string template = GetTemplatePage();
            var message = "Foi disponibilizado a unidade de medida " + description + " (" + symbol + ") para a geração de RQPS e EPS.";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        public string NewPqrMessage(string numberPqr, string revisionPqr)
        {
            string title = "Inclusão de RQPS";
            string template = GetTemplatePage();
            var message = "Foi disponibilizado o RQPS " + numberPqr + " revisão " + revisionPqr + ".";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        public string NewWpsMessage(string numberWps)
        {
            string title = "Inclusão de EPS";
            string template = GetTemplatePage();
            var message = "Foi disponibilizada a EPS " + numberWps + ".";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        public string NewWpsMessage(string userName, string WPS, string host)
        {
            string title = "Nova EPS";
            string template = GetTemplatePage(userName);
            var message = "Foi criada a EPS " + WPS + ".<br/>" +
                "Acesse nosso <a href=\"" + host + "\">site</a> para validá-la.";

            template = template.Replace("{TITLE}", title);
            template = template.Replace("{BODY}", message);
            return template;
        }

        private string GetTemplatePage(string userName = null)
        {
            var template = "";
            using (StreamReader reader = File.OpenText(_Path))
            {
                template = reader.ReadToEnd();
            }
            template = template.Replace("{CSS}", StyleTemplate);
            template = template.Replace("{RECIEVER}", GenerateRecieverText(userName));
            return template;
        }

        private string GenerateRecieverText(string userName = null)
        {
            return userName != null ? "Prezado(a) <strong>" + userName + "</strong>," : "Prezado usuário,";
        }

    }
}
