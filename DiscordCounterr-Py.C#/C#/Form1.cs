using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;
using System.Diagnostics;

namespace DiscordCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int last_count = 0;
        private int count = 0;
        private DateTime last_message_time = DateTime.Now;
        private long last_message = 0;


        private void button1_Click(object sender, EventArgs e)
        {

            var start_time = DateTime.Now;
            last_message_time = DateTime.Now;

            int next_message_number = 0;

            var options = new ChromeOptions();
            options.AddArgument("--disable-extensions");

            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://discord.com/login");
            Thread.Sleep(1000);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var username_field = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("email")));
            var password_field = driver.FindElement(By.Name("password"));

            if (string.IsNullOrEmpty(textEmail.Text))
            {
                MessageBox.Show("Je bent je email vergeten in te vullen!");
                return;
            }
            username_field.SendKeys(textEmail.Text);

            if (string.IsNullOrEmpty(textWw.Text))
            {
                MessageBox.Show("Je bent je wachtwoord vergeten in te vullen!");
                return;
            }
            password_field.SendKeys(textWw.Text);

            password_field.SendKeys(Keys.Return);
            Thread.Sleep(1000);

            last_count = 0;

            if (string.IsNullOrEmpty(textChannel.Text))
            {
                MessageBox.Show("Je bent vergeten het kanaal op te geven!");
                return;
            }

            if (string.IsNullOrEmpty(textUsername.Text))
            {
                MessageBox.Show("Je bent je naam vergeten in te vullen!");
                return;
            }

            driver.Navigate().GoToUrl(textChannel.Text);
            Thread.Sleep(10000);

            var message_box = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'inner')]/div[contains(@class,'textArea')]//div[@role='textbox']")));
            last_message = 0;
            count = 0;

            try
            {
                while (true)
                {
                    try
                    {
                        var warning_elements = driver.FindElements(By.XPath("//img[contains(@src, '/assets/2896') and @class='emoji']//ancestor::li//div[contains(@class, 'messageContent')]"));
                        long? warning_id = null;
                        if (warning_elements.Count > 0)
                        {
                            var warning_element = warning_elements.Last();
                            var warning_id_string = warning_element.GetAttribute("id");
                            warning_id_string = warning_id_string.Replace("message-content-", "");
                            warning_id = long.Parse(warning_id_string);
                        }

                        var alle_vinkjes = driver.FindElements(By.XPath("//img[(contains(@src, '/assets/86c16c3') or contains(@src, '/assets/212e30e') or contains(@src, '/assets/db009c8') or contains(@src, '/assets/d23c2dd')) and @class='emoji']//ancestor::li//div[contains(@class, 'messageContent')]"));
                        if (alle_vinkjes.Count == 0)
                        {
                            Debug.WriteLine("niks gevonden");
                        }
                        else
                        {
                            string? gebruiker = null;
                            var laatste_vinkje = alle_vinkjes.Last();
                            var laatste_vinkje_id = laatste_vinkje.GetAttribute("id");
                            laatste_vinkje_id = laatste_vinkje_id.Replace("message-content-", "");
                            var laatste_vinkje_id_int = long.Parse(laatste_vinkje_id);

                            if (warning_id != null && warning_id > laatste_vinkje_id_int)
                            {
                                Debug.WriteLine("laatste was fout");
                                last_message = 0;
                            }
                            else
                            {
                                Debug.WriteLine("Laatste: " + laatste_vinkje.Text);
                                gebruiker = laatste_vinkje.FindElement(By.XPath("./..//span[contains(@class, 'username')]")).Text;
                                Debug.WriteLine(gebruiker);
                            }

                            if (gebruiker != textUsername.Text)
                            {
                                next_message_number = (int.Parse(laatste_vinkje.Text) + 1);
                            }

                            if (next_message_number >= last_message + 2)
                            {
                                SendMessage(message_box, next_message_number, start_time);
                            }
                            else
                            {
                                var timeSinceLastMessage = DateTime.Now - last_message_time;
                                if (timeSinceLastMessage.TotalSeconds >= 4)
                                {
                                    var messageContents = driver.FindElements(By.XPath("//div[contains(@id, 'message-content-')]"));
                                    var lastElement = messageContents.LastOrDefault();
                                    if (lastElement != null)
                                    {
                                        var lastMessage = lastElement.Text;
                                        var lastUser = lastElement.FindElement((By.XPath("./..//span[contains(@class, 'username')]")))?.Text;
                                        Debug.WriteLine($"Last message: {lastMessage}");
                                        Debug.WriteLine($"Last user: {lastUser}");
                                        if (int.TryParse(lastMessage, out var number) && number >= last_message && lastUser != null && !lastUser.Contains(textUsername.Text))
                                        {
                                            SendMessage(message_box, number + 1, start_time);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Exception occurred: " + ex.Message);
                        Debug.WriteLine(ex.StackTrace);
                    }
                }
            }
            finally
            {
                driver.Quit();
            }
        }

        private void SendMessage(IWebElement message_box, int number, DateTime start_time)
        {
            message_box.SendKeys(number.ToString());
            message_box.SendKeys(Keys.Return);
            last_message = number;
            last_message_time = DateTime.Now;
            count++;

            if (count % 10 == 0)
            {
                var random_delay = new Random().NextDouble() * (7.5 - 0) + 0;
                Thread.Sleep(TimeSpan.FromSeconds(random_delay));
            }
            else
            {
                var random_delay = new Random().NextDouble() * (2.25 - 0) + 0;
                Thread.Sleep(TimeSpan.FromSeconds(random_delay));
            }

            if (count % 100 == 0)
            {
                var current_time = DateTime.Now;
                var time_elapsed = current_time - start_time;
                var count_since_last = count - last_count;
                last_count = count;
                using (StreamWriter sw = File.AppendText("stats.txt"))
                {
                    sw.WriteLine($"Count: {count}, Time Elapsed: {time_elapsed}, Count Since Last: {count_since_last}");
                }
            }
            else
            {
                Thread.Sleep(500);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}