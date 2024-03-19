﻿using ACVPN.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ACVPN.MVVM.ViewModel
{
    internal class MainViewModel:ObservableObject
    {
        /* Commands */
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutDownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand ShowProtectionView { get; set; }
        public RelayCommand ShowSettingsView { get; set; }


        private object _currentView; 

        public object currentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                onPropertyChanged();
            }
             
        }

        public ProtectionViewModel ProtectionVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }


        public MainViewModel()
        {
            ProtectionVM = new ProtectionViewModel();
            currentView = ProtectionVM;
            SettingsVM = new SettingsViewModel();

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
            ShutDownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o => 
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                else
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
            });
            MinimizeWindowCommand = new RelayCommand(o => {Application.Current.MainWindow.WindowState = WindowState.Minimized; });

            ShowProtectionView = new RelayCommand(o => { currentView = ProtectionVM; });
            ShowSettingsView = new RelayCommand(o => { currentView = SettingsVM; });

        }
    }
}
