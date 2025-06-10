Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start
'GAB training
'Exercise 3

V.Local.fPerVal.Declare 'Declares a local variable to temporarily hold the calculated price.


'Edit the script to write back to the Alt Price fields as so: Alt Price 2 back to it self at 5% increase, Alt Price 3 10% decrease, Alt Price 4 25% decrease
F.Intrinsic.Control.If(V.Caller.Hook,=,10210)

	'Launch the GAB Debugger so you can inspect the passed variables.
	Function.Intrinsic.Debug.InvokeDebugger
	'Pause the script so you can look at the values before continuing.
	Function.Intrinsic.Debug.Stop
	
	
	'F.Intrinsic.Math.Mult(Value1, Value2, ReturnVariable) Multiplies the original price by the percentage factor.
	'.Set(...): Writes the new value back to the passed variable, updating the field in the calling screen.


	'Alt Price 2 - 000054
	'Alt Price 3 - 000055
	'Alt Price 4 - 000056
	
	' Increase Alt Price 2 by 5%
	F.Intrinsic.Math.Mult(V.Passed.000054, 1.05, V.Local.fPerVal)
	V.Passed.000054.Set(V.Local.fPerVal)
	
	' Decrease Alt Price 3 by 10%
	F.Intrinsic.Math.Mult(V.Passed.000055, 0.90, V.Local.fPerVal)
	V.Passed.000055.Set(V.Local.fPerVal)
	
	' Decrease Alt Price 4 by 25%
	F.Intrinsic.Math.Mult(V.Passed.000056, 0.75, V.Local.fPerVal)
	V.Passed.000056.Set(V.Local.fPerVal)
	
	'Launch the GAB Debugger so you can inspect the passed variables.
	Function.Intrinsic.Debug.InvokeDebugger
	'Pause the script so you can look at the values before continuing.
	Function.Intrinsic.Debug.Stop
F.Intrinsic.Control.EndIf

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250610134210516$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLKVxCCg+EHxqFx/3s7rpvx53chYXcj+CMk=
${$7$}$File Version:1.1.20250610184210.1
Program.Sub.Comments.End
