Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start

'V.Local.sSQL.Declare

' NOT THE BEST PRECTICE: Define the INSERT SQL statement
' V.Local.sSQL.Set("INSERT INTO GCG_CUSTOM_TABLE (PART, LOC, PUSER1, PUSER2) VALUES ('PART001', 'LOC01', 'UserValue1', 'UserValue2'); ")


V.Local.sSQL.Declare(String)
V.Local.PART.Declare(String)
V.Local.LOC.Declare(String)
V.Local.PUSER1.Declare(String)
V.Local.PUSER2.Declare(String)
V.Local.PART_ESC.Declare(String)
V.Local.LOC_ESC.Declare(String)
V.Local.PUSER1_ESC.Declare(String)
V.Local.PUSER2_ESC.Declare(String)
Function.Intrinsic.Debug.InvokeDebugger
Function.Intrinsic.Debug.Stop

' Assign values (could be from user input or variables)
V.Local.PART.Set("PART002")
V.Local.LOC.Set("LOC01")
V.Local.PUSER1.Set("UserValue1")
V.Local.PUSER2.Set("UserValue2")

' Escape single quotes if needed (optional but recommended)
F.Intrinsic.String.Replace(V.Local.PART, "'", "''", V.Local.PART_ESC)
F.Intrinsic.String.Replace(V.Local.LOC, "'", "''", V.Local.LOC_ESC)
F.Intrinsic.String.Replace(V.Local.PUSER1, "'", "''", V.Local.PUSER1_ESC)
F.Intrinsic.String.Replace(V.Local.PUSER2, "'", "''", V.Local.PUSER2_ESC)

' Build SQL statement
F.Intrinsic.String.Build( "INSERT INTO GCG_CUSTOM_TABLE (PART, LOC, PUSER1, PUSER2) VALUES ('{0}', '{1}', '{2}', '{3}');", V.Local.PART_ESC, V.Local.LOC_ESC, V.Local.PUSER1_ESC, V.Local.PUSER2_ESC, V.Local.sSQL)
Function.Intrinsic.Debug.InvokeDebugger
Function.Intrinsic.Debug.Stop

F.ODBC.Connection!con.OpenCompanyConnection
F.ODBC.Connection!con.Execute(V.Local.sSQL)
F.ODBC.Connection!con.Close

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250611101935361$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLIgRYWxIVfNzaq8W6KpsbY7JtkGOfG2Brg=
${$7$}$File Version:1.1.20250611151935.1
Program.Sub.Comments.End
