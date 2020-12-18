using App7;
using Syncfusion.XForms.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace App7
{
    public class GettingStartedViewModel : INotifyPropertyChanged
    {         
        /// <summary>
        /// Current user of chat.
        /// </summary>
        private Author currentAuthor;

        ObservableCollection<MessageModel> messageCollection;

        public GettingStartedViewModel()
        {
            MessageModel messageModel = new MessageModel();          
            this.messageCollection = new ObservableCollection<MessageModel>();        
            this.currentAuthor = new Author() { Name = "Nancy", Avatar = "People_Circle2.png" };
            this.GenerateMessages();
        }
       
        /// <summary>
        /// Gets or sets the collection of messages of a conversation.
        /// </summary>
        public ObservableCollection<MessageModel> MessageCollection
        {
            get
            {
                return this.messageCollection;
            }

            set
            {
                this.messageCollection = value;
                RaisePropertyChanged("messageCollection");
            }
        }       

        /// <summary>
        /// Gets or sets the current user of the message.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.currentAuthor;
            }
            set
            {
                this.currentAuthor = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void GenerateMessages()
        {           
            this.messageCollection.Add(new MessageModel()
            {
                User = currentAuthor,
                Text = "Hi guys, good morning! I'm very delighted to share with you the news that our team is going to launch a new mobile application.",             
            });

            this.messageCollection.Add(new MessageModel()
            {
                User = new Author() { Name = "Andrea", Avatar = "People_Circle7.png" },
                Text = "Oh! That's great.",
            });

            this.messageCollection.Add(new MessageModel()
            {
                User = new Author() { Name = "Harrison", Avatar = "People_Circle5.png" },
                Text = "That is good news.",              
            });           
        }
    }
}
