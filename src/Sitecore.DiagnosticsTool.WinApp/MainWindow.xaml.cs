﻿namespace Sitecore.DiagnosticsTool.WinApp
{
  using System;
  using Sitecore.DiagnosticsTool.WinApp.Model;
  using Sitecore.DiagnosticsTool.WinApp.ViewModel;

  public partial class MainWindow
  {
    #region Constructors

    public MainWindow()
    {
      InitializeComponent();

      _mainWindowViewModel = new MainWindowViewModel();
      _mainWindowViewModel.RequestClose += OnViewModelRequestClose;
      DataContext = _mainWindowViewModel;
    }

    #endregion

    #region Fields

    readonly MainWindowViewModel _mainWindowViewModel;

    #endregion

    #region Properties

    public DataSource Result => _mainWindowViewModel.Source;

    #endregion

    #region Handlers

    private void OnViewModelRequestClose(object sender, EventArgs e)
    {
      Close();
    }

    #endregion
  }
}