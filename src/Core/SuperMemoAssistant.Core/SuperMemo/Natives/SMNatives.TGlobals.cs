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
// Created On:   2019/12/13 20:24
// Modified On:  2019/12/14 19:54
// Modified By:  Alexis

#endregion




using System;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming

namespace SuperMemoAssistant.SuperMemo.Natives
{
  public partial class SMNatives
  {
    /// <summary>Global variables</summary>
    public class TGlobals
    {
      #region Constructors

      public TGlobals(NativeData nativeData)
      {
        CurrentConceptIdPtr = new IntPtr(nativeData.Pointers[NativePointers.Globals_CurrentConceptIdPtr]);
        CurrentRootIdPtr    = new IntPtr(nativeData.Pointers[NativePointers.Globals_CurrentRootIdPtr]);
        CurrentHookIdPtr    = new IntPtr(nativeData.Pointers[NativePointers.Globals_CurrentHookIdPtr]);

        IgnoreUserConfirmationPtr = new IntPtr(nativeData.Pointers[NativePointers.Globals_IgnoreUserConfirmationPtr]);
      }

      #endregion




      #region Properties Impl - Public

      public IntPtr CurrentConceptIdPtr { get; }
      public IntPtr CurrentRootIdPtr    { get; }
      public IntPtr CurrentHookIdPtr    { get; }

      
      // Cont.TContents.DeleteCurrentElement
      // 008575BD       call        TContents.MakeVisible
      public IntPtr IgnoreUserConfirmationPtr { get; }

      #endregion
    }
  }
}
