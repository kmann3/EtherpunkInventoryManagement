using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtherpunkInventoryManagement.Models
{

    public class MessageModel
    {
        public List<MessageModel> MessageList = new List<MessageModel>();

        public string Title { get; set; }
        public string Message { get; set; }
        public CssClassType CssClassName { get; set; }
        public bool EndPageProcessing { get; set; }

        public enum CssClassType
        {
            Primary,
            Secondar,
            Success,
            Danger,
            Warning,
            Info,
            Light,
            Dark
        }
    }
}
