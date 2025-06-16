Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start
Function.Intrinsic.UI.UsePixels ' Allows you to use Pixels instead of Twips throughout
F.Intrinsic.Control.Try
V.Local.sTemp.Declare
V.Local.bHasXPath.Declare
V.Local.sDates.Declare
V.Local.sXPath.Declare
V.Local.iCnt.Declare
V.Local.sJSONString.Declare

F.Communication.JSON.ParseFile("C:\Users\droldan\Downloads\GAB Training Session 4-20250313_100149-Meeting Recording\json_example.json")


'-----------------------------------------------READ PATHS INDIVIDUALY-----------------------------------------------
'this is going to read Property1 
F.Communication.JSON.SetProperty("XPath","/json/Property1/")
F.Communication.JSON.ReadProperty("XText",V.Local.sTemp)
F.Intrinsic.String.TrimChar(V.Local.sTemp,V.Ambient.DblQuote,V.Local.sTemp)

Function.Intrinsic.Debug.InvokeDebugger
Function.Intrinsic.Debug.STOP
'Note you're overwriting sTemp


'Read Arrays in JSON:
F.Communication.JSON.SetProperty("XPath","/json/Property8/[1]/Property9/") 
F.Communication.JSON.ReadProperty("XText",V.Local.sTemp)
F.Intrinsic.String.TrimChar(V.Local.sTemp,V.Ambient.DblQuote,V.Local.sTemp)

'What happens if the path doesn't exists? Error:
'F.Communication.JSON.SetProperty("XPath","/json/Property8/[4]/Property9/")
'F.Communication.JSON.ReadProperty("XText",V.Local.sTemp)
'How do I just "explore" if it exist, without error? just an "in case you exist"
'F.Communication.JSON.HasXPath("/json/Property8/[4]/Property9/",V.Local.bHasXPath)

'-----------------------------------------------WHOLE FILE----------------------------------------------------------
'Loop through Array
F.Communication.JSON.ParseFile("C:\Users\droldan\Downloads\GAB Training Session 4-20250313_100149-Meeting Recording\json_exercise.json")

V.Local.bHasXPath.Set(True)
V.Local.iCnt.Set(1) 'I have to set to 1 for my loop

F.Intrinsic.Control.DoUntil(V.Local.bHasXPath.Not)
	F.Intrinsic.String.Build("/json/JSONExample/[{0}]/Date/",V.Local.iCnt,V.Local.sXPath)
	F.Communication.JSON.HasXPath(V.Local.sXPath,V.Local.bHasXPath)
	
	F.Intrinsic.Control.If(V.Local.bHasXPath)
		F.Communication.JSON.SetProperty("XPath",V.Local.sXPath)
		F.Communication.JSON.ReadProperty("XText",V.Local.sTemp)
		F.Intrinsic.String.TrimChar(V.Local.sTemp,V.Ambient.DblQuote,V.Local.sTemp)
		
		F.Intrinsic.Control.If(V.Local.sDates.Trim,=,"")
			V.Local.sDates.Set(V.Local.sTemp)
		F.Intrinsic.Control.Else
			F.Intrinsic.String.Build("{0}{1}{2}",V.Local.sDates,V.Ambient.NewLine,V.Local.sTemp,V.Local.sDates)
		F.Intrinsic.Control.EndIf		
	F.Intrinsic.Control.EndIf
	F.Intrinsic.Math.Add(V.Local.iCnt,1,V.Local.iCnt)
	
F.Intrinsic.Control.Loop

'in this case, after the loop ends, i want a window with the dates
F.Intrinsic.UI.Msgbox(V.Local.sDates)

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

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250616145624769$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLKljPLjl+A6b1QzuP6oFvkBZZwjr17EC2g=
${$7$}$File Version:1.1.20250616195624.1
Program.Sub.Comments.End
