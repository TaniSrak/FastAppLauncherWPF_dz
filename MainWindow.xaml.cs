using System;
using System.Diagnostics;
using System.Windows;

namespace FastAppLauncherWPF_dz
{
    public partial class MainWindow : Window
    {
        // процессы для каждого приложения
        Process calcProcess, cmdProcess, wordProcess, excelProcess, ieProcess, defaultBrowserProcess;

        public MainWindow()
        {
            InitializeComponent();
        }

        // запуск приложений
        private void LaunchApp(ref Process process, string path, string errorMessage)
        {
            try
            {
                if (process == null || process.HasExited)
                {
                    process = Process.Start(path);
                }
                else
                {
                    MessageBox.Show("Приложение уже запущено.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(errorMessage);
            }
        }

        // закрытие приложений
        private void CloseApp(ref Process process)
        {
            if (process != null && !process.HasExited)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                    MessageBox.Show("Приложение закрыто.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при закрытии: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Приложение не запущено.");
            }
        }

        // нажатие кнопки для Калькулятора
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            LaunchApp(ref calcProcess, "calc.exe", "Калькулятор не найден.");
        }

        // закрытие Калькулятора
        private void btnCloseCalc_Click(object sender, RoutedEventArgs e)
        {
            CloseApp(ref calcProcess);
        }

        // нажатие кнопки для Командной строки
        private void btnCmd_Click(object sender, RoutedEventArgs e)
        {
            LaunchApp(ref cmdProcess, "cmd.exe", "Командная строка не найдена.");
        }

        // закрытие командной строки
        private void btnCloseCmd_Click(object sender, RoutedEventArgs e)
        {
            CloseApp(ref cmdProcess);
        }

        // обработка нажатия кнопки для MS Word
        private void btnWord_Click(object sender, RoutedEventArgs e)
        {
            LaunchApp(ref wordProcess, @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE", "MS Word не найден.");
        }

        // закрытие MS Word
        private void btnCloseWord_Click(object sender, RoutedEventArgs e)
        {
            CloseApp(ref wordProcess);
        }

        // обработка нажатия кнопки для MS Excel
        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            LaunchApp(ref excelProcess, @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE", "MS Excel не найден.");
        }

        // закрытие MS Excel
        private void btnCloseExcel_Click(object sender, RoutedEventArgs e)
        {
            CloseApp(ref excelProcess);
        }

        // збработка нажатия кнопки для Internet Explorer
        private void btnIE_Click(object sender, RoutedEventArgs e)
        {
            LaunchApp(ref ieProcess, "iexplore.exe", "Internet Explorer не найден.");
        }

        // закрытие Internet Explorer
        private void btnCloseIE_Click(object sender, RoutedEventArgs e)
        {
            CloseApp(ref ieProcess);
        }

        // обработка нажатия кнопки для браузера по умолчанию
        private void btnDefaultBrowser_Click(object sender, RoutedEventArgs e)
        {
            LaunchApp(ref defaultBrowserProcess, "http://ya.ru", "Браузер по умолчанию не найден.");
        }

        // закрытие браузера по умолчанию
        private void btnCloseDefaultBrowser_Click(object sender, RoutedEventArgs e)
        {
            CloseApp(ref defaultBrowserProcess);
        }
    }
}
