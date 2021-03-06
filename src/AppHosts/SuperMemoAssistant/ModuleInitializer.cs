﻿#region License & Metadata

// The MIT License (MIT)
// 
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// 
// 
// Created On:   2020/01/22 09:58
// Modified On:  2020/01/22 10:16
// Modified By:  Alexis

#endregion




using System;
using Anotar.Serilog;
using SuperMemoAssistant.Exceptions;
using SuperMemoAssistant.Extensions;
using SuperMemoAssistant.Interop;
using SuperMemoAssistant.Plugins;
using SuperMemoAssistant.Services.Configuration;
using SuperMemoAssistant.Services.IO.HotKeys;
using SuperMemoAssistant.Services.IO.Keyboard;
using SuperMemoAssistant.Services.IO.Logger;
using SuperMemoAssistant.SMA;
using SuperMemoAssistant.SuperMemo.Common.Content.Layout;

// ReSharper disable NotAccessedVariable
// ReSharper disable JoinDeclarationAndInitializer
// ReSharper disable RedundantAssignment

namespace SuperMemoAssistant
{
  public static class ModuleInitializer
  {
    #region Constants & Statics

    public static IDisposable SentryInstance { get; private set; }

    #endregion




    #region Methods

    public static void Initialize()
    {
      try
      {
        // Required for logging
        Core.SharedConfiguration = new ConfigurationService(SMAFileSystem.SharedConfigDir);

        Core.Logger = LoggerFactory.Create(SMAConst.Name, Core.SharedConfiguration, Services.Sentry.SentryEx.LogToSentry);

        // ReSharper disable once RedundantNameQualifier
        var appType     = typeof(SuperMemoAssistant.App);
        var releaseName = $"SuperMemoAssistant@{appType.GetAssemblyVersion()}";

        SentryInstance = Services.Sentry.SentryEx.Initialize(releaseName);

        Core.Configuration  = new ConfigurationService(SMAFileSystem.ConfigDir.Combine("Core"));
        Core.KeyboardHotKey = KeyboardHookService.Instance;
        Core.HotKeyManager  = HotKeyManager.Instance.Initialize(Core.Configuration, Core.KeyboardHotKey);
        Core.SMA            = SMA.SMA.Instance;

        object tmp;
        tmp = LayoutManager.Instance;
        tmp = PluginManager.Instance;
      }
      catch (SMAException ex)
      {
        LogTo.Warning(ex, "Error during SuperMemoAssistant Initialize().");
      }
      catch (Exception ex)
      {
        LogTo.Error(ex, "Exception thrown during SuperMemoAssistant module Initialize().");
      }
    }

    #endregion
  }
}
