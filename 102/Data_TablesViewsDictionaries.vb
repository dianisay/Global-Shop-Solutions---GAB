'This script simulates data processing for a "class" concept using DataTables, adds and merges mock records, filters and transforms them via DataViews, joins additional data using Dictionaries, and pushes updated results to a custom database table (GCG_CUSTOM_TABLE). It also creates a UI form to display the data grid.

Program.Sub.ScreenSU.Start
' UI Form Setup
Gui.F_Main..Create(BaseForm)
Gui.F_Main..Caption("Form")
Gui.F_Main..Size(1024,720)
Gui.F_Main..Position(0,0)
Gui.F_Main..AlwaysOnTop(False)
Gui.F_Main..FontName("Tahoma")
Gui.F_Main..FontSize(8.25)
Gui.F_Main..ControlBox(True)
Gui.F_Main..MaxButton(True)
Gui.F_Main..MinButton(True)
Gui.F_Main..Moveable(True)
Gui.F_Main..Sizeable(True)
Gui.F_Main..ShowInTaskBar(True)
Gui.F_Main..TitleBar(True)
Gui.F_Main..Event(UnLoad,F_Main_UnLoad)

' Create a grid control inside the form
Gui.F_Main.GsGcMain.Create(GsGridControl)
Gui.F_Main.GsGcMain.Size(1024,690)
Gui.F_Main.GsGcMain.Position(0,0)
Gui.F_Main.GsGcMain.Anchor(15)
Gui.F_Main.GsGcMain.Dock(5)
Gui.F_Main.GsGcMain.Enabled(True)
Gui.F_Main.GsGcMain.Visible(True)
Gui.F_Main.GsGcMain.Zorder(0)
Program.Sub.ScreenSU.End

Program.Sub.Preflight.Start
' No preflight code used
Program.Sub.Preflight.End

Program.Sub.Main.Start
Function.Intrinsic.UI.UsePixels

' === Declare Local Variables ===
V.Local.sMsg.Declare
V.Local.iCnt.Declare

' === Create and define dtClass DataTable structure ===
F.Data.DataTable.Create("dtClass",True)
F.Data.DataTable.AddColumn("dtClass","ClassName","String")
F.Data.DataTable.AddColumn("dtClass","ClassID","Integer")
F.Data.DataTable.AddColumn("dtClass","ClassScore","Float")
F.Data.DataTable.AddColumn("dtClass","ClassDate","DateTime")
F.Data.DataTable.AddColumn("dtClass","ClassCert","Boolean")
F.Data.DataTable.AddColumn("dtClass","ClassCurve","Float")

' === Add calculated (expression) column to dtClass ===
F.Data.DataTable.AddExpressionColumn("dtClass","ClassStatus","String","IIF(IsNull(ClassDate,#1/1/2900#) > #03/11/2025#,'Upcoming',IIF(IsNull(ClassDate,#1/1/2900#) <= #03/11/2025#, 'PAST',''))")

' === Clone dtClass into dtClassTemp and add an extra column ===
F.Data.DataTable.Clone("dtClass","dtClassTemp",True)
F.Data.DataTable.AddColumn("dtClassTemp","ClassTEST","String")

' === Insert mock data into dtClassTemp ===
F.Data.DataTable.AddRow("dtClassTemp","ClassName","GAB 201","ClassID",1,"ClassScore",90.3,"ClassDate",03/11/2025,"ClassCert",True,"ClassCurve",0,"ClassTEST","ABC")
F.Data.DataTable.AddRow("dtClassTemp","ClassName","GAB 201","ClassID",2,"ClassScore",88.5,"ClassDate",04/20/2025,"ClassCert",True,"ClassCurve",5,"ClassTEST","ABC")
F.Data.DataTable.AddRow("dtClassTemp","ClassName","GAB 201","ClassID",3,"ClassScore",93.2,"ClassDate",04/25/2025,"ClassCert",True,"ClassCurve",7,"ClassTEST","ABC")
F.Data.DataTable.AddRow("dtClassTemp","ClassName","GAB 201","ClassID",4,"ClassScore",95.0,"ClassDate",05/15/2025,"ClassCert",True,"ClassCurve",3.5,"ClassTEST","ABC")

' Commit changes in temp table
F.Data.DataTable.AcceptChanges("dtClassTemp")

' === Merge temporary data into main dtClass ===
F.Data.DataTable.Merge("dtClassTemp","dtClass",True,1)

' Clean up
F.Data.DataTable.Close("dtClassTemp")

' === Optionally compute average (commented out) ===
' F.Data.DataTable.Compute("dtClass","Avg([ClassScore])","[ClassScore] > 90",V.Local.sMsg)

' === Generate new series IDs for ClassID ===
F.Data.DataTable.SetSeries("dtClass","ClassID",101,100)

' === Example looping over rows to build string output (no UI display) ===
F.Intrinsic.Control.For(V.Local.iCnt,V.DataTable.dtClass.RowCount--)
	F.Intrinsic.String.Build("{0}{1}{2}",V.Local.sMsg,V.DataTable.dtClass(V.Local.iCnt).ClassDate!FieldValTrim,V.Ambient.NewLine,V.Local.sMsg)
F.Intrinsic.Control.Next(V.Local.iCnt)

' === Create a DataView from dtClass with filtering and sorting ===
F.Data.DataView.Create("dtClass","dvClass",22)
F.Data.DataView.SetFilter("dtClass","dvClass","[ClassScore] > 93")
F.Data.DataView.SetSort("dtClass","dvClass","[ClassID] desc")

' === Set value inside view, create a new DataTable from the filtered view ===
F.Data.DataView.SetValue("dtClass","dvClass",-1,"ClassName","GAB 501")
F.Data.DataView.ToDataTable("dtClass","dvClass","dtNewClass",True)

' === Convert view data to string and back into new DataTable ===
F.Data.DataView.ToString("dtClass","dvClass",V.DataTable.dtClass.FieldNames,"*!*","#$#",V.Local.sMsg)
F.Data.DataTable.CreateFromString("dtString",V.Local.sMsg,V.DataTable.dtClass.FieldNames,"String*!*String*!*String*!*String*!*String*!*String*!*String*!*String","*!*","#$#",True)
F.Data.DataTable.Close("dtString")

' === Dictionary demo with overwrite and lookup ===
F.Data.Dictionary.Create("dictDictionary")
F.Data.Dictionary.AddItem("dictDictionary","Key1","Value1")
F.Data.Dictionary.AddItem("dictDictionary","Key2","Value2")
F.Data.Dictionary.AddItem("dictDictionary","Key3","Value3")
F.Data.Dictionary.AddItem("dictDictionary","Key4","Value4")
F.Data.Dictionary.AddItem("dictDictionary","Key5","Value5")
F.Data.Dictionary.AddItem("dictDictionary","Key3","Value23") ' Overwrites Key3

' Store result from dictionary lookup
V.Local.sMsg.Set(V.Dictionary.dictDictionary!Key3)

' === Load external data from GCG_CUSTOM_TABLE and match with TEXT_INFO2 ===
F.ODBC.Connection!con.OpenCompanyConnection
	F.Data.DataTable.CreateFromSQL("dtCustom","con","SELECT PART, LOC, RTRIM(PART)+RTRIM(LOC) AS PartLoc, PUSER1, PUSER2 FROM GCG_CUSTOM_TABLE",True)
	F.Data.Dictionary.CreateFromSQL("dictTextInfo2","con","SELECT RTRIM(PART)+RTRIM(LOCATION) AS PartLoc, RTRIM(TEXT_INFO2) FROM V_INVENTORY_ALL")
	
	F.Data.Dictionary.SetDefaultReturn("dictTextInfo2","")
	F.Data.DataTable.FillFromDictionary("dtCustom","dictTextInfo2","PartLoc","PUSER2")
	F.Data.Dictionary.Close("dictTextInfo2")

	F.Data.DataTable.RemoveColumn("dtCustom","PartLoc")

	F.Data.DataTable.SaveToDB("dtCustom","con","GCG_CUSTOM_TABLE","PART*!*LOC",256,"")
F.ODBC.Connection!con.Close

' === Display the view in the UI grid ===
Gui.F_Main.GsGcMain.AddGridviewFromDataview("gvClass","dtClass","dvClass")
Gui.F_Main.GsGcMain.MainView("gvClass")

' === Show the form ===
Gui.F_Main..Show
Program.Sub.Main.End

' === Cleanup when form is closed ===
Program.Sub.F_Main_UnLoad.Start
F.Intrinsic.Control.End
Program.Sub.F_Main_UnLoad.End

' === Script versioning info ===
Program.Sub.Comments.Start
${$5$}$20.1.9133.25878$}$1
${$6$}$tsmith$}$20250311123814709$}$xqPbj9atw05FglvzeFsZ9cqXP+qvG6tXBpEKNTgypcAMwWlHtn+Hjx1x6dxfWZpoNtbHB0tg16Q=
${$7$}$File Version:1.1.20250311173814.0
Program.Sub.Comments.End
