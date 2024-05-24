Imports Inventor
Imports System.Runtime.InteropServices

Public Class clsMiniToolbar
    Dim invApp As Inventor.Application

    Dim started As Boolean

    Private WithEvents m_miniToolbar As MiniToolbar
    Private WithEvents m_button1 As MiniToolbarButton
    Private WithEvents m_button2 As MiniToolbarButton
    Private WithEvents m_button3 As MiniToolbarTextEditor
    Private WithEvents m_combo As MiniToolbarSlider
    Private WithEvents m_dropDown As MiniToolbarDropdown

    Public Sub New()
        Try
            invApp = Marshal.GetActiveObject("Inventor.Application")
        Catch ex As Exception
            MsgBox("Need to have a session of Inventor running")
            Return
        End Try

        if invApp.Documents.Count > 0 Then
            createMiniToolbar()
        Else
            MsgBox("Need to have a document open")
        End if

    End Sub

    Public Sub createMiniToolbar()
        m_miniToolbar = invApp.CommandManager.CreateMiniToolbar()
        Dim controls As MiniToolbarControls

        controls = m_miniToolbar.Controls

        m_button1 = controls.AddButton("InName选择", "选择", "选择一个尺寸")

        m_button2 = controls.AddButton("InName还原", "还原", "还原尺寸")

        m_button3 = controls.AddButton("InName还原", "还原", "还原尺寸")


        m_button2.AutoHide = True

        m_miniToolbar.Controls.AddSeparator()

        'm_button3 = controls.AddButton("MyButton3", "Button 3", "This is button 3")

        'controls.AddNewLine()

        'm_combo = controls.AddComboBox("MyCombo", True, True, 35)

        'm_combo.AddItem("Item 1", "Item number 1", , True)

        'm_combo.AddItem("Item 2", "Item number 2", , False)

        'm_combo.AddItem("Item 3", "Item number 3", , False)

        'm_combo.AddItem("Item 4", "Item number 4", , True)

        'controls.AddLabel("MyLabel", "Some stuff:", "Stuff")

        'm_dropDown = controls.AddDropdown("MyDropdown", True, True, True)

        'm_dropDown.AddItem("Thing 1", "Thing 1 tooltip", , , , )
        'm_dropDown.AddItem("Thing 2", "Thing 2 tooltip")
        'm_dropDown.AddItem("Thing 3", "Thing 3 tooltip", , , , )

        m_miniToolbar.Visible = True



    End Sub


    Private Sub m_button1_OnClick1() Handles m_button1.OnClick

        MsgBox("Clicked ""Button 1""")

    End Sub



    Private Sub m_button2_OnClick1() Handles m_button2.OnClick

        MsgBox("Clicked ""Button 2""")

    End Sub


    Private Sub m_miniToolbar_OnApply() Handles m_miniToolbar.OnApply
        MsgBox("Clicked ""Apply""")
    End Sub



    Private Sub m_miniToolbar_OnCancel() Handles m_miniToolbar.OnCancel

        MsgBox("Clicked ""Cancel""")

        m_miniToolbar = Nothing

        m_button1 = Nothing

        m_button2 = Nothing

        m_button3 = Nothing

        m_combo = Nothing

    End Sub



    Private Sub m_miniToolbar_OnOK() Handles m_miniToolbar.OnOK

        MsgBox("Clicked ""Ok""")

        m_miniToolbar = Nothing

        m_button1 = Nothing

        m_button2 = Nothing

        m_button3 = Nothing

        m_combo = Nothing

    End Sub
End Class
