﻿#pragma checksum "..\..\ToDoListWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D6C618D5826B8EDE33DBC51AD73D5584"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace I_Need_That_A {
    
    
    /// <summary>
    /// ToDoListWindow
    /// </summary>
    public partial class ToDoListWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 46 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddActivity;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEdit;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemoveActivity;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LvToDoList;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MIUrgency;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MIUrgencyDescend;
        
        #line default
        #line hidden
        
        
        #line 224 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MIImportance;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MIImportanceDescend;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnReturn;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\ToDoListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOpenActivityHistory;
        
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
            System.Uri resourceLocater = new System.Uri("/I Need That A;component/todolistwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ToDoListWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.BtnAddActivity = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\ToDoListWindow.xaml"
            this.BtnAddActivity.Click += new System.Windows.RoutedEventHandler(this.BtnAddActivity_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\ToDoListWindow.xaml"
            this.BtnEdit.Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnRemoveActivity = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\ToDoListWindow.xaml"
            this.BtnRemoveActivity.Click += new System.Windows.RoutedEventHandler(this.BtnRemoveActivity_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LvToDoList = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.MIUrgency = ((System.Windows.Controls.MenuItem)(target));
            
            #line 222 "..\..\ToDoListWindow.xaml"
            this.MIUrgency.Click += new System.Windows.RoutedEventHandler(this.MIUrgency_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MIUrgencyDescend = ((System.Windows.Controls.MenuItem)(target));
            
            #line 223 "..\..\ToDoListWindow.xaml"
            this.MIUrgencyDescend.Click += new System.Windows.RoutedEventHandler(this.MIUrgencyDescend_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MIImportance = ((System.Windows.Controls.MenuItem)(target));
            
            #line 224 "..\..\ToDoListWindow.xaml"
            this.MIImportance.Click += new System.Windows.RoutedEventHandler(this.MIImportance_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MIImportanceDescend = ((System.Windows.Controls.MenuItem)(target));
            
            #line 225 "..\..\ToDoListWindow.xaml"
            this.MIImportanceDescend.Click += new System.Windows.RoutedEventHandler(this.MIImportanceDescend_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnReturn = ((System.Windows.Controls.Button)(target));
            
            #line 241 "..\..\ToDoListWindow.xaml"
            this.BtnReturn.Click += new System.Windows.RoutedEventHandler(this.BtnReturn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnOpenActivityHistory = ((System.Windows.Controls.Button)(target));
            
            #line 254 "..\..\ToDoListWindow.xaml"
            this.BtnOpenActivityHistory.Click += new System.Windows.RoutedEventHandler(this.BtnOpenActivityHistory_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 205 "..\..\ToDoListWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnFinishActivity_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

