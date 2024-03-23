﻿#pragma checksum "..\..\..\..\CustomElements\CustomToolBar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64FADD514DCE0318FFD2AF9FD4E00A87FD20E72A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome5;
using FontAwesome5.Converters;
using Projekat_HCI.CustomElements;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Projekat_HCI.CustomElements {
    
    
    /// <summary>
    /// CustomToolBar
    /// </summary>
    public partial class CustomToolBar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\CustomElements\CustomToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar ToolBar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\CustomElements\CustomToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton BoldToggleButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\CustomElements\CustomToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton ItalicToggleButton;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\CustomElements\CustomToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton UnderlineToggleButton;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\CustomElements\CustomToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FontFamilyComboBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\CustomElements\CustomToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TextColorComboBox;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\CustomElements\CustomToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FontSizeComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Projekat_HCI;V1.0.0.0;component/customelements/customtoolbar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\CustomElements\CustomToolBar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ToolBar = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 2:
            this.BoldToggleButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 3:
            this.ItalicToggleButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 4:
            this.UnderlineToggleButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 5:
            this.FontFamilyComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 73 "..\..\..\..\CustomElements\CustomToolBar.xaml"
            this.FontFamilyComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FontFamilyComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextColorComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 84 "..\..\..\..\CustomElements\CustomToolBar.xaml"
            this.TextColorComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TextColorComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FontSizeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 110 "..\..\..\..\CustomElements\CustomToolBar.xaml"
            this.FontSizeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FontSizeComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

