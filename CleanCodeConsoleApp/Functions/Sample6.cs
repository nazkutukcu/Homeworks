using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// "Name the functions with what they do" prensibi, bir fonksiyonun adının, ne yaptığını hemen neredeyse %100 
    /// anlamanızı sağlamak için doğru ve eksiksiz olması gerektiğini savunur.
    /// 
    /// Fonksiyonun adını okuyarak tam olarak ne iş yaptığını anlayamazsak,bu karmaşaya neden olur.
    /// </summary>
   
    public class NotificationBase
    {
        protected string _to;
        protected string _files;
        protected string _body;

        protected void SendMessage(string to, string files, string body)
        {
            // Mesaj gönderme işlemleri...
        }
    }


    //BAD
    public class BadSlackNotification : NotificationBase
    {
        //...

        //Handle methodu bir mesajın işlemi mi yoksa dosyada yapılan bir işlem mi?
        public void Handle()
        {
            SendMessage(this._to, this._files, this._body);
        }
    }


    //GOOD
    public class GoodSlackNotification : NotificationBase
    {
        //...
        public void Send()
        {
            // Method Slack mesajının gönderilmesini sağladığı anlaşılıyor.

            SendMessage(this._to, this._files, this._body);
        }
    }
}
