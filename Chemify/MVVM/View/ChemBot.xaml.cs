using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chemify.MVVM.View
{
    public partial class ChemBot : UserControl
    {
        private ClientWebSocket _webSocket;
        private const string SystemPrompt = "You are a knowledgeable chemistry professor guiding and mentoring the user through their questions and concerns in a supportive and educational manner. Always answer the user's questions in a short and clear way.";
        private readonly string _chatId = Guid.NewGuid().ToString();
        private bool _receiving = false;

        public ChemBot()
        {
            InitializeComponent();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_receiving && !string.IsNullOrWhiteSpace(UserInput.Text))
            {
                string messageText = UserInput.Text.Trim();
                UserInput.Clear();

                AddMessageToChat("Tu: " + messageText, HorizontalAlignment.Right, "DarkBlue");

                await ConnectWebSocketAsync(messageText);
            }
        }

        private void AddMessageToChat(string message, HorizontalAlignment alignment, string bgColor)
        {
            TextBlock messageBlock = new TextBlock
            {
                Text = message,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(bgColor)),
                Margin = new Thickness(5),
                Padding = new Thickness(10),
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = alignment,
                MaxWidth = ChatHistory.ActualWidth - 20
            };
            ChatHistory.Items.Add(messageBlock);
            ChatHistory.ScrollIntoView(messageBlock);
        }

        private async Task ConnectWebSocketAsync(string message)
        {
            _receiving = true;
            _webSocket = new ClientWebSocket();
            Uri serverUri = new Uri("wss://backend.buildpicoapps.com/api/chatbot/chat");

            try
            {
                await _webSocket.ConnectAsync(serverUri, CancellationToken.None);

                var messageData = new
                {
                    chatId = _chatId,
                    appId = "add-top",
                    systemPrompt = SystemPrompt,
                    message = message
                };
                string messageJson = System.Text.Json.JsonSerializer.Serialize(messageData);
                byte[] messageBytes = Encoding.UTF8.GetBytes(messageJson);
                await _webSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);

                var messageBlock = new TextBlock
                {
                    Text = "ChemBot: ",
                    Background = new SolidColorBrush(Colors.LightYellow),
                    Margin = new Thickness(5),
                    Padding = new Thickness(10),
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    MaxWidth = ChatHistory.ActualWidth - 20
                };
                ChatHistory.Items.Add(messageBlock);

                await ReceiveMessagesAsync(messageBlock);
            }
            catch (Exception ex)
            {
                AddMessageToChat("Error: " + ex.Message, HorizontalAlignment.Left, "Red");
                _receiving = false;
            }
        }

        private async Task ReceiveMessagesAsync(TextBlock messageBlock)
        {
            var buffer = new byte[1024 * 4];
            try
            {
                while (_webSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                        _receiving = false;
                        break;
                    }
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    messageBlock.Text += receivedMessage;
                    ChatHistory.ScrollIntoView(messageBlock);
                }
            }
            catch (Exception ex)
            {
                messageBlock.Text += " Error receiving response from server. " + ex.Message;
                _receiving = false;
            }
        }
    }
}
