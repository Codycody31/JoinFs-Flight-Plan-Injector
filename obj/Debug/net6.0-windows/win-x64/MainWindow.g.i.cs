﻿#pragma checksum "..\..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6959164ADE20B46ED30DED741CD3D74C1366D15F"
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
using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
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
        
        
        #line 21 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label version;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WhazzupLocation;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SpecifyWhazzupLocation;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Other;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonControlStartStop;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox TFL;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JoinFs Flight Plan Injector;V0.8.6.0;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
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
            
            #line 22 "..\..\..\..\MainWindow.xaml"
            this.WhazzupLocation.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.WhazzupLocation_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SpecifyWhazzupLocation = ((System.Windows.Controls.CheckBox)(target));
            
            #line 23 "..\..\..\..\MainWindow.xaml"
            this.SpecifyWhazzupLocation.Checked += new System.Windows.RoutedEventHandler(this.SpecifyWhazzupLocation_Checked);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\..\MainWindow.xaml"
            this.SpecifyWhazzupLocation.Unchecked += new System.Windows.RoutedEventHandler(this.SpecifyWhazzupLocation_UnChecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Other = ((System.Windows.Controls.CheckBox)(target));
            
            #line 27 "..\..\..\..\MainWindow.xaml"
            this.Other.Checked += new System.Windows.RoutedEventHandler(this.Other_Checked);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\..\MainWindow.xaml"
            this.Other.Unchecked += new System.Windows.RoutedEventHandler(this.Other_UnChecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonControlStartStop = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\MainWindow.xaml"
            this.ButtonControlStartStop.Click += new System.Windows.RoutedEventHandler(this.StartStop_Clicked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 29 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TFL = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            
            #line 33 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Update_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

