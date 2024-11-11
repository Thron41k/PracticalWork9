using Task1.UserInput;
using Task2;

// Создаем экземпляр класса SortList
var sortList = new SortList();

// Добавляем фамилии в список
sortList.AddSurname("Иванов");
sortList.AddSurname("Петров");
sortList.AddSurname("Сидоров");
sortList.AddSurname("Кузнецов");
sortList.AddSurname("Михайлов");

// Объявляем делегат события для обработки события сортировки
sortList.SortEvent += (_, _) =>
{
    Console.WriteLine("Список отсортирован!");
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
        Console.WriteLine();
        Console.WriteLine();

        // Вызываем метод Get, который преобразует пользовательский ввод в тип сортировки
        var sortType = UserInput.Get(input, 1, 2);

        // Выполняем сортировку
        sortList.Sort(sortType);
    }
    catch (Exception e)
    {
        // Обработка ошибок
        Console.WriteLine(e);
    }
    finally
    {
        // Возвращаем курсор в исходную позицию
        Console.SetCursorPosition(startPosition.Left, startPosition.Top);
    }
} while (input != "exit");// Продолжаем цикл, пока пользователь не введёт "exit"
return;

// Метод WriteHeader выводит заголовок программы
void WriteHeader()
{
    // Устанавливаем курсор в начало строки и очищаем консоль
    Console.SetCursorPosition(0, 0);
    Console.Clear();

    // Выводим список фамилий
    sortList.PrintSurnames();

    // Выводим приглашение для ввода типа сортировки
    Console.Write("Введите 1 для сортировки А-Я или 2 для сортировки Я-А (или 'exit' для выхода): ");
}