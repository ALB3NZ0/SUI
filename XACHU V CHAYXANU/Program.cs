using System.Globalization;
namespace Notebook
{
    class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Note(string title, string description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
        }
    }
    class Program
    {
        public static List<Note> notes = new List<Note>();
        static void Main(string[] args)
        {
            notes.Add(new Note("Заметка №1", "Сходить в военкомат", new DateTime(2023, 10, 17)));
            notes.Add(new Note("Заметка №2", "Изучить основы SQL", new DateTime(2023, 10, 18)));
            notes.Add(new Note("Заметка №3", "Проснуться на пары", new DateTime(2023, 10, 19)));
            notes.Add(new Note("Заметка №4", "Сходить на тренировку", new DateTime(2023, 10, 20)));
            notes.Add(new Note("Заметка №5", "Помочь отцу перестроить дом", new DateTime(2023, 10, 21)));
            int cur_index = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(notes[cur_index].Title);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Нажмите Enter для полной информации или используйте стрелки влево и вправо для переключения");
                Console.WriteLine("Для добавления новой заметки нажмите клавишу Q");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (cur_index > 0)
                        cur_index--;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (cur_index < notes.Count - 1)
                        cur_index++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Название: " + notes[cur_index].Title);
                    Console.WriteLine("Описание: " + notes[cur_index].Description);
                    Console.WriteLine("Дата: " + notes[cur_index].Date.ToString("dd.MM.yyyy"));
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    Console.Clear();
                    Console.WriteLine("Введите название заметки:");
                    string Title = Console.ReadLine();
                    Console.WriteLine("Введите описание заметки:");
                    string Description = Console.ReadLine();
                    Console.WriteLine("Введите дату заметки (в формате dd.mm.yyyy):");
                    string Date = Console.ReadLine();
                    if (DateTime.TryParseExact(Date, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime date))
                    {
                        notes.Add(new Note(Title, Description, date));
                        Console.WriteLine("Заметка добавлена!");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода даты, заметка не добавлена");
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();


                }
            }
        }
    }
}