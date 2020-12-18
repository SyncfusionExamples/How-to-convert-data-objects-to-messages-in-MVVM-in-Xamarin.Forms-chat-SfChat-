using Syncfusion.XForms.Chat;
using System;

namespace App7
{
    public class MessageModel
    {
        public MessageModel()
        {
        }

        public ChatSuggestions Suggestions { get; set; }         
        public Author User { get; set; }
        public string Text { get; set; }
    }
}

