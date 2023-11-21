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

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                Client client = new Client();
                client.sendMessage(currentTextbox.Text, "CURRENT");

                currentStringTextbox.Text = client.receiveMessage();

                client.deleteSocket();
            }
        }

    }
}
