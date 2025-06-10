Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start
'GAB training
'Exercise 2
'declare local variables:
V.Local.dOpen.Declare
V.Local.sCustomer.Declare
V.Local.sRouter.Declare
V.Local.dClosed.Declare


'Use the GAB Debugger to find the Passed Variables for Customer, Date Closed, and Router.


'This checks if the script is being run from Hook 16670. If yes, the code inside the If block will run.
F.Intrinsic.Control.If(V.Caller.Hook,=,16670) ' Shop Floor Control > File > Work Orders > Open
	'Launch the GAB Debugger so you can inspect the passed variables.
	Function.Intrinsic.Debug.InvokeDebugger
	'Pause the script so you can look at the values before continuing.
	Function.Intrinsic.Debug.Stop
	
	'These lines copy values from the passed variables into local variable
	F.Intrinsic.String.Set(V.Passed.000020, V.Local.sCustomer)
	F.Intrinsic.String.Set(V.Passed.000006, V.Local.sRouter)
	F.Intrinsic.Date.ConvertDString(V.Passed.000042, "MMDDYY", V.Local.dClosed)
	F.Intrinsic.Date.ConvertDString(V.Passed.000040,"MMDDYY",V.Local.dOpen)
F.Intrinsic.Control.EndIf

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250610132351164$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLKVxCCg+EHxqJuPRiCZMs5PHuNGWiPDvtI=
${$7$}$File Version:1.1.20250610182351.1
Program.Sub.Comments.End
