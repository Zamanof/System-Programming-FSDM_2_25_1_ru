namespace SP_02._Threads_in_UI_App;

public partial class Form1 : Form
{
    static int count = 0;
    static int colorCounter = 0;
    public Form1()
    {
        InitializeComponent();
        timer1.Tick += Counter;

    }
    private void Counter(object sender, EventArgs args)
    {
        countLabel.Text = count.ToString();
        count++;
    }

    private void startButton_Click(object sender, EventArgs e)
    {
        timer1.Start();
        //Thread thread = new Thread(() =>
        //{
        //    countLabel.Text = "0";
        //    startButton.Enabled = false;
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(1000);
        //        countLabel.Text = i.ToString();
        //    }
        //    startButton.Enabled = true;
        //});
        //thread.IsBackground = true;
        //thread.Start();

    }

    private void changeBgButton_Click(object sender, EventArgs e)
    {
        if (colorCounter % 3 == 0) this.BackColor = Color.Aqua;
        else if (colorCounter % 3 == 1) this.BackColor = Color.Red;
        else this.BackColor = Color.Blue;
        colorCounter++;
    }
}
