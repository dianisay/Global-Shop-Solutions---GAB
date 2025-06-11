Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start


' Declare SQL variable
V.Local.sSql.Declare(String)

' Set SQL query
V.Local.sSql.Set("SELECT customer, Name_Customer, City, State, Zip FROM Customer_Master WHERE Rec = '1';")

' Open connection, run query, and close connection
F.ODBC.Connection!con.OpenCompanyConnection
F.Data.DataTable.CreateFromSQL("Customer", "con", V.Local.sSql)
F.ODBC.Connection!con.Close

'Function.Intrinsic.Debug.InvokeDebugger
'Function.Intrinsic.Debug.Stop

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250611110404005$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLLeizz5jhMnBjzq5L46wU6w/U1hVbUL/Bc=
${$7$}$File Version:1.1.20250611160403.1
Program.Sub.Comments.End
