namespace lab2_2_GUI_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Считываем значения из настроек
            txt_inLine.Text = Properties.Settings.Default.inLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inLine = txt_inLine.Text; // Получаем последовательность в виде строки
            Properties.Settings.Default.inLine = inLine;
            Properties.Settings.Default.Save(); // Сохраняем переданные значения
            string message = Logic.Check(inLine);
            if (message != "Error") // Если функция не вернула ошибку, то 
            {                       // выводим ответ
                MessageBox.Show(message);
            }
        }
    }
    public class Logic
    {
        public static string Check(string line)
        {
            // НАЧАЛО логики
            string[] strNumbers = line.Split(" "); // Разбиение строки на числа
            int[] numbers = new int[strNumbers.Length]; // Создание int массива для чисел

            for (int i = 0; i < (strNumbers.Length); i++) // Преобразование str числа в int и
            {                                             // заполнение int массива этими числами
                try // Если в последовательности есть буква, то выводим ошибку
                {
                    numbers[i] = int.Parse(strNumbers[i]);
                }
                catch(FormatException)
                {
                    MessageBox.Show("Ты ввёл буквы в последовательность?", "Oh Shit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
            }

            string outMessage = "Последовательность упорядочена"; // Сообщение по умолчанию
            for (int i = 0; i < (numbers.Length) - 1; i++) // Проверка упорядоченности ряда
            {
                if (numbers[i] >= numbers[i + 1]) // Если текущее число не меньше следующего,
                {                                 // то меняется сообщение
                    outMessage = "Последовательность не упорядочена";
                    break;
                }
            }

            return outMessage;
            // КОНЕЦ логики
        }
    }
}