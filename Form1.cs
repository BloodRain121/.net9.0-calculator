namespace Calculator;

public partial class Form1 : Form
{
    private System.ComponentModel.IContainer components = null;
    
    public int one; // первое число
    public int two; // второе число
    public string sign; // знак операции
    public int result; // результат вычислений
    
    // Обьявляем поля для элементов формы/окна
    private TextBox firstNumber;
    private TextBox secondNumber;
    private TextBox signChar;
    private TextBox resultTextBox;
    private Button resultButton;
    
    public Form1()
    {
        components = new System.ComponentModel.Container();
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Text = "Calculator"; // Задаём название окна
        
        firstNumber = new System.Windows.Forms.TextBox();
        secondNumber = new System.Windows.Forms.TextBox();
        secondNumber.Location = new Point(300, 0); // Задаём расположение второго текстового поля
        signChar = new System.Windows.Forms.TextBox();
        signChar.Location = new Point(150, 0); // Задаём расположение поля для знака операции
        resultTextBox = new System.Windows.Forms.TextBox();
        resultTextBox.Location = new Point(450, 0); // Задаём расположение поля с результатом операции
        resultTextBox.ReadOnly = true; // Запрещаем пользователю редактировать текстовое поле с результатом
        resultButton = new System.Windows.Forms.Button();
        resultButton.Location = new Point(600, 0); // Задаём расположение кнопки результата
        resultButton.Click += new System.EventHandler(resultButton_Click); // Добавляем метод евента нажатия на кнопку
        
        //Добавляем текстовые поля и кнопку
        Controls.Add(firstNumber);
        Controls.Add(secondNumber);
        Controls.Add(signChar);
        Controls.Add(resultTextBox);
        Controls.Add(resultButton);
    }
    
    public void resultButton_Click(object sender, EventArgs e)
    {
        // Получаем значения из текстовых полей
        if (!int.TryParse(firstNumber.Text, out one))
        {
            MessageBox.Show("Некорректный ввод в первом числе.");
            return; // Выходим из метода, если преобразование не удалось
        }

        if (!int.TryParse(secondNumber.Text, out two))
        {
            MessageBox.Show("Некорректный ввод во втором числе.");
            return; // Выходим из метода, если преобразование не удалось
        }

        sign = signChar.Text; // Получаем знак операции

        // Выполняем вычисления
        switch (sign)
        {
            case "+":
                result = one + two;
                break;
            case "-":
                result = one - two;
                break;
            case "*":
                result = one * two;
                break;
            case "/":
                if (two == 0)
                {
                    MessageBox.Show("Деление на ноль!");
                    result = 0; // Задаем значение по умолчанию
                }
                else
                {
                    result = one / two;
                }
                break;
            default:
                MessageBox.Show("Некорректный знак операции.");
                result = 0; // Задаем значение по умолчанию
                break;
        }

        // Обновляем поле результата
        resultTextBox.Text = result.ToString();
    }
}