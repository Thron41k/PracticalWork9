namespace Task1.UserInput;

/// <summary>
/// Класс для работы с пользовательским вводом.
/// </summary>
public static class UserInput
{
    /// <summary>
    /// Получает целое число из пользовательского ввода.
    /// </summary>
    /// <param name="data">Пользовательский ввод в виде строки.</param>
    /// <param name="min">Минимально допустимое значение.</param>
    /// <param name="max">Максимально допустимое значение.</param>
    /// <returns>Целое число, представляющее пользовательский ввод.</returns>
    /// <exception cref="UserInputException">Выбрасывается, когда ввод данных неверен.</exception>
    public static short Get(string? data, int min, int max)
    {
        // Проверяем, не является ли входная строка пустой или null
        if (string.IsNullOrEmpty(data))
        {
            // Если строка пустая, выбрасываем исключение с сообщением об ошибке
            throw new UserInputException("Входные данные пусты");
        }
        // Пытаемся преобразовать входную строку в целое число
        if (!int.TryParse(data, out var result))
        {
            // Если преобразование не удалось, выбрасываем исключение с сообщением об ошибке
            throw new UserInputException("Входные данные не являются допустимым целым числом");
        }
        // Проверяем, находится ли полученное целое число в допустимом диапазоне
        if (result < min || result > max)
        {
            // Если число вне диапазона, выбрасываем исключение с сообщением об ошибке
            throw new UserInputException($"Значение вне диапазона. Допустимый диапазон от {min} до {max}");
        }
        // Если все проверки пройдены, возвращаем полученное целое число как short
        return (short)result;
    }
}