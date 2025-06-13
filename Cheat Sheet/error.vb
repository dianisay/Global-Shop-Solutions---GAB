Program.Sub.Main.Start
' Begin a Try/Catch block to handle any errors that may occur in the main subroutine
F.Intrinsic.Control.Catch
	' If an error occurs, jump to the Error subroutine
	F.Intrinsic.Control.CallSub(Error)
F.Intrinsic.Control.EndTry
Program.Sub.Main.End



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
