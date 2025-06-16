Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start
Function.Intrinsic.UI.UsePixels ' Allows you to use Pixels instead of Twips throughout
F.Intrinsic.Control.Try
V.Local.bCheck.Declare
V.Local.sSQL.Declare
V.Local.sCols.Declare
V.Local.sExcelSave.Declare
V.Local.iRowCount.Declare

F.Automation.MSExcel.CheckPresence(V.Local.bCheck)

F.Intrinsic.Control.If(V.Local.bCheck.Not)
	F.Automation.OOGeneral.CheckPresence(V.Local.bCheck)
	F.Intrinsic.Control.If(V.Local.bCheck.Not)
		F.Intrinsic.Control.End
	F.Intrinsic.Control.EndIf
F.Intrinsic.Control.EndIf

F.Intrinsic.File.IsFileLocked("C:\Users\droldan\Desktop\excel.xlsx",V.Local.bCheck)
F.Intrinsic.Control.If(V.Local.bCheck)
    F.Intrinsic.UI.Msgbox("Please close the Excel file","Error - File In Use")
    F.Intrinsic.Control.End
F.Intrinsic.Control.EndIf

F.Automation.MSExcel.CreateAppObject("oExcel")
F.Automation.MSExcel.OpenWorkbook("oExcel","oBook","C:\Users\droldan\Desktop\excel.xlsx")
F.Automation.MSExcel.OpenWorksheet("oBook","oSheet",1)

F.Automation.MSExcel.RowCount("oSheet",V.Local.iRowCount)
F.Automation.MSExcel.WriteCell("oSheet",1,6,"Hi")
F.Automation.MSExcel.WriteCell("oSheet",2,6,"We")
F.Automation.MSExcel.WriteCell("oSheet",3,6,"Are")
F.Automation.MSExcel.WriteCell("oSheet",4,6,"New")

F.Automation.MSExcel.SaveWorkbook("oBook")

F.Automation.MSExcel.DestroyAllObjects("oExcel","oBook","oSheet")

F.Intrinsic.Control.End

F.Intrinsic.Control.Catch
	F.Automation.MSExcel.DestroyAllObjects("oExcel","oBook","oSheet")
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.Finally
	F.Automation.MSExcel.DestroyAllObjects("oExcel","oBook","oSheet")
	F.Intrinsic.Control.End
F.Intrinsic.Control.EndTry
Program.Sub.Main.End

Program.Sub.Error.Start
V.Local.sError.Declare
V.Local.iRet.Declare
V.Local.sSep.Declare
V.Local.sScript.Declare

F.Intrinsic.String.Split(V.Caller.ScriptFile,"\",V.Local.sScript)
V.Local.sScript.Set(V.Local.sScript(V.Local.sScript.UBound))
V.Local.sScript.RedimPreserve(0,0)

F.Intrinsic.String.Build("-------------------------------------------------------------------------------------",,V.Local.sSep)
F.Intrinsic.String.Build("{5} {6}{0}{7}{0}Project: {4}{0}{7}{0}Sub: {1}{0}Line:{8}{0}Error: {2}, {3}", V.Ambient.NewLine, V.Ambient.SubroutineCalledFrom, V.Ambient.ErrorNumber, V.Ambient.ErrorDescription,V.Local.sScript,V.Ambient.Date, V.Ambient.Time,V.Local.sSep,V.Ambient.ErrorLine,V.Local.sError)
F.Intrinsic.UI.Msgbox(V.Local.sError,"Error",V.Local.iRet)
Program.Sub.Error.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250616091018978$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLLdhAkgaNHsPKhttYD3jtkL2gTEdynjDmY=
${$7$}$File Version:1.1.20250616141018.1
Program.Sub.Comments.End
