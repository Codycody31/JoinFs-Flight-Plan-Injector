﻿#pragma checksum "..\..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AC6163F608A4AFCA23A23864264390E5E3AB6BE8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JoinFs_Flight_Plan_Injector;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace JoinFs_Flight_Plan_Injector {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label version;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WhazzupLocation;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SpecifyWhazzupLocation;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox JoinFs;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Other;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonControlStartStop;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox TFL;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JoinFs Flight Plan Injector;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.version = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.WhazzupLocation = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\MainWindow.xaml"
            this.WhazzupLocation.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.WhazzupLocation_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SpecifyWhazzupLocation = ((System.Windows.Controls.CheckBox)(target));
            
            #line 21 "..\..\..\..\MainWindow.xaml"
            this.SpecifyWhazzupLocation.Checked += new System.Windows.RoutedEventHandler(this.SpecifyWhazzupLocation_Checked);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\..\MainWindow.xaml"
            this.SpecifyWhazzupLocation.Unchecked += new System.Windows.RoutedEventHandler(this.SpecifyWhazzupLocation_UnChecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.JoinFs = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.Other = ((System.Windows.Controls.CheckBox)(target));
            
            #line 25 "..\..\..\..\MainWindow.xaml"
            this.Other.Checked += new System.Windows.RoutedEventHandler(this.Other_Checked);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\..\MainWindow.xaml"
            this.Other.Unchecked += new System.Windows.RoutedEventHandler(this.Other_UnChecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonControlStartStop = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\MainWindow.xaml"
            this.ButtonControlStartStop.Click += new System.Windows.RoutedEventHandler(this.StartStop_Clicked);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 27 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TFL = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            
            #line 31 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Update_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

