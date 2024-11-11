namespace Task2;

/// <summary>
/// Класс для управления списком фамилий.
/// </summary>
internal class SortList
{
    // Это приватный список строк для хранения фамилий.
    private readonly List<string> _surnames = [];

    /// <summary>
    /// Событие, которое вызывается при сортировке списка фамилий.
    /// </summary>
    public event EventHandler? SortEvent;

    /// <summary>
    /// Добавляет фамилию в список.
    /// </summary>
    /// <param name="surname">Фамилия для добавления.</param>
    public void AddSurname(string surname)
    {
        // Добавляет фамилию в список.
        _surnames.Add(surname);
    }

    /// <summary>
    /// Сортирует список фамилий.
    /// </summary>
    /// <param name="sortType">Тип сортировки. 1 для сортировки по возрастанию, 2 для сортировки по убыванию.</param>
    public void Sort(int sortType)
    {
        // Выбирает тип сортировки с помощью оператора switch.
        switch (sortType)
        {
            // Если sortType равен 1, сортирует список по возрастанию.
            case 1:
                _surnames.Sort();
                break;
            // Если sortType равен 2, сортирует список по убыванию.
            case 2:
                _surnames.Sort((a, b) => string.Compare(b, a, StringComparison.Ordinal));
                break;
        }

        // Вызывает событие SortEvent, если есть подписчики.
        SortEvent?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Выводит список фамилий в консоль.
    /// </summary>
    public void PrintSurnames()
    {
        // Выводит заголовок списка фамилий в консоль.
        Console.WriteLine("Список фамилий:");

        // Вывод списка фамилий
        Console.Write("\t");
        Console.WriteLine(string.Join("\n\t", _surnames));
        Console.WriteLine();
    }
}