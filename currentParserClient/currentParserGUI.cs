using static currentParserClient.Client;

namespace currentParserClient
{
    public partial class currentParserGUI : Form
    {
        public currentParserGUI()
        {
            InitializeComponent();
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.sendMessage(currentTextbox.Text, "CURRENT");

            currentStringTextbox.Text = client.receiveMessage();

            client.deleteSocket();
        }
    }
}
