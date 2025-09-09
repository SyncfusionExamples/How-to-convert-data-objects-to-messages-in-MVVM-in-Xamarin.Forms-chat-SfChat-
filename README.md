# How-to-convert-data-objects-to-messages-in-MVVM-in-Xamarin.Forms-chat-SfChat
Describes data binding in Xamarin.Forms Chat(SfChat) using ItemsSource and ItemsSourceConverter property for using existing data collections as message collection in SfChat

## Sample

```xaml

    <ContentPage.Resources>
        <ResourceDictionary>
            <local:AuthorColorConverter x:Name="authorColorConverter" x:Key="authorColorConverter" />

            <!--Defining outgoing message author color-->
            <Style TargetType="sfChat:OutgoingMessageAuthorView">
                <Setter Property="ControlTemplate">
                    <Setter.Value>
                        <ControlTemplate>
                            <Label Text="{Binding Author.Name}" BackgroundColor="Transparent" TextColor="{TemplateBinding BindingContext, Converter= {StaticResource authorColorConverter},ConverterParameter={x:Reference viewModel}}" BindingContext="{TemplateBinding BindingContext}"/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>

            <!--Defining incoming message author color-->
            <Style TargetType="sfChat:IncomingMessageAuthorView">
                <Setter Property="ControlTemplate">
                    <Setter.Value>
                        <ControlTemplate>
                            <Label Text="{Binding Author.Name}" BackgroundColor="Transparent" TextColor="{TemplateBinding BindingContext, Converter= {StaticResource authorColorConverter},ConverterParameter={x:Reference viewModel}}" BindingContext="{TemplateBinding BindingContext}"/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ResourceDictionary>
    </ContentPage.Resources>

MessageConverter:

    public class MessageConverter : IChatMessageConverter
    {
        /// <summary>
        /// Converts given data object to a chat message.
        /// </summary>
        /// <param name="data">The data object to be converted as a chat message.</param>
        /// <param name="chat">Instance of <see cref="SfChat"/>. </param>
        /// <returns>Returns the data object as a chat message.</returns>
        public IMessage ConvertToChatMessage(object data, SfChat chat)
        {
            var message = new TextMessage();
            var item = data as MessageModel;

            message.Text = item.Text;
            message.Author = item.User;
            message.Data = item;
            if (item.Suggestions != null)
            {
                message.Suggestions = item.Suggestions;
            }
            return message;
        }

        /// <summary>
        /// Converts the given chat message to a data object.
        /// </summary>
        /// <param name="chatMessage">The chat message that is to be converted as a data object.</param>
        /// <param name="chat">Instance of <see cref="SfChat"/>. </param>
        /// <returns>Returns the chat message as a data object.</returns>
        public object ConvertToData(object chatMessage, SfChat chat)
        {
            var message = new MessageModel();
            var item = chatMessage as TextMessage;

            message.Text = item.Text;
            message.User = chat.CurrentUser;
            if (message.Suggestions != null)
            {
                message.Suggestions = chat.Suggestions;
            }
            return message;
        }
    }

```
## Requirements to run the demo

To run the demo, refer to [System Requirements for Xamarin](https://help.syncfusion.com/xamarin/system-requirements)

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
