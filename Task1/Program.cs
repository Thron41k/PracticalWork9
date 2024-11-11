using Task1.UserInput;

// Создаём массив исключений, которые будут использоваться в программе
var exceptions = new Exception[]
{
    new TimeoutException("Время ожидания истекло"),
    new IndexOutOfRangeException("Индекс за пределами массива"),
    new UserInputException("Неверное значение пользовательского ввода"),
    new DivideByZeroException("Деление на ноль"),
    new InvalidOperationException("Недопустимая операция"),
};

// Выводим заголовок
WriteHeader();

// Запоминаем текущую позицию курсора
var startPosition = Console.GetCursorPosition();

// Инициализируем переменную input, которая будет хранить пользовательский ввод
var input = "";

// Начинаем цикл, который будет продолжаться, пока пользователь не введёт "exit"
do
{
    try
    {
        // Получаем ввод пользователя
        input = Console.ReadLine();

        // Выводим заголовок
        WriteHeader();

        // Выводим пустую строку, чтобы отделить заголовок
        Console.WriteLine();
        Console.WriteLine();

        // Вызываем метод Get, который преобразует пользовательский ввод в индекс исключения
        var exceptionIndex = UserInput.Get(input, 0, exceptions.Length - 1);

        // Выбрасываем исключение по индексу, полученному из пользовательского ввода
        throw exceptions[exceptionIndex];
    }
    catch (Exception e)
    {
        // Если исключение было выброшено, выводим его сообщение в консоль
        Console.WriteLine(e);
    }
    finally
    {
        // Возвращаем курсор в исходную позицию
        Console.SetCursorPosition(startPosition.Left, startPosition.Top);
    }
} while (!string.Equals(input, "exit"));// Продолжаем цикл, пока пользователь не введёт "exit"

return;

// Метод WriteHeader выводит заголовок программы
void WriteHeader()
{
    // Устанавливаем курсор в начало строки и очищаем консоль
    Console.SetCursorPosition(0, 0);
    Console.Clear();

    // Создаём строку, которая будет содержать список исключений
    var exceptionsString = string.Join(Environment.NewLine, exceptions.Select((exception, index) =>
        $"\t {index}. {exception.GetType().Name} {exception.Message}"));

    // Выводим заголовок программы
    Console.WriteLine("Доступные исключения:");
    Console.WriteLine(exceptionsString);

    // Выводим приглашение для ввода индекса исключения
    Console.Write("Введите индекс исключения (или 'exit' для выхода): ");
}