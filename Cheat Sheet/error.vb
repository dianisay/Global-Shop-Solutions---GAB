Program.Sub.Main.Start
F.Intrinsic.Control.Catch
	F.Intrinsic.Control.CallSub(Error)
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
