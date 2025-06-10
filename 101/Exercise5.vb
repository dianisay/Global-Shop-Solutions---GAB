Program.Sub.ScreenSU.Start

' Create the main form called F_Example
Gui.F_Example..Create(BaseForm)

' Set the title of the form window
Gui.F_Example..Caption("Form")

' Set the size of the form (width: 1067, height: 351 pixels)
Gui.F_Example..Size(1067,351)

' Set the minimum X and Y coordinates for resizing (not really used here since it's not sizeable)
Gui.F_Example..MinX(0)
Gui.F_Example..MinY(0)

' Set the position of the form on the screen (top-left corner)
Gui.F_Example..Position(0,0)

' Keep the form on top of other windows? False = no
Gui.F_Example..AlwaysOnTop(False)

' Set the font for the form
Gui.F_Example..FontName("Tahoma")
Gui.F_Example..FontSize(8.25)

' Enable the control box (minimize, close, etc.)
Gui.F_Example..ControlBox(True)

' Disable the maximize button
Gui.F_Example..MaxButton(False)

' Enable the minimize button
Gui.F_Example..MinButton(True)

' Set the mouse pointer style (0 = default)
Gui.F_Example..MousePointer(0)

' Allow the form to be moved
Gui.F_Example..Moveable(True)

' Prevent the form from being resized
Gui.F_Example..Sizeable(False)

' Show the form in the Windows taskbar
Gui.F_Example..ShowInTaskBar(True)

' Show the title bar
Gui.F_Example..TitleBar(True)

' Set the event to run when the form is closed
Gui.F_Example..Event(UnLoad,F_Example_UnLoad)



'-----------------Added elements--------------------





' Create a textbox named txtExample
Gui.F_Example.txtExample.Create(TextBox,"",True,100,20,0,33,36,True,0,"Tahoma",8.25,,1)
' Create a label for the textbox
Gui.F_Example.lblTextbox.Create(Label,"Textbox",True,40,13,0,37,21,True,0,"Tahoma",8.25,,0,0)
Gui.F_Example.lblTextbox.BorderStyle(0) ' No border on the label





' Create a checkbox named chkExample
Gui.F_Example.chkExample.Create(CheckBox)
Gui.F_Example.chkExample.Enabled(True)
Gui.F_Example.chkExample.Visible(True)
Gui.F_Example.chkExample.Zorder(0)
Gui.F_Example.chkExample.Size(75,20)
Gui.F_Example.chkExample.Position(161,36)
Gui.F_Example.chkExample.Caption("Check Box")
Gui.F_Example.chkExample.FontName("Tahoma")
Gui.F_Example.chkExample.FontSize(8.25)





' Create a date picker named dtpExample
Gui.F_Example.dtpExample.Create(DatePicker)
Gui.F_Example.dtpExample.Enabled(True)
Gui.F_Example.dtpExample.Visible(True)
Gui.F_Example.dtpExample.Zorder(0)
Gui.F_Example.dtpExample.Size(100,20)
Gui.F_Example.dtpExample.Position(256,36)
Gui.F_Example.dtpExample.CheckBox(False) ' No checkbox inside the date picker
Gui.F_Example.dtpExample.FontName("Tahoma")
Gui.F_Example.dtpExample.FontSize(8.25)
' Create a label for the date picker
Gui.F_Example.lblDatePicker.Create(Label,"Date Picker",True,54,13,0,260,21,True,0,"Tahoma",8.25,,0,0)
Gui.F_Example.lblDatePicker.BorderStyle(0)





' Create a dropdown list named ddlDropDownList
Gui.F_Example.ddlDropDownList.Create(DropDownList)
Gui.F_Example.ddlDropDownList.Enabled(True)
Gui.F_Example.ddlDropDownList.Visible(True)
Gui.F_Example.ddlDropDownList.Zorder(0)
Gui.F_Example.ddlDropDownList.Size(120,20)
Gui.F_Example.ddlDropDownList.Position(34,95)
Gui.F_Example.ddlDropDownList.FontName("Tahoma")
Gui.F_Example.ddlDropDownList.FontSize(8.25)
' Create a label for the dropdown list
Gui.F_Example.lblDropDownList.Create(Label,"Drop Down List",True,72,13,0,39,80,True,0,"Tahoma",8.25,,0,0)
Gui.F_Example.lblDropDownList.BorderStyle(0)

Program.Sub.ScreenSU.End



Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start
Function.Intrinsic.UI.UsePixels ' Allows you to use Pixels instead of Twips throughout
'GAB Training
'Exercise 5

' Add 5 items to the Drop Down List
Gui.F_Example.ddlDropDownList.AddItem("Option 1", 0)
Gui.F_Example.ddlDropDownList.AddItem("Option 2", 1)
Gui.F_Example.ddlDropDownList.AddItem("Option 3", 2)
Gui.F_Example.ddlDropDownList.AddItem("Option 4", 3)
Gui.F_Example.ddlDropDownList.AddItem("Option 5", 4)

' Set the selected item to index 3 (which is "Option 4")
Gui.F_Example.ddlDropDownList.ListIndex(3)

' Show the form
Gui.F_Example..Show

Program.Sub.Main.End


Program.Sub.F_Example_UnLoad.Start
F.Intrinsic.Control.End
Program.Sub.F_Example_UnLoad.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250610150503960$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLK+Z46nTTM9KtXVUf851OkDxS12ZXSrleU=
${$7$}$File Version:1.1.20250610200503.1
Program.Sub.Comments.End
