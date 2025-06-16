Program.Sub.ScreenSU.Start
Gui.F_Main..Create(BaseForm)
Gui.F_Main..Caption("Form")
Gui.F_Main..Size(1024,720)
Gui.F_Main..MinX(0)
Gui.F_Main..MinY(0)
Gui.F_Main..Position(0,0)
Gui.F_Main..AlwaysOnTop(False)
Gui.F_Main..FontName("Tahoma")
Gui.F_Main..FontSize(8.25)
Gui.F_Main..ControlBox(True)
Gui.F_Main..MaxButton(True)
Gui.F_Main..MinButton(True)
Gui.F_Main..MousePointer(0)
Gui.F_Main..Moveable(True)
Gui.F_Main..Sizeable(True)
Gui.F_Main..ShowInTaskBar(True)
Gui.F_Main..TitleBar(True)
Gui.F_Main.GsGcMain.Create(GsGridControl)
Gui.F_Main.GsGcMain.Enabled(True)
Gui.F_Main.GsGcMain.Visible(True)
Gui.F_Main.GsGcMain.Zorder(0)
Gui.F_Main.GsGcMain.Size(1024,690)
Gui.F_Main.GsGcMain.Position(0,0)
Gui.F_Main.GsGcMain.Dock(5)
Program.Sub.ScreenSU.End

Program.Sub.Preflight.Start
Program.External.Include.Library("200000.lib")
Program.External.Include.Library("300011.lib")
Program.Sub.Preflight.End

Program.Sub.Main.Start
Function.Intrinsic.UI.UsePixels ' Allows you to use Pixels instead of Twips throughout

'Modify this script to pull the following into a DataTable and then attach that data to a gridview on the form and show it.  Add your Try/Catch functions created in Exercise 1.
'Customer Name
'Customer PO
'Order Number
'Line Number (formated to 3 characters)
'Quantity Ordered
'Part
'Description

'Where date ordered was in the last 5 days

F.Intrinsic.Control.Try

F.Intrinsic.Control.CallSub(SetUpContextMenus)
F.Intrinsic.Control.CallSub(LoadData)
F.Intrinsic.Control.CallSub(FormatGrid)
F.Intrinsic.Control.CallSub(Deserialize)

Gui.F_Main..Show

' Begin a Try/Catch block to handle any errors that may occur in the main subroutine
F.Intrinsic.Control.Catch
	' If an error occurs, jump to the Error subroutine
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry

F.ODBC.Connection!con.OpenCompanyConnection

F.ODBC.Connection!con.Close

Program.Sub.Main.End

Program.Sub.F_Form_UnLoad.Start
F.Intrinsic.Control.End
Program.Sub.F_Form_UnLoad.End


Program.Sub.SetUpContextMenus.Start
F.Intrinsic.Control.Try

Gui.F_Main..ContextMenuCreate("ctxDash")
Gui.F_Main..ContextMenuAddItem("ctxDash","cmdRefresh",V.Enum.MenuItemType!Button,"Refresh")
Gui.F_Main..ContextMenuAddItem("ctxDash","cmdExport",V.Enum.MenuItemType!Button,"Export")

Gui.F_Main..ContextMenuSetItemEventHandler("ctxDash","cmdRefresh","cmdRefresh_Click")
Gui.F_Main..ContextMenuSetItemEventHandler("ctxDash","cmdExport","cmdExport_Click")

Gui.F_Main.GsGcMain.ContextMenuAttach("ctxDash")

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.SetUpContextMenus.End

Program.Sub.LoadData.Start
F.Intrinsic.Control.Try

F.Intrinsic.Control.CallSub(ODBC_OPEN)

'Customer Name
'Customer PO
'Order Number
'Line Number (formated to 3 characters***) Left(RECORD_NO,3) as ORDER_LINE
'Quantity Ordered
'Part
'Description

	F.Data.DataTable.CreateFromSQL("dtOrderLines","conts","Select '' as NAME_CUSTOMER,CUSTOMER,ORDER_NO,Left(RECORD_NO,3) as ORDER_LINE,QTY_ORDERED,PART,DESCRIPTION from V_ORDER_LINES",True)
	F.Data.Dictionary.CreateFromSQL("dictCustName","conts","Select ORDER_NO,RTRIM(NAME_CUSTOMER) from V_ORDER_BILL_TO")	
F.Intrinsic.Control.CallSub(ODBC_CLOSE)

F.Data.Dictionary.SetDefaultReturn("dictCustName","")
F.Data.DataTable.FillFromDictionary("dtOrderLines","dictCustName","ORDER_NO","NAME_CUSTOMER")
F.Data.Dictionary.Close("dictCustName")	
	
F.Data.DataView.Create("dtOrderLines","dvOrders",22)
F.Data.DataView.SetFilter("dtOrderLines","dvOrders","ORDER_LINE <> '800'")
F.Data.DataView.SetSort("dtOrderLines","dvOrders","ORDER_NO asc, ORDER_LINE asc")

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.LoadData.End

Program.Sub.FormatGrid.Start
F.Intrinsic.Control.Try
V.Local.iCnt.Declare
V.Local.iDateShip.Declare

Gui.F_Main.GsGcMain.AddGridviewFromDataview("gvOrders","dtOrderLines","dvOrders")

Gui.F_Main.GsGcMain.MainView("gvOrders")

Gui.F_Main.GsGcMain.SuspendLayout

Gui.F_Main.GsGcMain.SetGridviewProperty("gvOrders",V.Enum.GridViewPropertyNames!ColumnAutoWidth,False)
Gui.F_Main.GsGcMain.SetGridviewProperty("gvOrders",V.Enum.GridViewPropertyNames!ColumnPanelRowHeight,60)
Gui.F_Main.GsGcMain.SetGridviewProperty("gvOrders",V.Enum.GridViewPropertyNames!EnableAppearanceEvenRow,True)
Gui.F_Main.GsGcMain.SetGridviewProperty("gvOrders",V.Enum.GridViewPropertyNames!ShowFilterPanelMode,"Default")

'New formatting method - Bulk Formatting
'Header Font Bold
F.Intrinsic.Control.CallSub(BulkFormatting,"Form","F_Main","GV","gvOrders","GSGC","GsGcMain","Cols",V.DataTable.dtOrderLines.FieldNames,"Vals","True","Prop",V.Enum.ColumnPropertyNames!HeaderFontBold)
'Captions
F.Intrinsic.Control.CallSub(BulkFormatting,"Form","F_Main","GV","gvOrders","GSGC","GsGcMain","Cols",V.DataTable.dtOrderLines.FieldNames,"Vals","Sales Order*!*Line*!*Cust*!*Customer*!*Part*!*Loc*!*Desc*!*Order Qty*!*Shipped Qty*!*BO Qty*!*UM*!*Unit Price*!*Unit Cost*!*Date Last Ship*!*PL*!*On Hand*!*Notes","Prop",V.Enum.ColumnPropertyNames!Caption)
'Allow Edit - All columns
F.Intrinsic.Control.CallSub(BulkFormatting,"Form","F_Main","GV","gvOrders","GSGC","GsGcMain","Cols",V.DataTable.dtOrderLines.FieldNames,"Vals","False","Prop",V.Enum.ColumnPropertyNames!AllowEdit)
'Column widths
F.Intrinsic.Control.CallSub(BulkFormatting,"Form","F_Main","GV","gvOrders","GSGC","GsGcMain","Cols",V.DataTable.dtOrderLines.FieldNames,"Vals","105*!*59*!*66*!*149*!*127*!*56*!*174*!*108*!*106*!*78*!*54*!*92*!*89*!*125*!*50*!*111*!*300","Prop",V.Enum.ColumnPropertyNames!Width)
'Is hyperlink?
F.Intrinsic.Control.CallSub(BulkFormatting,"Form","F_Main","GV","gvOrders","GSGC","GsGcMain","Cols","ORDER_NO","Vals","True","Prop",V.Enum.ColumnPropertyNames!IsHyperlink)
Gui.F_Main.GsGcMain.Event(RowCellClick,GsGcMain_RowCellClick)
'Custom numeric - quantities
F.Intrinsic.Control.CallSub(BulkFormatting,"Form","F_Main","GV","gvOrders","GSGC","GsGcMain","Cols","QTY_ORDERED","Vals","#,##0","Prop",V.Enum.ColumnPropertyNames!DisplayCustomNumeric)

Gui.F_Main.GsGcMain.ResumeLayout

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.FormatGrid.End


Program.Sub.BulkFormatting.Start
F.Intrinsic.Control.Try
V.Local.sCol.Declare
V.Local.sVal.Declare
V.Local.iCnt.Declare
V.Local.iVI.Declare

F.Intrinsic.String.Split(V.Args.Cols,"*!*",V.Local.sCol)
F.Intrinsic.String.Split(V.Args.Vals,"*!*",V.Local.sVal)

V.Local.iVI.Set(-1)
F.Intrinsic.Control.For(V.Local.iCnt,V.Local.sCol.UBound)
	F.Intrinsic.Control.If(V.Local.sCol.UBound,=,V.Local.sVal.UBound)
		Gui.[V.Args.FORM].[V.Args.GSGC].SetColumnProperty(V.Args.GV,V.Local.sCol(V.Local.iCnt),V.Args.Prop,V.Local.sVal(V.Local.iCnt))
	F.Intrinsic.Control.ElseIf(V.Args.Prop,=,V.Enum.ColumnPropertyNames!VisibleIndex)
		Gui.[V.Args.FORM].[V.Args.GSGC].SetColumnProperty(V.Args.GV,V.Local.sCol(V.Local.iCnt),V.Args.Prop,V.Local.iVI.++)
	F.Intrinsic.Control.Else
		Gui.[V.Args.FORM].[V.Args.GSGC].SetColumnProperty(V.Args.GV,V.Local.sCol(V.Local.iCnt),V.Args.Prop,V.Local.sVal)
	F.Intrinsic.Control.EndIf
F.Intrinsic.Control.Next(V.Local.iCnt)

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.BulkFormatting.End

Program.Sub.Serialize.Start
F.Intrinsic.Control.Try
V.Local.sSerialize.Declare

Gui.F_Main.GsGcMain.Serialize("gvOrders",V.Local.sSerialize)

F.Global.Registry.AddValue(V.Caller.User,V.Caller.CompanyCode,"GAB 301 - Gridviews.g2u",20250312,1000,False,"Serialize",False,0,-999.0,1/1/1980,12:00:00 AM,V.Local.sSerialize)

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.Serialize.End

Program.Sub.Deserialize.Start
F.Intrinsic.Control.Try
V.Local.sSerialize.Declare

'0 - Boolean
'1 - Integer
'2 - Float
'3 - Date
'4 - Time
'5 - String
'6 - Extended String - VVal

F.Global.Registry.ReadValue(V.Caller.User,V.Caller.CompanyCode,"GAB 301 - Gridviews.g2u",20250312,1000,6,"",V.Local.sSerialize)

F.Intrinsic.Control.If(V.Local.sSerialize.Trim,<>,"")
	Gui.F_Main.GsGcMain.Deserialize(V.Local.sSerialize)
F.Intrinsic.Control.EndIf

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.Deserialize.End

#Region "Events"

Program.Sub.cmdRefresh_Click.Start
F.Intrinsic.Control.Try

F.Intrinsic.Control.If(V.DataTable.dtOrderLines.Exists)
	F.Intrinsic.Control.CallSub(Serialize)
	F.Data.DataTable.Close("dtOrderLines")
F.Intrinsic.Control.EndIf

Gui.F_Main.GsGcMain.Enabled(False)
Gui.F_Main.GsGcMain.SuspendLayout

F.Intrinsic.Control.CallSub(LoadData)
F.Intrinsic.Control.CallSub(FormatGrid)
F.Intrinsic.Control.CallSub(Deserialize)

Gui.F_Main.GsGcMain.ResumeLayout
Gui.F_Main.GsGcMain.Enabled(True)

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.cmdRefresh_Click.End

Program.Sub.cmdExport_Click.Start
F.Intrinsic.Control.Try
'V.Local.sPath.Declare

'F.Intrinsic.UI.ShowSaveFileDialog("","xlsx | *.xlsx",V.Local.sPath)

Gui.F_Main.GsGcMain.Export("E:\ACC Courses\Avery  - Mar 2025\GAB 301\Export.xlsx","XLSX")

F.Intrinsic.Task.ShellExec(0,"","Export.xlsx","","E:\ACC Courses\Avery  - Mar 2025\GAB 301\",1)

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.cmdExport_Click.End


Program.Sub.GsGcMain_RowCellClick.Start
F.Intrinsic.Control.Try

F.Intrinsic.Control.SelectCase(V.Args.Column.UCase)
	F.Intrinsic.Control.Case("ORDER_NO")
		F.Data.DataTable.AddRow("200000","OrdNum",V.Args.CellValue,"Mode","V","CustNum",V.DataTable.dtOrderLines(V.Args.RowIndex).CUSTOMER!FieldVal)
		Gui.F_Main..Enabled(False)
		F.Intrinsic.Control.CallSub(200000Sync)
		Gui.F_Main..Enabled(True)
		Gui.F_Main..SetFocus
F.Intrinsic.Control.EndSelect

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.GsGcMain_RowCellClick.End

#End Region ' Events

Program.Sub.ODBC_OPEN.Start
F.Intrinsic.Control.Try

F.Intrinsic.Control.If(V.ODBC.conts.Exists,=,False)
	F.ODBC.Connection!conts.OpenCompanyConnection
F.Intrinsic.Control.EndIf

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.ODBC_OPEN.End

Program.Sub.ODBC_CLOSE.Start
F.Intrinsic.Control.Try

F.Intrinsic.Control.If(V.ODBC.conts.Exists)
	F.ODBC.Connection!conts.Close
F.Intrinsic.Control.EndIf

F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.ODBC_CLOSE.End

Program.Sub.F_Main_UnLoad.Start
F.Intrinsic.Control.If(V.DataTable.dtOrderLines.Exists)
	F.Intrinsic.Control.CallSub(Serialize)
	F.Data.DataTable.Close("dtOrderLines")
F.Intrinsic.Control.EndIf
F.Intrinsic.Control.End
Program.Sub.F_Main_UnLoad.End
Program.Sub.Error.Start
' Declare local variables to store error message components
' Final error message string
V.Local.sError.Declare
' Return value from the message box
V.Local.iRet.Declare
' Separator line for formatting
V.Local.sSep.Declare
' Name of the current script file
V.Local.sScript.Declare

' Split the full script file path by "\" and assign just the script file name to sScript
F.Intrinsic.String.Split(V.Caller.ScriptFile,"\",V.Local.sScript)
 ' Get the last part of the path (the file name)
V.Local.sScript.Set(V.Local.sScript(V.Local.sScript.UBound))
' Convert sScript from an array to a simple string (clean-up)
V.Local.sScript.RedimPreserve(0,0)


' Build a separator line for readability in the error message
F.Intrinsic.String.Build("-------------------------------------------------------------------------------------",,V.Local.sSep)

' Build a detailed multi-line error message including:
' - Date and time
' - Script name
' - Subroutine name
' - Line number
' - Error number and message
'    V.Ambient.NewLine,               ' {0} - newline character
'    V.Ambient.SubroutineCalledFrom, ' {1} - subroutine name
'    V.Ambient.ErrorNumber,          ' {2} - error number
'    V.Ambient.ErrorDescription,     ' {3} - error message
'    V.Local.sScript,                ' {4} - script file name
'    V.Ambient.Date,                 ' {5} - current date
'    V.Ambient.Time,                 ' {6} - current time
'    V.Local.sSep,                   ' {7} - separator line
'    V.Ambient.ErrorLine,            ' {8} - line number where error occurred
'    V.Local.sError)                 ' Output string
F.Intrinsic.String.Build("{5} {6}{0}{7}{0}Project: {4}{0}{7}{0}Sub: {1}{0}Line:{8}{0}Error: {2}, {3}", V.Ambient.NewLine, V.Ambient.SubroutineCalledFrom, V.Ambient.ErrorNumber, V.Ambient.ErrorDescription,V.Local.sScript,V.Ambient.Date, V.Ambient.Time,V.Local.sSep,V.Ambient.ErrorLine,V.Local.sError)

' Show the error message in a pop-up box		
F.Intrinsic.UI.Msgbox(V.Local.sError,"Error",V.Local.iRet)
Program.Sub.Error.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250613160604126$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLIeWHZuhuUDVpHfzcN35VyqCy5acyoUvX4=
${$7$}$File Version:1.1.20250613210604.1
Program.Sub.Comments.End
