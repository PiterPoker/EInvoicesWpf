﻿#pragma checksum "..\..\..\Pages\Step1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "14D0803204A7DE62E88C0F3AD4DA1DFC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EInvoicesWpf;
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


namespace EInvoicesWpf {
    
    
    /// <summary>
    /// Step1
    /// </summary>
    public partial class Step1 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Pages\Step1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar calendar1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\Step1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\Step1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextBtn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\Step1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DateStart;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\Step1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DateEnd;
        
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
            System.Uri resourceLocater = new System.Uri("/EInvoicesWpf;component/pages/step1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Step1.xaml"
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
            this.calendar1 = ((System.Windows.Controls.Calendar)(target));
            
            #line 21 "..\..\..\Pages\Step1.xaml"
            this.calendar1.MouseMove += new System.Windows.Input.MouseEventHandler(this.calendar1_MouseMove);
            
            #line default
            #line hidden
            
            #line 21 "..\..\..\Pages\Step1.xaml"
            this.calendar1.KeyUp += new System.Windows.Input.KeyEventHandler(this.calendar1_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pages\Step1.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Pages\Step1.xaml"
            this.nextBtn.Click += new System.Windows.RoutedEventHandler(this.nextBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DateStart = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.DateEnd = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

