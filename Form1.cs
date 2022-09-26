namespace lab2_2_GUI_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // ��������� �������� �� ��������
            txt_inLine.Text = Properties.Settings.Default.inLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inLine = txt_inLine.Text; // �������� ������������������ � ���� ������
            Properties.Settings.Default.inLine = inLine;
            Properties.Settings.Default.Save(); // ��������� ���������� ��������
            string message = Logic.Check(inLine);
            if (message != "Error") // ���� ������� �� ������� ������, �� 
            {                       // ������� �����
                MessageBox.Show(message);
            }
        }
    }
    public class Logic
    {
        public static string Check(string line)
        {
            // ������ ������
            string[] strNumbers = line.Split(" "); // ��������� ������ �� �����
            int[] numbers = new int[strNumbers.Length]; // �������� int ������� ��� �����

            for (int i = 0; i < (strNumbers.Length); i++) // �������������� str ����� � int �
            {                                             // ���������� int ������� ����� �������
                try // ���� � ������������������ ���� �����, �� ������� ������
                {
                    numbers[i] = int.Parse(strNumbers[i]);
                }
                catch(FormatException)
                {
                    MessageBox.Show("�� ��� ����� � ������������������?", "Oh Shit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
            }

            string outMessage = "������������������ �����������"; // ��������� �� ���������
            for (int i = 0; i < (numbers.Length) - 1; i++) // �������� ��������������� ����
            {
                if (numbers[i] >= numbers[i + 1]) // ���� ������� ����� �� ������ ����������,
                {                                 // �� �������� ���������
                    outMessage = "������������������ �� �����������";
                    break;
                }
            }

            return outMessage;
            // ����� ������
        }
    }
}