﻿using ElectronicDiary.DesktopClient.Windows;
using ElectronicDiary.Models;
using ElectronicDiary.SchoolDayStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectronicDiary.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Account studentAccount;
        private Account parentAccount;
        private Account teacherAccount;
        private ISchoolDayStorage schoolDayStorage = new TempSchoolDayStorage();
        public MainWindow()
        {
            InitializeComponent();
            studentAccount = new Account("Yurii","Kalantir","Sergeevich",AccountType.Student); 
            parentAccount = new Account("Yuliya","Kalantir","Valentinovna",AccountType.Parent);
            teacherAccount = new Account("Kapshukova","Svetlana","Ivanovna",AccountType.Teacher);
        }

        private void StudentClick(object sender, RoutedEventArgs e)
        {
            StudentWindow window = new StudentWindow(studentAccount);
            window.Show();
        }
        private void ParentClick(object sender, RoutedEventArgs e)
        {
            ParentWindow window = new ParentWindow(parentAccount,studentAccount);
            window.Show();
        }
        private void TeacherClick(object sender, RoutedEventArgs e)
        {
            TeacherWindow window = new TeacherWindow(teacherAccount);
            window.Show();
        }
        private void AboutClick(object sender, RoutedEventArgs e)
        {
            AboutWindow window = new AboutWindow();
            window.Show();
        }
    }
}
