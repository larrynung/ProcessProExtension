﻿#pragma checksum "..\..\..\..\Src\Class\MyControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "50242AF05A3A1BF91BE43AB92CC0DA4D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Wpf.Util;


namespace LevelUp.ProcessPro {
    
    
    /// <summary>
    /// MyControl
    /// </summary>
    public partial class MyControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Src\Class\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LevelUp.ProcessPro.MyControl MyToolWindow;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Src\Class\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgArrow;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Src\Class\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.AutoCompleteBox tbxFilter;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Src\Class\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvProcesses;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Src\Class\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem cmiAttachOrDetach;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Src\Class\MyControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem cmiKill;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProcessPro;component/src/class/mycontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Src\Class\MyControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MyToolWindow = ((LevelUp.ProcessPro.MyControl)(target));
            
            #line 11 "..\..\..\..\Src\Class\MyControl.xaml"
            this.MyToolWindow.Loaded += new System.Windows.RoutedEventHandler(this.MyToolWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\..\Src\Class\MyControl.xaml"
            ((System.Windows.Controls.Button)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Button_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\..\Src\Class\MyControl.xaml"
            ((System.Windows.Controls.Button)(target)).PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Button_PreviewMouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.imgArrow = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            
            #line 27 "..\..\..\..\Src\Class\MyControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbxFilter = ((System.Windows.Controls.AutoCompleteBox)(target));
            
            #line 34 "..\..\..\..\Src\Class\MyControl.xaml"
            this.tbxFilter.Populating += new System.Windows.Controls.PopulatingEventHandler(this.autoCompleteBox1_Populating);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\..\Src\Class\MyControl.xaml"
            this.tbxFilter.TextChanged += new System.Windows.RoutedEventHandler(this.tbxFilter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lvProcesses = ((System.Windows.Controls.ListView)(target));
            
            #line 39 "..\..\..\..\Src\Class\MyControl.xaml"
            this.lvProcesses.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lvProcesses_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmiAttachOrDetach = ((System.Windows.Controls.MenuItem)(target));
            
            #line 42 "..\..\..\..\Src\Class\MyControl.xaml"
            this.cmiAttachOrDetach.Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\..\Src\Class\MyControl.xaml"
            this.cmiAttachOrDetach.Loaded += new System.Windows.RoutedEventHandler(this.MenuItem_Loaded);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cmiKill = ((System.Windows.Controls.MenuItem)(target));
            
            #line 43 "..\..\..\..\Src\Class\MyControl.xaml"
            this.cmiKill.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
