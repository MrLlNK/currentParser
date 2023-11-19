using static currentParserClient.Client;

namespace currentParserClient
{
    public partial class currentParserGUI : Form
    {
        Client client;

        public currentParserGUI()
        {
            InitializeComponent();
            try
            {
                client = new Client();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            client.sendMessage(currentTextBox.Text);

            currentStringTextbox.Text = client.receiveMessage();
        }
    }
}
