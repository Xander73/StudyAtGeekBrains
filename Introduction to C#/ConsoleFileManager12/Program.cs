using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            int elemOnPage = int.Parse(ConfigurationManager.AppSettings.Get("itemElem"));

            if (elemOnPage < MAX_ELEM_ON_PAGE)
            {
                MAX_ELEM_ON_PAGE = elemOnPage;
            }
            else
            {
                PrintMainWindow();
                ShowMessage($"Количество элементов больше максимального - {MAX_ELEM_ON_PAGE}. Установлено {MAX_ELEM_ON_PAGE} элеменотов");
                Console.ReadKey();
            }

            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "save.txt"))
            {
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "save.txt", true))
                {
                    currPath = sr.ReadToEnd();
                }
            }
            

            while (true)
            {
                PrintWindow();
            }

            Console.ReadLine();
        }

        static readonly int MAX_STAGE = 2;
        static readonly int MIN_WIDTH = 3;
        static readonly int MAX_WIDTH = Console.WindowWidth - 3;
        static readonly int MIN_TREE_HEIGHT = 2;
        static readonly int MAX_TREE_HEIGHT = Console.WindowHeight - 10;
        static List<string> listDirectoriesFiles = new List<string>();
        static int MAX_ELEM_ON_PAGE = MAX_TREE_HEIGHT - MIN_TREE_HEIGHT - 1;
        static List<List<string>> PAGES = new List<List<string>>(listDirectoriesFiles.Count / MAX_ELEM_ON_PAGE + 1);
        static string currPath = "";



        /// <summary>
        /// Печатем все окна и выводим первоначальную страницу каталога
        /// </summary>
        static void PrintWindow()
        {
            PrintMainWindow();
            DirectoryTreeMain();
            PrintPage(0);

            Console.CursorLeft = 2;
            Console.CursorTop = Console.WindowHeight - 3;
            PrintCatalogs(Console.ReadLine());
        }

        /// <summary>
        /// Печатаем только рамки всех окон
        /// </summary>
        static void PrintMainWindow()
        {
            PrintDirectoryPart(new DirectoryInfo(Directory.GetCurrentDirectory()));
            PrintInfoPart(new DirectoryInfo(Directory.GetCurrentDirectory()));   //имя текущего каталога: количество файлов, каталогов, дата создания, еще что -нибудь.
            PrintCommandLine(new DirectoryInfo(Directory.GetCurrentDirectory()));
        }

        #region Вывод рамок и стринички каталога
        /// <summary>
        /// Печатаем только рамку дерева каталогов
        /// </summary>
        /// <param name="directory"></param>
        static void PrintDirectoryPart(DirectoryInfo directory) //координаты ограничения раздела каталогов 
        {
            Console.CursorLeft = 2;
            for (int i = 1; i < Console.BufferWidth - 3; i++)
            {
                Console.CursorTop = 0;
                Console.Write('_');
            }
            Console.CursorTop = 1;
            for (int i = 1; i < Console.WindowHeight - 10; i++)
            {
                Console.CursorLeft = 1;
                Console.Write('|');

                Console.CursorLeft = Console.BufferWidth - 2;
                Console.WriteLine('|');
            }

            Console.CursorLeft = 2;
            for (int i = 1; i < Console.BufferWidth - 3; i++)
            {
                Console.CursorTop = Console.WindowHeight - 11;
                Console.Write('_');
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Печатаем только рамку информации
        /// </summary>
        /// <param name="directory"></param>
        static void PrintInfoPart(DirectoryInfo directory) //имя текущего каталога: количество файлов, каталогов, дата создания, еще что - нибудь.
        {
            for (int i = 1; i < Console.WindowHeight - Console.CursorTop + 3; i++)
            {
                Console.CursorLeft = 1;
                Console.Write('|');

                Console.CursorLeft = Console.BufferWidth - 2;
                Console.WriteLine('|');
            }

            Console.CursorLeft = 2;
            Console.CursorTop -= 1;
            for (int i = 1; i < Console.BufferWidth - 3; i++)
            {
                Console.Write('_');
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Выводим информацию в рамке информации
        /// </summary>
        /// <param name="page"></param>
        static void PrintInInfo(int page)
        {
            Console.CursorTop = Console.WindowHeight - 10;
            Console.CursorLeft = 2;
            Console.Write($"Текущая папка: - {currPath}\n");
            Console.CursorLeft = 2;
            Console.CursorTop = Console.WindowHeight - 8;
            Console.Write($"Текущая страница - {page + 1} из {PAGES.Count}");
        }

        /// <summary>
        /// Печатаем рамку ввода команд
        /// </summary>
        /// <param name="directory"></param>
        static void PrintCommandLine(DirectoryInfo directory)
        {
            for (int i = 1; i < Console.WindowHeight - Console.CursorTop + 3; i++)
            {
                Console.CursorLeft = 1;
                Console.Write('|');

                Console.CursorLeft = Console.BufferWidth - 2;
                Console.WriteLine('|');
            }

            Console.CursorLeft = 2;
            Console.CursorTop -= 1;
            for (int i = 1; i < Console.BufferWidth - 3; i++)
            {
                Console.Write('_');
            }

            Console.CursorLeft = 2;
            Console.CursorTop -= 1;
        }

        /// <summary>
        /// Создаем дерево каталогов
        /// </summary>
        static void DirectoryTreeMain()
        {
            int stage = 2;
            Console.CursorTop = 2;

            if (currPath == "")
            {
                currPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            
            DirectoryTreeRecursion(@currPath, stage);
            SplitPages();
        }

        /// <summary>
        /// Считываем рекурсивно файлы и каталоги по указанному пути на указанную глубину - stage
        /// </summary>
        /// <param name="p"></param>
        /// <param name="stage"></param>
        static void DirectoryTreeRecursion(string p, int stage)
        {
            Console.CursorLeft = MIN_WIDTH;

            DirectoryInfo path = new DirectoryInfo(@p);
            if (!path.Exists)
            {
                ShowMessage("Задано неверное имя каталога");
                return;
            }
            if (stage > MAX_STAGE)
            {
                Console.CursorLeft = MIN_WIDTH;
                AddDirectoriesFiles(path, MAX_STAGE);
                return;
            }

            FileSystemInfo[] subPath = default;
            if (stage == 0)
            {
                AddDirectoriesFiles(path, stage);
            }
            else if ((subPath = path.GetDirectories()).Length == 0)
            {
                Console.CursorLeft = MIN_WIDTH;
                AddDirectoriesFiles(path, stage);
            }
            else
            {
                foreach (var item in subPath)
                {
                    try
                    {
                        Console.CursorLeft = MIN_WIDTH;
                        listDirectoriesFiles.Add(GetTab(stage) + '\\' + item.Name + '\n');
                        Console.CursorLeft = MIN_WIDTH;
                        DirectoryTreeRecursion(item.ToString(), stage - 1);
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message);
                    }
                }
                subPath = path.GetFiles();

                if (subPath.Length == 0)
                {
                    return;
                }
                Console.CursorLeft = MIN_WIDTH;
                try
                {
                    AddDirectoriesFiles(path, stage);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
            if (stage == MAX_STAGE)
            {
                AddDirectoriesFiles(path, stage);
            }
        }

        /// <summary>
        /// Добавляем каталоги и файлы в listDirectoriesFiles
        /// </summary>
        /// <param name="path"></param>
        /// <param name="stage"></param>
        static void AddDirectoriesFiles(DirectoryInfo path, int stage)
        {
            var directories = path.GetDirectories();
            string tab = GetTab(stage);

            if (stage == 0)
            {
                for (int i = 0; i < directories.Length; i++)
                {
                    listDirectoriesFiles.Add(tab + directories[i].Name + '/' + '\n');
                }
            }

            var files = path.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                listDirectoriesFiles.Add(tab + files[i].Name + '\n');
            }

        }

        /// <summary>
        /// Делим на страници все считанные каталоги.
        /// </summary>
        static void SplitPages()
        {
            PAGES = new List<List<string>>();
            int j = 0;
            PAGES.Add(new List<string>());
            for (int i = 0; i < listDirectoriesFiles.Count; i++)
            {
                if (i % MAX_ELEM_ON_PAGE == 0 && i != 0)
                {
                    ++j;
                    PAGES.Add(new List<string>());
                }
                PAGES[j].Add(listDirectoriesFiles[i]);
            }
        }

        /// <summary>
        /// Печатаем и управляем выводом каталогов и файлов в консоль
        /// </summary>
        /// <param name="str"></param>
        static void PrintCatalogs(string str)
        {
            int currPage = 0;

            while (true)
            {
                Console.CursorTop = Console.WindowHeight - 3;
                Console.CursorLeft = 2;
                try
                {
                    switch (str)
                    {
                        case ">":
                            {
                                if (currPage < PAGES.Count - 1)
                                {
                                    PrintPage(++currPage);
                                }
                                else
                                {
                                    PrintPage(currPage);
                                    ShowMessage("Это последняя страница. Дальше пройти нельзя.");
                                }
                                break;
                            }
                        case "<":
                            {
                                if (currPage > 0)
                                {
                                    PrintPage(--currPage);
                                }
                                else
                                {
                                    PrintPage(currPage);
                                    ShowMessage("Это первая страница. Назад вернуться нельзя.");
                                }
                                break;
                            }
                        case "e":
                            {
                                PrintPage(currPage);
                                break;
                            }
                        default:
                            {
                                CommandHandler(str);
                                break;
                            }
                    }
                }
                catch
                {                    
                    
                }
                finally
                {

                }
                PrintInInfo(currPage);
                Console.CursorTop = Console.WindowHeight - 3;
                Console.CursorLeft = 2;
                str = Console.ReadLine();
            }
        }
        
        /// <summary>
        /// Выводим одну страничку каталогов и файлов на консоль. 
        /// </summary>
        /// <param name="numberPage"></param>
        static void PrintPage(int numberPage)
        {
            ClearConsole();
            Console.CursorTop = 2;
            Console.CursorLeft = 2;
            for (int i = 0; i < PAGES[numberPage].Count; i++)
            {
                Console.CursorLeft = 2;
                Console.Write(PAGES[numberPage][i]);
            }
            PrintInInfo(numberPage);
            ShowMessage("Для перемещения по страничкам введите '<' или '>'");

        }

        /// <summary>
        /// Получаем размер отступа от правого края в зависимости от вложенности файлов и папок.
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        static string GetTab(int stage)
        {
            string tab = null;
            for (; stage < MAX_STAGE; ++stage) tab += '\t';
            return tab;
        }

        /// <summary>
        /// Очищаем консоль от зписей. 
        /// </summary>
        static void ClearConsole()
        {
            Console.Clear();
            PrintMainWindow();
        }

        #endregion

        #region команды

        /// <summary>
        /// Обрабатываем команды
        /// </summary>
        /// <param name="str"></param>
        static void CommandHandler(string @str)
        {
            string cmd = GetCommand(str);
            switch (cmd)
            {
                case "ls":
                    {
                        GoToNewPath(GetAddres(str));
                        break;
                    }
                case "cp":
                    {
                        CopyCommand(GetAddres(str));
                        break;
                    }
                case "rm":
                    {
                        Remove(GetAddres(str));
                        break;
                    }
                case "fl":
                    {
                        GetInformation(GetAddres(str));
                        break;
                    }
                case "quit":
                    {
                        File.WriteAllText("save.txt", currPath);
                        Environment.Exit(0);
                        break;
                    }
                default:
                    ShowMessage("Неизвестная команда");
                    break;
            }
        }

        /// <summary>
        /// Получить информацию о папке или файле по указанному полному адресу
        /// </summary>
        /// <param name="path"></param>
        static void GetInformation(string path)
        {
            try
            {

                if (Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    List<string> directoryInfo = new List<string>();
                    directoryInfo.Add("Полный путь - " + directory.FullName + '\n');
                    directoryInfo.Add("Имя папки - " + directory.Name + '\n');
                    directoryInfo.Add("Количество папок - " + directory.GetDirectories("*", SearchOption.AllDirectories).Length + '\n');
                    directoryInfo.Add("Количество файлов - " + directory.GetFiles("*", SearchOption.AllDirectories).Length + '\n');
                    directoryInfo.Add("Время создания - " + directory.CreationTime + '\n');
                    directoryInfo.Add("Время последнего обращения - " + directory.LastWriteTime + '\n');
                    directoryInfo.Add("Атрибут - " + directory.Attributes + '\n');

                    ClearConsole();
                    Console.CursorTop = 2;
                    foreach (var v in directoryInfo)
                    {
                        Console.CursorLeft = 2;
                        Console.Write(v);
                    }

                    ShowMessage("Для выхода нажмите - e");
                }
                else if (File.Exists(path))
                {
                    FileInfo file = new FileInfo(path);
                    List<string> fileInfo = new List<string>();
                    fileInfo.Add("Полный адрес - " + file.FullName + '\n');
                    fileInfo.Add("Имя - " + file.Name + '\n');
                    fileInfo.Add("Время создания - " + file.CreationTime + '\n');
                    fileInfo.Add("Тип - " + file.Extension + '\n');
                    fileInfo.Add("Время последного обращения - " + file.LastWriteTime + '\n');
                    fileInfo.Add("Размер - " + file.Length + " байт" + '\n');
                    fileInfo.Add("Атрибут - " + file.Attributes + '\n');

                    ClearConsole();
                    Console.CursorTop = 2;
                    foreach (var v in fileInfo)
                    {
                        Console.CursorLeft = 2;
                        Console.Write(v);
                    }

                    ShowMessage("Для выхода нажмите - e");
                }
                else
                {
                    ShowMessage("Объект не найден.");
                }
            }
            catch
            {
                ShowMessage("!!! ИСКЛЮЧЕНИЕ в информации объекта!");
            }
        }

        /// <summary>
        /// Удаляем объект.
        /// </summary>
        /// <param name="path"></param>
        static void Remove(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                else if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else
                {
                    ShowMessage("Удаление не выполнено. Объект не существует.");
                }
            }
            catch
            {
                ShowMessage("!!! ИСКЛЮЧЕНИЕ в удалении объекта");
            }
        }

        /// <summary>
        /// Выделяем команду из строки.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string GetCommand(string @str)
        {
            if (str.ToLower() == "quit")
            {
                return str.ToLower();
            }
            if (str.IndexOf(' ') == -1)
                return "";
            return str.Substring(0, str.IndexOf(' ')).ToLower();
        }

        /// <summary>
        /// Выделяем адрес из строки. Адрес не должен содержать пробелы.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string GetAddres(string @str)
        {
            if (GetCommand(str).Length == 0)
                return "";
            return str.Substring(GetCommand(str).Length + 1, str.Length - GetCommand(str).Length - 1);
        }

        /// <summary>
        /// Переход в новую папку
        /// </summary>
        /// <param name="path"></param>
        static void GoToNewPath(string path)
        {
            try
            {
                if (path[1] != ':')
                {
                    currPath += @"\" + path;

                    listDirectoriesFiles = new List<string>();
                    DirectoryTreeRecursion(@currPath, 2);
                    SplitPages();
                    PrintPage(0);
                }
                else
                {
                    currPath = path;

                    listDirectoriesFiles = new List<string>();
                    DirectoryTreeRecursion(@currPath, 2);
                    SplitPages();
                    PrintPage(0);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                //ShowMessage($"!!! ИСКЛЮЧЕНИЕ в переходе в папку {path}");
            }

        }

        /// <summary>
        /// обработчик команды cp - копировать
        /// </summary>
        /// <param name="path"></param>
        static void CopyCommand(string path)
        {
            try
            {
                string[] paths = path.Split(' ');

                if (Directory.Exists(paths[0]))
                {
                    CopyDirectory(paths[0], paths[1]);
                }
                else if (File.Exists(paths[0]))
                {
                    CopyFile(paths[0], paths[1]);
                }
                else
                {
                    ShowMessage("Невозможно произвести копирование. Файла или папки не существует.");
                }
            }
            catch
            {
                ShowMessage("!!! ИСКЛЮЧЕНИЕ при копировании");
            }
        }

        /// <summary>
        /// Копирование файла из pathFrom в pathTo. Если файл существует в папке назначения, то он перезаписывается. 
        /// </summary>
        /// <param name="pathFrom"></param>
        /// <param name="pathTo"></param>
        static void CopyFile(string pathFrom, string pathTo)
        {
            if (!File.Exists(pathTo))
            {
                using (File.Create(pathTo)) { }
            }
            File.Copy(pathFrom, pathTo, true);
            ShowMessage("Копирование файла завершено.");
        }

        /// <summary>
        /// Копируем папку из адреса pathFrom в адрес pathTo. папка назначения должа существовать. 
        /// </summary>
        /// <param name="pathFrom"></param>
        /// <param name="pathTo"></param>
        static void CopyDirectory(string pathFrom, string pathTo)
        {
            //Создаем идентичную структуру папок
            foreach (var path in Directory.GetDirectories(pathFrom, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(path.Replace(pathFrom, pathTo));
                }
                catch
                {
                    ShowMessage("Произошла ошибка при копировании папок");
                }
            }

            foreach (var path in Directory.GetFiles(pathFrom, "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    CopyFile(path, path.Replace(pathFrom, pathTo));
                }
                catch
                {
                    ShowMessage("Произошла ошибка при копировании файлов");
                }
            }
            ShowMessage("Копирование папки завершено");
        }

        #endregion
        /// <summary>
        /// Выводим сообщение о работе приложения или выполненной операции.
        /// </summary>
        /// <param name="message"></param>
        static void ShowMessage(string message)
        {
            Console.CursorLeft = 2;
            Console.CursorTop = Console.WindowHeight - 6;
            for (int i = 2; i < MAX_WIDTH; i++)
            {
                Console.CursorLeft = i;
                Console.Write(' ');
            }
            
            Console.CursorLeft = 2;
            Console.CursorTop = Console.WindowHeight - 6;
            Console.Write($"Сообщение: {message}.");

            Console.CursorLeft = 2;
            Console.CursorTop = Console.WindowHeight - 3;
            for (int i = 2; i < MAX_WIDTH; i++)
            {
                Console.CursorLeft = i;
                Console.Write(' ');
            }
        }



    }
}
