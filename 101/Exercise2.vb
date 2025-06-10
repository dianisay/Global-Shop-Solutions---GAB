Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start
'GAB training
'Exercise 2

V.Local.dOpen.Declare

'Use the GAB Debugger to find the Passed Variables for Customer, Date Closed, and Router.
F.Intrinsic.Control.If(V.Caller.Hook,=,16670) ' Shop Floor Control > File > Work Orders > Open
	Function.Intrinsic.Debug.InvokeDebugger
	Function.Intrinsic.Debug.Stop
	
	F.Intrinsic.Date.ConvertDString(V.Passed.000040,"MMDDYY",V.Local.dOpen)
F.Intrinsic.Control.EndIf

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$2.0.0.0$}$2
${$6$}$tsmith$}$20231005102733620$}$xqPbj9atw05FglvzeFsZ9cqXP+qvG6tX7DssNeNNwu8QL7xbsRJLtp2B6j1nSEOXeVOk7OSHib0=
Program.Sub.Comments.End
