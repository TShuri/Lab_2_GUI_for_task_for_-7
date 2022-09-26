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
            string[] strNumbers = inLine.Split(" "); // ��������� ������ �� �����
            Properties.Settings.Default.inLine = inLine;
            Properties.Settings.Default.Save(); // ��������� ���������� ��������

            int[] numbers = new int[strNumbers.Length]; // �������� int ������� ��� �����

            for (int i = 0; i < (strNumbers.Length); i++) // �������������� str ����� � int �
            {                                             // ���������� int ������� ����� �������
                try // ���� � ������������������ ���� �����, �� ������� ������
                {
                    numbers[i] = int.Parse(strNumbers[i]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("�� ��� ����� � ������������������?", "Oh Shit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show(Logic.Check(numbers));
        }
    }
    public class Logic
    {
        public static string Check(int[] _numbers)
        {
            string outMessage = "������������������ �����������"; // ��������� �� ���������
            for (int i = 0; i < (_numbers.Length) - 1; i++) // �������� ��������������� ����
            {
                if (_numbers[i] >= _numbers[i + 1]) // ���� ������� ����� �� ������ ����������,
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