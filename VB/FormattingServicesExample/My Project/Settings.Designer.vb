﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34209
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Namespace My


    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")> _
    Friend NotInheritable Partial Class Settings
        Inherits System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As Settings = (CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()), Settings))

        Public Shared ReadOnly Property [Default]() As Settings
            Get
                Return defaultInstance
            End Get
        End Property

        <Global.System.Configuration.ApplicationScopedSettingAttribute(), Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString), Global.System.Configuration.DefaultSettingValueAttribute("Data Source=127.0.0.1;Initial Catalog=XtraCars;Integrated Security=True")> _
        Public ReadOnly Property XtraCarsConnectionString() As String
            Get
                Return (DirectCast(Me("XtraCarsConnectionString"), String))
            End Get
        End Property

        <Global.System.Configuration.ApplicationScopedSettingAttribute(), Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString), Global.System.Configuration.DefaultSettingValueAttribute("Data Source=ZAYTSEV_XP;Initial Catalog=XtraCars;Persist Security Info=True;User I" & "D=sa;Password=123")> _
        Public ReadOnly Property XtraCarsConnectionString1() As String
            Get
                Return (DirectCast(Me("XtraCarsConnectionString1"), String))
            End Get
        End Property
    End Class
End Namespace
